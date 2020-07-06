using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CroppingWhitespacesForms
{
				public static class TextCropper
				{
								public static string EllipsisChars = "...";

								private static readonly Regex prevWord = new Regex(@"\W*\w*$");
								private static readonly Regex nextWord = new Regex(@"\w*\W*");

								[Flags]
								public enum EllipsisFormat
								{
												// Text is not modified.
												None = 0,

												// Text is trimmed at the end of the string. An ellipsis (...)
												// is drawn in place of remaining text.
												End = 1,

												// Text is trimmed at the beginning of the string.
												// An ellipsis (...) is drawn in place of remaining text.
												Start = 2,

												// Text is trimmed in the middle of the string.
												// An ellipsis (...) is drawn in place of remaining text.
												Middle = 3,

												// Preserve as much as possible of the drive and filename information.
												// Must be combined with alignment information.
												Path = 4,

												// Text is trimmed at a word boundary.
												// Must be combined with alignment information.
												Word = 8
								}

								public static string Compact(string text, Control ctrl, EllipsisFormat options)
								{
												using (Graphics dc = ctrl.CreateGraphics())
												{
																Size s = TextRenderer.MeasureText(dc, text, ctrl.Font);

																// control is large enough to display the whole text
																if (s.Width <= ctrl.Width)
																				return text;

																string pre = "";
																string mid = text;
																string post = "";

																bool isPath = (EllipsisFormat.Path & options) != 0;

																// split path string into <drive><directory><filename>
																if (isPath)
																{
																				pre = Path.GetPathRoot(text);
																				mid = Path.GetDirectoryName(text).Substring(pre.Length);
																				post = Path.GetDirectoryName(text).Substring(pre.Length);
																}

																int len = 0;
																int seg = text.Length;
																string fit = "";

																// find the longest string that fits into
																// the control boundaries using bisection method
																while (seg > 1)
																{
																				seg -= seg / 2;

																				int left = len + seg;
																				int right = text.Length;

																				if (left > right)
																								continue;

																				if ((EllipsisFormat.Middle & options) == EllipsisFormat.Middle)
																				{
																								right -= left / 2;
																								left -= left / 2;
																				}

																				else if ((EllipsisFormat.Start & options) != 0)
																				{
																								right -= left;
																								left = 0;
																				}

																				if ((EllipsisFormat.Word & options) != 0)
																				{
																								if ((EllipsisFormat.End & options) != 0)
																								{
																												left -= prevWord.Match(text, 0, left).Length;
																								}
																								if ((EllipsisFormat.Start & options) != 0)
																								{
																												right += nextWord.Match(text, right).Length;
																								}
																				}

																				// build and measure a candidate string with ellipsis
																				string tst = text.Substring(0, left) + EllipsisChars + text.Substring(right);

																				if (isPath)
																				{
																								tst = Path.Combine(Path.Combine(pre, tst), post);
																				}

																				s = TextRenderer.MeasureText(dc, tst, ctrl.Font);

																				// candidate string fits into control boundaries,
																				// try a longer string
																				// stop when seg <= 1
																				if (s.Width <= ctrl.Width)
																				{
																								len += seg;
																								fit = tst;
																				}
																}

																if (len == 0) // string can't fit into control
																{
																				// "path" mode is off, just return ellipsis characters
																				if (!isPath)
																								return EllipsisChars;

																				// <drive> and <directory> are empty, return <filename>
																				if (pre.Length == 0 && mid.Length == 0)
																								return post;

																				// measure "C:\...\filename.ext"
																				fit = Path.Combine(Path.Combine(pre, EllipsisChars), post);

																				s = TextRenderer.MeasureText(dc, fit, ctrl.Font);

																				// if still not fit then return "...\filename.ext"
																				if (s.Width > ctrl.Width)
																								fit = Path.Combine(EllipsisChars, post);
																}

																return fit;
												}
								}
				}
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CroppingWhitespacesForms
{
				public partial class Form1 : Form
				{
								private bool isWritingCount;
								private int offset = 0;

								private readonly TextCropper.EllipsisFormat formatOptions =
												TextCropper.EllipsisFormat.Path;

								private string inputDirectory;
								private string outputDirectory;

								public Form1()
								{
												InitializeComponent();

												vistaFolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

												progressDialog1.Description = "Чертежи обрабатываются";
												progressDialog1.ShowTimeRemaining = true;
												progressDialog1.Text = "asd...";
												progressDialog1.WindowTitle = "Подождите...";
								}

								private void Form1_Load(object sender, EventArgs e)
								{

								}

								private void Form1_Resize(object sender, EventArgs e)
								{
												changeInputFolderTBox.Text = TextCropper.Compact(changeInputFolderTBox.Text,
																changeInputFolderTBox, formatOptions);

												changeOutputFolderTBox.Text = TextCropper.Compact(changeOutputFolderTBox.Text,
																changeOutputFolderTBox, formatOptions);
								}

								private void CheckBox1_CheckedChanged(object sender, EventArgs e)
								{
												isWritingCount = isWritingNumsCheckBox.Checked;
								}

								private void GenerateBtn_Click(object sender, EventArgs e)
								{
												if (changeInputFolderBtn.Text.Length == 0 || changeOutputFolderTBox.Text.Length == 0)
												{
																errorLabel.Visible = true;
																errorLabel.Text = "Перед генерацией необходимо указать пути!";
												}
												else
												{
																errorLabel.Visible = false;

																if (progressDialog1.IsBusy)
																{
																				MessageBox.Show(
																								this, "The progress dialog is already displayed.", "Progress dialog sample"
																				);
																}
																else
																{
																				progressDialog1.Show(this);
																}
												}
								}

								private void ChangeInputFolderBtn_Click(object sender, EventArgs e)
								{
												inputDirectory = SetFolderPath(changeInputFolderTBox);
								}

								private void ChangeOutputFolderBtn_Click(object sender, EventArgs e)
								{
												outputDirectory = SetFolderPath(changeOutputFolderTBox);
								}

								private string GetChoosenFolder(TextBox setBox)
								{
												if (vistaFolderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
												{
																return vistaFolderBrowserDialog1.SelectedPath;
												}

												return setBox.Text;
								}

								private string SetFolderPath(TextBox setBox)
								{
												string folderPath = GetChoosenFolder(setBox);
												setBox.Text = TextCropper.Compact(folderPath, setBox, TextCropper.EllipsisFormat.Path);

												return folderPath;
								}

								//Todo
								private void TextBoxMouseHover(object sender, EventArgs e)
								{
												//var textBox = (TextBox)sender;

												//toolTip.SetToolTip(textBox, textBox.Text);
								}

								private void OffsetTBox_TextChanged(object sender, EventArgs e)
								{
												if (Int32.TryParse(offsetTBox.Text, out int offset))
												{
																errorLabel.Visible = false;
																this.offset = offset;
												}
												else
												{
																errorLabel.Visible = true;
																errorLabel.Text = "Введите число!";
												}
								}

								private void ProgressDialog1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
								{
												var files = Directory.GetFiles(inputDirectory);
												int counter = 0;

												for (int i = 0; i < files.Length; i++)
												{
																if (progressDialog1.CancellationPending) return;
																counter++;
																int percent = (i + 1) * 100 / files.Length;

																progressDialog1.ReportProgress(
																				percent, null, string.Format("Обрабатывается {0} файл из {1}", i, files.Length)
																);

																Task<Bitmap> bitmap = BlueprintsGenerator.GenerateFile(files[i], offset);
																BlueprintsGenerator.DrawCount(bitmap.Result, counter);
																string saveString = string.Format("{0}\\{1}.png", outputDirectory, counter);

																bitmap.Result.Save(saveString, ImageFormat.Png);
																GC.Collect();
												}
								}
				}
}

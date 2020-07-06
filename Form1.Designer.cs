namespace CroppingWhitespacesForms
{
				partial class Form1
				{
								/// <summary>
								/// Required designer variable.
								/// </summary>
								private System.ComponentModel.IContainer components = null;

								/// <summary>
								/// Clean up any resources being used.
								/// </summary>
								/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
								protected override void Dispose(bool disposing)
								{
												if (disposing && (components != null))
												{
																components.Dispose();
												}
												base.Dispose(disposing);
								}

								#region Windows Form Designer generated code

								/// <summary>
								/// Required method for Designer support - do not modify
								/// the contents of this method with the code editor.
								/// </summary>
								private void InitializeComponent()
								{
												this.components = new System.ComponentModel.Container();
												this.isWritingNumsCheckBox = new System.Windows.Forms.CheckBox();
												this.generateBtn = new System.Windows.Forms.Button();
												this.changeInputFolderBtn = new System.Windows.Forms.Button();
												this.changeOutputFolderBtn = new System.Windows.Forms.Button();
												this.label1 = new System.Windows.Forms.Label();
												this.label2 = new System.Windows.Forms.Label();
												this.changeInputFolderTBox = new System.Windows.Forms.TextBox();
												this.changeOutputFolderTBox = new System.Windows.Forms.TextBox();
												this.toolTip = new System.Windows.Forms.ToolTip(this.components);
												this.offsetTBox = new System.Windows.Forms.TextBox();
												this.label3 = new System.Windows.Forms.Label();
												this.errorLabel = new System.Windows.Forms.Label();
												this.vistaFolderBrowserDialog1 = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
												this.progressDialog1 = new Ookii.Dialogs.WinForms.ProgressDialog(this.components);
												this.SuspendLayout();
												// 
												// isWritingNumsCheckBox
												// 
												this.isWritingNumsCheckBox.AutoSize = true;
												this.isWritingNumsCheckBox.Location = new System.Drawing.Point(15, 67);
												this.isWritingNumsCheckBox.Margin = new System.Windows.Forms.Padding(0);
												this.isWritingNumsCheckBox.Name = "isWritingNumsCheckBox";
												this.isWritingNumsCheckBox.Size = new System.Drawing.Size(171, 17);
												this.isWritingNumsCheckBox.TabIndex = 0;
												this.isWritingNumsCheckBox.Text = "Добавить числовой порядок";
												this.isWritingNumsCheckBox.UseVisualStyleBackColor = true;
												this.isWritingNumsCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
												// 
												// generateBtn
												// 
												this.generateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
												this.generateBtn.Location = new System.Drawing.Point(206, 67);
												this.generateBtn.Name = "generateBtn";
												this.generateBtn.Size = new System.Drawing.Size(395, 72);
												this.generateBtn.TabIndex = 1;
												this.generateBtn.Text = "Сгенерировать";
												this.generateBtn.UseVisualStyleBackColor = true;
												this.generateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
												// 
												// changeInputFolderBtn
												// 
												this.changeInputFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
												this.changeInputFolderBtn.Location = new System.Drawing.Point(722, 12);
												this.changeInputFolderBtn.Name = "changeInputFolderBtn";
												this.changeInputFolderBtn.Size = new System.Drawing.Size(75, 20);
												this.changeInputFolderBtn.TabIndex = 3;
												this.changeInputFolderBtn.Text = "Обзор";
												this.changeInputFolderBtn.UseVisualStyleBackColor = true;
												this.changeInputFolderBtn.Click += new System.EventHandler(this.ChangeInputFolderBtn_Click);
												// 
												// changeOutputFolderBtn
												// 
												this.changeOutputFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
												this.changeOutputFolderBtn.Location = new System.Drawing.Point(722, 39);
												this.changeOutputFolderBtn.Name = "changeOutputFolderBtn";
												this.changeOutputFolderBtn.Size = new System.Drawing.Size(75, 20);
												this.changeOutputFolderBtn.TabIndex = 5;
												this.changeOutputFolderBtn.Text = "Обзор";
												this.changeOutputFolderBtn.UseVisualStyleBackColor = true;
												this.changeOutputFolderBtn.Click += new System.EventHandler(this.ChangeOutputFolderBtn_Click);
												// 
												// label1
												// 
												this.label1.AutoSize = true;
												this.label1.Location = new System.Drawing.Point(12, 12);
												this.label1.Name = "label1";
												this.label1.Size = new System.Drawing.Size(173, 13);
												this.label1.TabIndex = 6;
												this.label1.Text = "Папка с исходными чертежами: ";
												// 
												// label2
												// 
												this.label2.AutoSize = true;
												this.label2.Location = new System.Drawing.Point(12, 39);
												this.label2.Name = "label2";
												this.label2.Size = new System.Drawing.Size(128, 13);
												this.label2.TabIndex = 7;
												this.label2.Text = "Папка для сохранения: ";
												// 
												// changeInputFolderTBox
												// 
												this.changeInputFolderTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
												this.changeInputFolderTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
												this.changeInputFolderTBox.Location = new System.Drawing.Point(206, 12);
												this.changeInputFolderTBox.Margin = new System.Windows.Forms.Padding(0);
												this.changeInputFolderTBox.Name = "changeInputFolderTBox";
												this.changeInputFolderTBox.Size = new System.Drawing.Size(510, 20);
												this.changeInputFolderTBox.TabIndex = 8;
												this.changeInputFolderTBox.MouseHover += new System.EventHandler(this.TextBoxMouseHover);
												// 
												// changeOuputFolderTBox
												// 
												this.changeOutputFolderTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
												this.changeOutputFolderTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
												this.changeOutputFolderTBox.Location = new System.Drawing.Point(206, 39);
												this.changeOutputFolderTBox.Margin = new System.Windows.Forms.Padding(0);
												this.changeOutputFolderTBox.Name = "changeOuputFolderTBox";
												this.changeOutputFolderTBox.Size = new System.Drawing.Size(510, 20);
												this.changeOutputFolderTBox.TabIndex = 9;
												this.changeOutputFolderTBox.MouseHover += new System.EventHandler(this.TextBoxMouseHover);
												// 
												// offsetTBox
												// 
												this.offsetTBox.Location = new System.Drawing.Point(107, 94);
												this.offsetTBox.Name = "offsetTBox";
												this.offsetTBox.Size = new System.Drawing.Size(79, 20);
												this.offsetTBox.TabIndex = 10;
												this.offsetTBox.TextChanged += new System.EventHandler(this.OffsetTBox_TextChanged);
												// 
												// label3
												// 
												this.label3.AutoSize = true;
												this.label3.Location = new System.Drawing.Point(12, 94);
												this.label3.Name = "label3";
												this.label3.Size = new System.Drawing.Size(89, 13);
												this.label3.TabIndex = 11;
												this.label3.Text = "Отступ от краёв";
												// 
												// errorLabel
												// 
												this.errorLabel.AutoSize = true;
												this.errorLabel.ForeColor = System.Drawing.Color.Red;
												this.errorLabel.Location = new System.Drawing.Point(12, 126);
												this.errorLabel.Name = "errorLabel";
												this.errorLabel.Size = new System.Drawing.Size(81, 13);
												this.errorLabel.TabIndex = 12;
												this.errorLabel.Text = "Введите число";
												this.errorLabel.Visible = false;
												// 
												// progressDialog1
												// 
												this.progressDialog1.Text = "progressDialog1";
												this.progressDialog1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProgressDialog1_DoWork);
												// 
												// Form1
												// 
												this.AllowDrop = true;
												this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
												this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
												this.ClientSize = new System.Drawing.Size(809, 151);
												this.Controls.Add(this.errorLabel);
												this.Controls.Add(this.label3);
												this.Controls.Add(this.offsetTBox);
												this.Controls.Add(this.changeOutputFolderTBox);
												this.Controls.Add(this.changeInputFolderTBox);
												this.Controls.Add(this.label2);
												this.Controls.Add(this.label1);
												this.Controls.Add(this.changeOutputFolderBtn);
												this.Controls.Add(this.changeInputFolderBtn);
												this.Controls.Add(this.generateBtn);
												this.Controls.Add(this.isWritingNumsCheckBox);
												this.MaximumSize = new System.Drawing.Size(825, 225);
												this.MinimumSize = new System.Drawing.Size(560, 190);
												this.Name = "Form1";
												this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
												this.Text = "Генератор";
												this.Load += new System.EventHandler(this.Form1_Load);
												this.Resize += new System.EventHandler(this.Form1_Resize);
												this.ResumeLayout(false);
												this.PerformLayout();

								}

		#endregion
								private System.Windows.Forms.CheckBox isWritingNumsCheckBox;
								private System.Windows.Forms.Button generateBtn;
								private System.Windows.Forms.Button changeInputFolderBtn;
								private System.Windows.Forms.Button changeOutputFolderBtn;
								private System.Windows.Forms.Label label1;
								private System.Windows.Forms.Label label2;
								private System.Windows.Forms.TextBox changeInputFolderTBox;
								private System.Windows.Forms.TextBox changeOutputFolderTBox;
								private System.Windows.Forms.ToolTip toolTip;
								private System.Windows.Forms.TextBox offsetTBox;
								private System.Windows.Forms.Label label3;
								private System.Windows.Forms.Label errorLabel;
								private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog vistaFolderBrowserDialog1;
		private Ookii.Dialogs.WinForms.ProgressDialog progressDialog1;
	}
}


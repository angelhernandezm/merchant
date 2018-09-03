namespace Merchant.Application {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lblSelectedFile = new System.Windows.Forms.Label();
			this.txtSelectedFile = new System.Windows.Forms.TextBox();
			this.btnFilePicker = new System.Windows.Forms.Button();
			this.btnProcessFile = new System.Windows.Forms.Button();
			this.lstOutput = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lblSelectedFile
			// 
			this.lblSelectedFile.AutoSize = true;
			this.lblSelectedFile.Location = new System.Drawing.Point(13, 55);
			this.lblSelectedFile.Name = "lblSelectedFile";
			this.lblSelectedFile.Size = new System.Drawing.Size(153, 13);
			this.lblSelectedFile.TabIndex = 0;
			this.lblSelectedFile.Text = "Selected Merchant\'s Input File:";
			// 
			// txtSelectedFile
			// 
			this.txtSelectedFile.Location = new System.Drawing.Point(170, 52);
			this.txtSelectedFile.Name = "txtSelectedFile";
			this.txtSelectedFile.ReadOnly = true;
			this.txtSelectedFile.Size = new System.Drawing.Size(244, 20);
			this.txtSelectedFile.TabIndex = 1;
			// 
			// btnFilePicker
			// 
			this.btnFilePicker.Location = new System.Drawing.Point(422, 50);
			this.btnFilePicker.Name = "btnFilePicker";
			this.btnFilePicker.Size = new System.Drawing.Size(31, 23);
			this.btnFilePicker.TabIndex = 2;
			this.btnFilePicker.Text = "...";
			this.btnFilePicker.UseVisualStyleBackColor = true;
			this.btnFilePicker.Click += new System.EventHandler(this.btnFilePicker_Click);
			// 
			// btnProcessFile
			// 
			this.btnProcessFile.Location = new System.Drawing.Point(464, 49);
			this.btnProcessFile.Name = "btnProcessFile";
			this.btnProcessFile.Size = new System.Drawing.Size(75, 23);
			this.btnProcessFile.TabIndex = 3;
			this.btnProcessFile.Text = "&Process File";
			this.btnProcessFile.UseVisualStyleBackColor = true;
			this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);
			// 
			// lstOutput
			// 
			this.lstOutput.FormattingEnabled = true;
			this.lstOutput.Location = new System.Drawing.Point(16, 83);
			this.lstOutput.Name = "lstOutput";
			this.lstOutput.Size = new System.Drawing.Size(523, 121);
			this.lstOutput.TabIndex = 4;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 217);
			this.Controls.Add(this.lstOutput);
			this.Controls.Add(this.btnProcessFile);
			this.Controls.Add(this.btnFilePicker);
			this.Controls.Add(this.txtSelectedFile);
			this.Controls.Add(this.lblSelectedFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Merchant\'s Guide to the Galaxy";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSelectedFile;
		private System.Windows.Forms.TextBox txtSelectedFile;
		private System.Windows.Forms.Button btnFilePicker;
		private System.Windows.Forms.Button btnProcessFile;
		private System.Windows.Forms.ListBox lstOutput;
	}
}


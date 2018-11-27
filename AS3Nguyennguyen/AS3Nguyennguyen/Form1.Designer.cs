namespace AS3Nguyennguyen
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
			this.btnProcess = new System.Windows.Forms.Button();
			this.lstResult = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnProcess
			// 
			this.btnProcess.Location = new System.Drawing.Point(30, 28);
			this.btnProcess.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(123, 75);
			this.btnProcess.TabIndex = 1;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// lstResult
			// 
			this.lstResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstResult.FormattingEnabled = true;
			this.lstResult.ItemHeight = 14;
			this.lstResult.Location = new System.Drawing.Point(30, 138);
			this.lstResult.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.lstResult.Name = "lstResult";
			this.lstResult.Size = new System.Drawing.Size(952, 298);
			this.lstResult.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(420, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "Assignment 3";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(803, 90);
			this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(179, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Coded by Hong Le, Nguyen Nguyen";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1017, 471);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstResult);
			this.Controls.Add(this.btnProcess);
			this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.ListBox lstResult;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}


namespace Lesson7 {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
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
		private void InitializeComponent () {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ucBook1 = new Lesson7.ViewControls.UcBook();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ucCustomer1 = new Lesson7.ViewControls.UcCustomer();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.ucRental1 = new Lesson7.ViewControls.UcRental();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.ucDashBoard1 = new Lesson7.ViewControls.UcDashBoard();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(785, 504);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ucBook1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(777, 478);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "책 등록";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// ucBook1
			// 
			this.ucBook1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBook1.Location = new System.Drawing.Point(3, 3);
			this.ucBook1.Name = "ucBook1";
			this.ucBook1.Size = new System.Drawing.Size(771, 472);
			this.ucBook1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.ucCustomer1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(777, 478);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "고객 등록";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ucCustomer1
			// 
			this.ucCustomer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCustomer1.Location = new System.Drawing.Point(3, 3);
			this.ucCustomer1.Name = "ucCustomer1";
			this.ucCustomer1.Size = new System.Drawing.Size(771, 472);
			this.ucCustomer1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.ucRental1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(777, 478);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "대여 등록";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// ucRental1
			// 
			this.ucRental1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucRental1.Location = new System.Drawing.Point(3, 3);
			this.ucRental1.Name = "ucRental1";
			this.ucRental1.Size = new System.Drawing.Size(771, 472);
			this.ucRental1.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.ucDashBoard1);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(777, 478);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "대여 내역";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// ucDashBoard1
			// 
			this.ucDashBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucDashBoard1.Location = new System.Drawing.Point(3, 3);
			this.ucDashBoard1.Name = "ucDashBoard1";
			this.ucDashBoard1.Size = new System.Drawing.Size(771, 472);
			this.ucDashBoard1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(785, 504);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "도서 대여 시스템";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private ViewControls.UcBook ucBook1;
		private ViewControls.UcCustomer ucCustomer1;
		private ViewControls.UcRental ucRental1;
		private ViewControls.UcDashBoard ucDashBoard1;
	}
}
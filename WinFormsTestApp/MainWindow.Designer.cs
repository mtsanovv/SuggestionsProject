namespace WinFormsTestApp
{
    partial class MainWindow
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
            this.enterDataBtn = new System.Windows.Forms.Button();
            this.searchDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterDataBtn
            // 
            this.enterDataBtn.AutoSize = true;
            this.enterDataBtn.Location = new System.Drawing.Point(112, 139);
            this.enterDataBtn.Name = "enterDataBtn";
            this.enterDataBtn.Size = new System.Drawing.Size(317, 23);
            this.enterDataBtn.TabIndex = 0;
            this.enterDataBtn.Text = "Въвеждане/редакция на данни (валидация при запазване)";
            this.enterDataBtn.UseVisualStyleBackColor = true;
            this.enterDataBtn.Click += new System.EventHandler(this.enterDataBtn_Click);
            // 
            // searchDataBtn
            // 
            this.searchDataBtn.AutoSize = true;
            this.searchDataBtn.Location = new System.Drawing.Point(112, 188);
            this.searchDataBtn.Name = "searchDataBtn";
            this.searchDataBtn.Size = new System.Drawing.Size(323, 23);
            this.searchDataBtn.TabIndex = 1;
            this.searchDataBtn.Text = "Търсене/филтриране на данни (резултатът съдържа данни)";
            this.searchDataBtn.UseVisualStyleBackColor = true;
            this.searchDataBtn.Click += new System.EventHandler(this.searchDataBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchDataBtn);
            this.Controls.Add(this.enterDataBtn);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterDataBtn;
        private System.Windows.Forms.Button searchDataBtn;
    }
}


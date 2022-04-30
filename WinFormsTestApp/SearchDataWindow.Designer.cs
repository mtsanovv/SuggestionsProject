namespace WinFormsTestApp
{
    partial class SearchDataWindow
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.searchNameBtn = new System.Windows.Forms.Button();
            this.breedLabel = new System.Windows.Forms.Label();
            this.breedTextBox = new System.Windows.Forms.TextBox();
            this.searchBreedBtn = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.searchUserBtn = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.searchEmailBtn = new System.Windows.Forms.Button();
            this.catsListBox = new System.Windows.Forms.ListBox();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.suggestionsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(68, 22);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(125, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // searchNameBtn
            // 
            this.searchNameBtn.Location = new System.Drawing.Point(68, 48);
            this.searchNameBtn.Name = "searchNameBtn";
            this.searchNameBtn.Size = new System.Drawing.Size(75, 23);
            this.searchNameBtn.TabIndex = 2;
            this.searchNameBtn.Text = "Search";
            this.searchNameBtn.UseVisualStyleBackColor = true;
            // 
            // breedLabel
            // 
            this.breedLabel.AutoSize = true;
            this.breedLabel.Location = new System.Drawing.Point(24, 108);
            this.breedLabel.Name = "breedLabel";
            this.breedLabel.Size = new System.Drawing.Size(38, 13);
            this.breedLabel.TabIndex = 3;
            this.breedLabel.Text = "Breed:";
            // 
            // breedTextBox
            // 
            this.breedTextBox.Location = new System.Drawing.Point(68, 105);
            this.breedTextBox.Name = "breedTextBox";
            this.breedTextBox.Size = new System.Drawing.Size(125, 20);
            this.breedTextBox.TabIndex = 4;
            // 
            // searchBreedBtn
            // 
            this.searchBreedBtn.Location = new System.Drawing.Point(68, 131);
            this.searchBreedBtn.Name = "searchBreedBtn";
            this.searchBreedBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBreedBtn.TabIndex = 5;
            this.searchBreedBtn.Text = "Search";
            this.searchBreedBtn.UseVisualStyleBackColor = true;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(24, 275);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(32, 13);
            this.userLabel.TabIndex = 6;
            this.userLabel.Text = "User:";
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(68, 272);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(125, 20);
            this.userTextBox.TabIndex = 7;
            // 
            // searchUserBtn
            // 
            this.searchUserBtn.Location = new System.Drawing.Point(68, 298);
            this.searchUserBtn.Name = "searchUserBtn";
            this.searchUserBtn.Size = new System.Drawing.Size(75, 23);
            this.searchUserBtn.TabIndex = 8;
            this.searchUserBtn.Text = "Search";
            this.searchUserBtn.UseVisualStyleBackColor = true;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(24, 360);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 9;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(68, 357);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(125, 20);
            this.emailTextBox.TabIndex = 10;
            // 
            // searchEmailBtn
            // 
            this.searchEmailBtn.Location = new System.Drawing.Point(68, 383);
            this.searchEmailBtn.Name = "searchEmailBtn";
            this.searchEmailBtn.Size = new System.Drawing.Size(75, 23);
            this.searchEmailBtn.TabIndex = 11;
            this.searchEmailBtn.Text = "Search";
            this.searchEmailBtn.UseVisualStyleBackColor = true;
            // 
            // catsListBox
            // 
            this.catsListBox.FormattingEnabled = true;
            this.catsListBox.Location = new System.Drawing.Point(270, 22);
            this.catsListBox.Name = "catsListBox";
            this.catsListBox.Size = new System.Drawing.Size(246, 108);
            this.catsListBox.TabIndex = 12;
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Location = new System.Drawing.Point(270, 272);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(391, 108);
            this.usersListBox.TabIndex = 13;
            // 
            // suggestionsListBox
            // 
            this.suggestionsListBox.FormattingEnabled = true;
            this.suggestionsListBox.Location = new System.Drawing.Point(536, 48);
            this.suggestionsListBox.Name = "suggestionsListBox";
            this.suggestionsListBox.Size = new System.Drawing.Size(241, 186);
            this.suggestionsListBox.TabIndex = 14;
            // 
            // SearchDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.suggestionsListBox);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.catsListBox);
            this.Controls.Add(this.searchEmailBtn);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.searchUserBtn);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.searchBreedBtn);
            this.Controls.Add(this.breedTextBox);
            this.Controls.Add(this.breedLabel);
            this.Controls.Add(this.searchNameBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "SearchDataWindow";
            this.Text = "SearchDataWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button searchNameBtn;
        private System.Windows.Forms.Label breedLabel;
        private System.Windows.Forms.TextBox breedTextBox;
        private System.Windows.Forms.Button searchBreedBtn;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button searchUserBtn;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button searchEmailBtn;
        public System.Windows.Forms.ListBox catsListBox;
        public System.Windows.Forms.ListBox usersListBox;
        public System.Windows.Forms.ListBox suggestionsListBox;
    }
}
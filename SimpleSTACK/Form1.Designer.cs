namespace SimpleSTACK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.password = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.filesTree = new System.Windows.Forms.TreeView();
            this.textFreeSpace = new System.Windows.Forms.TextBox();
            this.uploadProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textUploadSpeed = new System.Windows.Forms.TextBox();
            this.stackUrl = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(199, 36);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(189, 20);
            this.password.TabIndex = 2;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(12, 35);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(181, 20);
            this.userName.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(394, 33);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // filesTree
            // 
            this.filesTree.AllowDrop = true;
            this.filesTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesTree.Location = new System.Drawing.Point(12, 61);
            this.filesTree.Name = "filesTree";
            this.filesTree.Size = new System.Drawing.Size(496, 303);
            this.filesTree.TabIndex = 4;
            // 
            // textFreeSpace
            // 
            this.textFreeSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFreeSpace.Location = new System.Drawing.Point(420, 377);
            this.textFreeSpace.Name = "textFreeSpace";
            this.textFreeSpace.ReadOnly = true;
            this.textFreeSpace.Size = new System.Drawing.Size(52, 22);
            this.textFreeSpace.TabIndex = 6;
            this.textFreeSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uploadProgress
            // 
            this.uploadProgress.Location = new System.Drawing.Point(12, 376);
            this.uploadProgress.Name = "uploadProgress";
            this.uploadProgress.Size = new System.Drawing.Size(269, 23);
            this.uploadProgress.Step = 1;
            this.uploadProgress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Free:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(478, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "GB";
            // 
            // textUploadSpeed
            // 
            this.textUploadSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUploadSpeed.Location = new System.Drawing.Point(287, 377);
            this.textUploadSpeed.Name = "textUploadSpeed";
            this.textUploadSpeed.ReadOnly = true;
            this.textUploadSpeed.Size = new System.Drawing.Size(83, 22);
            this.textUploadSpeed.TabIndex = 10;
            this.textUploadSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stackUrl
            // 
            this.stackUrl.Location = new System.Drawing.Point(12, 9);
            this.stackUrl.Name = "stackUrl";
            this.stackUrl.Size = new System.Drawing.Size(376, 20);
            this.stackUrl.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 401);
            this.Controls.Add(this.stackUrl);
            this.Controls.Add(this.textUploadSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uploadProgress);
            this.Controls.Add(this.textFreeSpace);
            this.Controls.Add(this.filesTree);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SimpleSTACK";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TreeView filesTree;
        private System.Windows.Forms.TextBox textFreeSpace;
        private System.Windows.Forms.ProgressBar uploadProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUploadSpeed;
        private System.Windows.Forms.TextBox stackUrl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


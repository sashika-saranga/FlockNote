namespace FlockNote
{
    partial class Notification
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
            this.dataGridViewNotification = new System.Windows.Forms.DataGridView();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNotification
            // 
            this.dataGridViewNotification.AllowUserToAddRows = false;
            this.dataGridViewNotification.AllowUserToDeleteRows = false;
            this.dataGridViewNotification.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewNotification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fname});
            this.dataGridViewNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNotification.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewNotification.Name = "dataGridViewNotification";
            this.dataGridViewNotification.ReadOnly = true;
            this.dataGridViewNotification.Size = new System.Drawing.Size(336, 377);
            this.dataGridViewNotification.TabIndex = 3;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSignIn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignIn.Location = new System.Drawing.Point(0, 377);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(336, 35);
            this.buttonSignIn.TabIndex = 2;
            this.buttonSignIn.Text = "Sign In ";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // fname
            // 
            this.fname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fname.HeaderText = "";
            this.fname.Name = "fname";
            this.fname.ReadOnly = true;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 412);
            this.Controls.Add(this.dataGridViewNotification);
            this.Controls.Add(this.buttonSignIn);
            this.Name = "Notification";
            this.Text = "FlockNote Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNotification;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
    }
}


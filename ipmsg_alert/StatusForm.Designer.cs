namespace ipmsg_alert
{
    partial class StatusForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.labelIPCount = new System.Windows.Forms.Label();
            this.txtIPView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(105, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelIPCount
            // 
            this.labelIPCount.AutoSize = true;
            this.labelIPCount.Location = new System.Drawing.Point(216, 232);
            this.labelIPCount.Name = "labelIPCount";
            this.labelIPCount.Size = new System.Drawing.Size(31, 12);
            this.labelIPCount.TabIndex = 2;
            this.labelIPCount.Text = "User:";
            // 
            // txtIPView
            // 
            this.txtIPView.Location = new System.Drawing.Point(12, 12);
            this.txtIPView.Multiline = true;
            this.txtIPView.Name = "txtIPView";
            this.txtIPView.ReadOnly = true;
            this.txtIPView.Size = new System.Drawing.Size(260, 209);
            this.txtIPView.TabIndex = 3;
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtIPView);
            this.Controls.Add(this.labelIPCount);
            this.Controls.Add(this.btnClose);
            this.Name = "StatusForm";
            this.ShowIcon = false;
            this.Text = "Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelIPCount;
        private System.Windows.Forms.TextBox txtIPView;
    }
}
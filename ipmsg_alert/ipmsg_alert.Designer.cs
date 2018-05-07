namespace ipmsg_alert
{
    partial class ipmsg_alert
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ipmsg_alert));
            this.btnWatchOn = new System.Windows.Forms.Button();
            this.btnWatchOff = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picBoxMayuko = new System.Windows.Forms.PictureBox();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMayuko)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWatchOn
            // 
            this.btnWatchOn.Location = new System.Drawing.Point(12, 29);
            this.btnWatchOn.Name = "btnWatchOn";
            this.btnWatchOn.Size = new System.Drawing.Size(75, 23);
            this.btnWatchOn.TabIndex = 0;
            this.btnWatchOn.Text = "watch on";
            this.btnWatchOn.UseVisualStyleBackColor = true;
            this.btnWatchOn.Click += new System.EventHandler(this.btnWatchOn_Click);
            // 
            // btnWatchOff
            // 
            this.btnWatchOff.Location = new System.Drawing.Point(140, 29);
            this.btnWatchOff.Name = "btnWatchOff";
            this.btnWatchOff.Size = new System.Drawing.Size(75, 23);
            this.btnWatchOff.TabIndex = 1;
            this.btnWatchOff.Text = "watch off";
            this.btnWatchOff.UseVisualStyleBackColor = true;
            this.btnWatchOff.Click += new System.EventHandler(this.btnWatchOff_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 191);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ipmsg_alert";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(107, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(227, 26);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.menuToolStripMenuItem.Text = "menu";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingToolStripMenuItem.Text = "setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // picBoxMayuko
            // 
            this.picBoxMayuko.Location = new System.Drawing.Point(13, 58);
            this.picBoxMayuko.Name = "picBoxMayuko";
            this.picBoxMayuko.Size = new System.Drawing.Size(202, 191);
            this.picBoxMayuko.TabIndex = 6;
            this.picBoxMayuko.TabStop = false;
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.versionToolStripMenuItem.Text = "version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // ipmsg_alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 296);
            this.Controls.Add(this.picBoxMayuko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnWatchOff);
            this.Controls.Add(this.btnWatchOn);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ipmsg_alert";
            this.Text = "ipmsg alert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ipmsg_alert_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ipmsg_alert_FormClosed);
            this.Load += new System.EventHandler(this.ipmsg_alert_Load);
            this.ClientSizeChanged += new System.EventHandler(this.ipmsg_alert_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMayuko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWatchOn;
        private System.Windows.Forms.Button btnWatchOff;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.PictureBox picBoxMayuko;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
    }
}


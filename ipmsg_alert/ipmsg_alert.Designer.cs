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
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ttContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.picBoxMayuko = new System.Windows.Forms.PictureBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.ssTimer = new System.Windows.Forms.Timer(this.components);
            this.dot_timer = new System.Windows.Forms.Timer(this.components);
            this.ttContext.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.btnWatchOff.Location = new System.Drawing.Point(93, 29);
            this.btnWatchOff.Name = "btnWatchOff";
            this.btnWatchOff.Size = new System.Drawing.Size(75, 23);
            this.btnWatchOff.TabIndex = 1;
            this.btnWatchOff.Text = "watch off";
            this.btnWatchOff.UseVisualStyleBackColor = true;
            this.btnWatchOff.Click += new System.EventHandler(this.btnWatchOff_Click);
            // 
            // txtDefault
            // 
            this.txtDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefault.Location = new System.Drawing.Point(13, 58);
            this.txtDefault.Multiline = true;
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.ReadOnly = true;
            this.txtDefault.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDefault.Size = new System.Drawing.Size(202, 191);
            this.txtDefault.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ttContext;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ipmsg_alert";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // ttContext
            // 
            this.ttContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitContextMenuItem});
            this.ttContext.Name = "ttContext";
            this.ttContext.Size = new System.Drawing.Size(99, 26);
            // 
            // exitContextMenuItem
            // 
            this.exitContextMenuItem.Name = "exitContextMenuItem";
            this.exitContextMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitContextMenuItem.Text = "Exit";
            this.exitContextMenuItem.Click += new System.EventHandler(this.exitContextMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(111, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(227, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.versionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // picBoxMayuko
            // 
            this.picBoxMayuko.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxMayuko.Location = new System.Drawing.Point(13, 58);
            this.picBoxMayuko.Name = "picBoxMayuko";
            this.picBoxMayuko.Size = new System.Drawing.Size(202, 191);
            this.picBoxMayuko.TabIndex = 6;
            this.picBoxMayuko.TabStop = false;
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.Location = new System.Drawing.Point(13, 58);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(202, 191);
            this.txtDetail.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(174, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(41, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ssTimer
            // 
            this.ssTimer.Enabled = true;
            this.ssTimer.Interval = 1000;
            this.ssTimer.Tick += new System.EventHandler(this.ssTimer_Tick);
            // 
            // dot_timer
            // 
            this.dot_timer.Enabled = true;
            this.dot_timer.Interval = 1000;
            this.dot_timer.Tick += new System.EventHandler(this.dot_timer_Tick);
            // 
            // ipmsg_alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 296);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.picBoxMayuko);
            this.Controls.Add(this.txtDefault);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWatchOff);
            this.Controls.Add(this.btnWatchOn);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.txtDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ipmsg_alert";
            this.Text = "ipmsg alert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ipmsg_alert_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ipmsg_alert_FormClosed);
            this.Load += new System.EventHandler(this.ipmsg_alert_Load);
            this.ClientSizeChanged += new System.EventHandler(this.ipmsg_alert_ClientSizeChanged);
            this.ttContext.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMayuko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWatchOn;
        private System.Windows.Forms.Button btnWatchOff;
        private System.Windows.Forms.TextBox txtDefault;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.PictureBox picBoxMayuko;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ttContext;
        private System.Windows.Forms.ToolStripMenuItem exitContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer ssTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Timer dot_timer;
    }
}


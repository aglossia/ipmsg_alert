namespace ipmsg_alert
{
    partial class SettingForm
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
            this.btnCloseSF = new System.Windows.Forms.Button();
            this.chboxSend = new System.Windows.Forms.CheckBox();
            this.chboxReceive = new System.Windows.Forms.CheckBox();
            this.chboxOpen = new System.Windows.Forms.CheckBox();
            this.radioDefault = new System.Windows.Forms.RadioButton();
            this.radioDetail = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMayuko = new System.Windows.Forms.RadioButton();
            this.chboxLeave = new System.Windows.Forms.CheckBox();
            this.txtIPaddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNetWork = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCloseSF
            // 
            this.btnCloseSF.Location = new System.Drawing.Point(63, 215);
            this.btnCloseSF.Name = "btnCloseSF";
            this.btnCloseSF.Size = new System.Drawing.Size(75, 23);
            this.btnCloseSF.TabIndex = 0;
            this.btnCloseSF.Text = "Apply";
            this.btnCloseSF.UseVisualStyleBackColor = true;
            this.btnCloseSF.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chboxSend
            // 
            this.chboxSend.AutoSize = true;
            this.chboxSend.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chboxSend.Location = new System.Drawing.Point(25, 16);
            this.chboxSend.Name = "chboxSend";
            this.chboxSend.Size = new System.Drawing.Size(49, 16);
            this.chboxSend.TabIndex = 1;
            this.chboxSend.Text = "Send";
            this.chboxSend.UseVisualStyleBackColor = true;
            // 
            // chboxReceive
            // 
            this.chboxReceive.AutoSize = true;
            this.chboxReceive.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chboxReceive.Location = new System.Drawing.Point(24, 52);
            this.chboxReceive.Name = "chboxReceive";
            this.chboxReceive.Size = new System.Drawing.Size(65, 16);
            this.chboxReceive.TabIndex = 2;
            this.chboxReceive.Text = "Receive";
            this.chboxReceive.UseVisualStyleBackColor = true;
            // 
            // chboxOpen
            // 
            this.chboxOpen.AutoSize = true;
            this.chboxOpen.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chboxOpen.Location = new System.Drawing.Point(24, 88);
            this.chboxOpen.Name = "chboxOpen";
            this.chboxOpen.Size = new System.Drawing.Size(50, 16);
            this.chboxOpen.TabIndex = 3;
            this.chboxOpen.Text = "Open";
            this.chboxOpen.UseVisualStyleBackColor = true;
            // 
            // radioDefault
            // 
            this.radioDefault.AutoSize = true;
            this.radioDefault.Location = new System.Drawing.Point(6, 10);
            this.radioDefault.Name = "radioDefault";
            this.radioDefault.Size = new System.Drawing.Size(60, 16);
            this.radioDefault.TabIndex = 6;
            this.radioDefault.TabStop = true;
            this.radioDefault.Text = "Default";
            this.radioDefault.UseVisualStyleBackColor = true;
            // 
            // radioDetail
            // 
            this.radioDetail.AutoSize = true;
            this.radioDetail.Location = new System.Drawing.Point(6, 46);
            this.radioDetail.Name = "radioDetail";
            this.radioDetail.Size = new System.Drawing.Size(53, 16);
            this.radioDetail.TabIndex = 7;
            this.radioDetail.TabStop = true;
            this.radioDetail.Text = "Detail";
            this.radioDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMayuko);
            this.groupBox1.Controls.Add(this.radioDefault);
            this.groupBox1.Controls.Add(this.radioDetail);
            this.groupBox1.Location = new System.Drawing.Point(95, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(83, 107);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // radioMayuko
            // 
            this.radioMayuko.AutoSize = true;
            this.radioMayuko.Location = new System.Drawing.Point(6, 81);
            this.radioMayuko.Name = "radioMayuko";
            this.radioMayuko.Size = new System.Drawing.Size(62, 16);
            this.radioMayuko.TabIndex = 8;
            this.radioMayuko.TabStop = true;
            this.radioMayuko.Text = "Mayuko";
            this.radioMayuko.UseVisualStyleBackColor = true;
            // 
            // chboxLeave
            // 
            this.chboxLeave.AutoSize = true;
            this.chboxLeave.Location = new System.Drawing.Point(24, 121);
            this.chboxLeave.Name = "chboxLeave";
            this.chboxLeave.Size = new System.Drawing.Size(54, 16);
            this.chboxLeave.TabIndex = 9;
            this.chboxLeave.Text = "Leave";
            this.chboxLeave.UseVisualStyleBackColor = true;
            // 
            // txtIPaddr
            // 
            this.txtIPaddr.Location = new System.Drawing.Point(59, 153);
            this.txtIPaddr.Name = "txtIPaddr";
            this.txtIPaddr.Size = new System.Drawing.Size(119, 19);
            this.txtIPaddr.TabIndex = 10;
            this.txtIPaddr.TextChanged += new System.EventHandler(this.txtIPaddr_TextChanged);
            this.txtIPaddr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIPaddr_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP";
            // 
            // cmbNetWork
            // 
            this.cmbNetWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetWork.FormattingEnabled = true;
            this.cmbNetWork.Location = new System.Drawing.Point(59, 179);
            this.cmbNetWork.Name = "cmbNetWork";
            this.cmbNetWork.Size = new System.Drawing.Size(119, 20);
            this.cmbNetWork.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "NW";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 250);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNetWork);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPaddr);
            this.Controls.Add(this.chboxLeave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chboxOpen);
            this.Controls.Add(this.chboxReceive);
            this.Controls.Add(this.chboxSend);
            this.Controls.Add(this.btnCloseSF);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseSF;
        private System.Windows.Forms.CheckBox chboxSend;
        private System.Windows.Forms.CheckBox chboxReceive;
        private System.Windows.Forms.CheckBox chboxOpen;
        private System.Windows.Forms.RadioButton radioDefault;
        private System.Windows.Forms.RadioButton radioDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMayuko;
        private System.Windows.Forms.CheckBox chboxLeave;
        private System.Windows.Forms.TextBox txtIPaddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNetWork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
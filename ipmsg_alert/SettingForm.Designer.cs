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
            this.btnCloseSF = new System.Windows.Forms.Button();
            this.chboxSend = new System.Windows.Forms.CheckBox();
            this.chboxReceive = new System.Windows.Forms.CheckBox();
            this.chboxOpen = new System.Windows.Forms.CheckBox();
            this.radioDefault = new System.Windows.Forms.RadioButton();
            this.radioDetail = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMayuko = new System.Windows.Forms.RadioButton();
            this.chboxLeave = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCloseSF
            // 
            this.btnCloseSF.Location = new System.Drawing.Point(63, 152);
            this.btnCloseSF.Name = "btnCloseSF";
            this.btnCloseSF.Size = new System.Drawing.Size(75, 23);
            this.btnCloseSF.TabIndex = 0;
            this.btnCloseSF.Text = "Close";
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
            this.groupBox1.Location = new System.Drawing.Point(102, 6);
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
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 187);
            this.Controls.Add(this.chboxLeave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chboxOpen);
            this.Controls.Add(this.chboxReceive);
            this.Controls.Add(this.chboxSend);
            this.Controls.Add(this.btnCloseSF);
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}
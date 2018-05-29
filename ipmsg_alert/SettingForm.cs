using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipmsg_alert.setting;
using System.Text.RegularExpressions;
using SharpPcap;
using PacketDotNet;
using System.IO;

namespace ipmsg_alert
{
    public partial class SettingForm : Form
    {
        static SettingForm fm;
        func fc = new func();
        Dictionary<string, string> bmpDic = new Dictionary<string, string>();
        static ipmsg_alert.setting retAppSettings = new ipmsg_alert.setting();

        bool ipErrorFlg = false;

        public SettingForm( ipmsg_alert.setting appSettings )
        {
            if (Directory.Exists(@"resource"))
            {
                string[] files = System.IO.Directory.GetFiles(@"resource", "*", System.IO.SearchOption.AllDirectories);

                foreach (string filePath in files)
                {
                    var tmp = Path.GetExtension(filePath);
                    if (Path.GetExtension(filePath) == ".bmp")
                    {
                        bmpDic.Add(Path.GetFileNameWithoutExtension(filePath), filePath);
                    }
                }
            }

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            chboxSend.Checked = appSettings.sendFlg;
            chboxReceive.Checked = appSettings.receiveFlg;
            chboxOpen.Checked = appSettings.openFlg;
            chboxLeave.Checked = appSettings.leaveFlg;
            radioDefault.Checked = appSettings.defaultFlg;
            radioDetail.Checked = appSettings.detailFlg;
            radioMayuko.Checked = appSettings.mykFlg;
            txtIPaddr.Text = appSettings.ipAddr;

            foreach (var x in LivePcapDeviceList.Instance)
            {
                cmbNetWork.Items.Add(x.Interface.FriendlyName);
            }

            cmbNetWork.SelectedIndex = appSettings.netWork;
            
            toolTip1.SetToolTip(cmbNetWork,cmbNetWork.Items[0].ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ipErrorFlg) return;

            retAppSettings.hostName = System.Net.Dns.GetHostName();
            retAppSettings.sendFlg = chboxSend.Checked;
            retAppSettings.receiveFlg = chboxReceive.Checked;
            retAppSettings.openFlg = chboxOpen.Checked;
            retAppSettings.leaveFlg = chboxLeave.Checked;
            retAppSettings.defaultFlg = radioDefault.Checked;
            retAppSettings.detailFlg = radioDetail.Checked;
            retAppSettings.mykFlg = radioMayuko.Checked;
            retAppSettings.ipAddr = txtIPaddr.Text;
            retAppSettings.netWork = cmbNetWork.SelectedIndex;

            System.Xml.Serialization.XmlSerializer serializer1 =
                new System.Xml.Serialization.XmlSerializer(typeof(ipmsg_alert.setting));
            //ファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                Constants.configFileName, false, new System.Text.UTF8Encoding(false));

            //シリアル化し、XMLファイルに保存する
            serializer1.Serialize(sw, retAppSettings);
            
            sw.Close();

            this.Close();
        }

        static public void showSettingForm( ref ipmsg_alert.setting appSettings )
        {
            retAppSettings = appSettings;
            fm = new SettingForm( retAppSettings );
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
            fm.Dispose();
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void txtIPaddr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fc.CheckIpString(txtIPaddr.Text);
                txtIPaddr.BackColor = Color.White;
                btnCloseSF.Enabled = true;
                ipErrorFlg = false;
                //labelIPCaution.Visible = false;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                //labelIPCaution.Visible = true;
                txtIPaddr.BackColor = Color.FromArgb(0xf0, 0xc7, 0xd3);
                btnCloseSF.Enabled = false;
                ipErrorFlg = true;
            }
        }

        async private void txtIPaddr_KeyDown(object sender, KeyEventArgs e)
        {
            string bmpName = txtIPaddr.Text;

            if (e.KeyData == Keys.Enter)
            {
                if (bmpDic.ContainsKey(bmpName))
                {
                    pictureBox1.BringToFront();
                    pictureBox1.ImageLocation = bmpDic[bmpName];
                    await Task.Delay(1000);
                    pictureBox1.SendToBack();

                    pictureBox1.ImageLocation = null;
                }
            }
        }
    }
}

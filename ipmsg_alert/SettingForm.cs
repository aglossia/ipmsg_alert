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

namespace ipmsg_alert
{
    public partial class SettingForm : Form
    {
        static SettingForm fm;
        //public Dictionary<int, bool> returnDic = new Dictionary<int, bool>();

        static ipmsg_alert.setting retAppSettings = new ipmsg_alert.setting();

        public SettingForm( ipmsg_alert.setting appSettings )
        {
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

            //returnDic = watchFlgDic;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            retAppSettings.sendFlg = chboxSend.Checked;
            retAppSettings.receiveFlg = chboxReceive.Checked;
            retAppSettings.openFlg = chboxOpen.Checked;
            retAppSettings.leaveFlg = chboxLeave.Checked;
            retAppSettings.defaultFlg = radioDefault.Checked;
            retAppSettings.detailFlg = radioDetail.Checked;
            retAppSettings.mykFlg = radioMayuko.Checked;
            retAppSettings.ipAddr = txtIPaddr.Text;

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
            //var insDic = fm.returnDic;
            fm.Dispose();

            //return insDic;
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}

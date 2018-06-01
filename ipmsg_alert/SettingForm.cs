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
using System.Security.Permissions;

namespace ipmsg_alert
{
    public partial class SettingForm : Form
    {
        static SettingForm fm;
        func fc = new func();
        Dictionary<string, string> bmpDic = new Dictionary<string, string>();
        static ipmsg_alert.setting retAppSettings = new ipmsg_alert.setting();

        bool ipErrorFlg = false;

        public class CommandOpt
        {
            public bool t_Mode { get; set; }
            public bool p_Mode { get; set; }
            public int modeType
            {
                set
                {
                    this.modeType = value;
                }
                get
                {
                    // モード状態 1bit：t、2bit：p
                    return Convert.ToInt32(this.t_Mode) | (Convert.ToInt32(this.p_Mode)<<1);
                }
            }
            public bool cmdModeFlg
            {
                set
                {
                    this.t_Mode = value;
                    this.p_Mode = value;
                }
                get
                {
                    return this.t_Mode | this.p_Mode;
                }
            }

            public CommandOpt()
            {
                t_Mode = false;
                p_Mode = false;
            }
        }

        CommandOpt co = new CommandOpt();

        public SettingForm( ipmsg_alert.setting appSettings )
        {
            InitializeComponent();

            // resourceフォルダがある場合
            if (Directory.Exists(@"resource"))
            {
                // resouceフォルダ内のファイル一覧を取得
                string[] files = System.IO.Directory.GetFiles(@"resource", "*", System.IO.SearchOption.AllDirectories);

                foreach (string filePath in files)
                {
                    if (Path.GetExtension(filePath) == ".bmp")
                    {
                        // bmpファイルなら{ファイル名、ファイルパス}で登録する
                        bmpDic.Add(Path.GetFileNameWithoutExtension(filePath), filePath);
                    }
                }
            }

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            chboxSend.Checked = appSettings.sendFlg;
            chboxReceive.Checked = appSettings.receiveFlg;
            chboxOpen.Checked = appSettings.openFlg;
            chboxLeave.Checked = appSettings.leaveFlg;
            radioDefault.Checked = appSettings.defaultFlg;
            radioDetail.Checked = appSettings.detailFlg;
            radioMayuko.Checked = appSettings.mykFlg;
            txtIPaddr.Text = appSettings.ipAddr;

            // ネットワーク名一覧を取得
            foreach (var x in LivePcapDeviceList.Instance)
            {
                cmbNetWork.Items.Add(x.Interface.FriendlyName);
            }

            cmbNetWork.SelectedIndex = appSettings.netWork;
            
            toolTip1.SetToolTip(cmbNetWork,cmbNetWork.Items[0].ToString());
        }

        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDBLCLK = 0xA3;

            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                //非クライアント領域がダブルクリックされた時
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
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
            // コマンドモードでない場合
            if (!co.cmdModeFlg)
            {
                try
                {
                    // IPアドレスフォーマットチェック
                    fc.CheckIpString(txtIPaddr.Text);
                    txtIPaddr.BackColor = Color.White;
                    btnCloseSF.Enabled = true;
                    ipErrorFlg = false;
                }
                catch
                {
                    // IPアドレスのフォーマットでない場合に赤にする
                    txtIPaddr.BackColor = Color.FromArgb(0xf0, 0xc7, 0xd3);
                    btnCloseSF.Enabled = false;
                    ipErrorFlg = true;
                }
            }

        }

        async private void txtIPaddr_KeyDown(object sender, KeyEventArgs e)
        {
            string str = txtIPaddr.Text;

            if (e.KeyData == Keys.Enter)
            {
                if (!co.cmdModeFlg)
                {
                    // コマンドモード以外でBMPファイル指定されたとき
                    if (bmpDic.ContainsKey(str))
                    {
                        pictureBox1.ImageLocation = bmpDic[str];
                        pictureBox1.BringToFront();
                        await Task.Delay(retAppSettings.viewTime);
                        pictureBox1.SendToBack();

                        pictureBox1.ImageLocation = null;

                        return;
                    }

                    // モード遷移
                    switch (str)
                    {
                        case "/t":
                            // tモード
                            txtIPaddr.Text = "";
                            txtIPaddr.BackColor = Color.FromArgb(0x99, 0xe9, 0x94);
                            label1.Text = "t";
                            co.t_Mode = true;
                            break;
                        case "/p":
                            // pモード
                            txtIPaddr.Text = "";
                            txtIPaddr.BackColor = Color.FromArgb(0x99, 0xe9, 0x94);
                            label1.Text = "p";
                            co.p_Mode = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // exit入力でモードを抜ける
                    if (co.cmdModeFlg && (str == "exit"))
                    {
                        txtIPaddr.Clear();
                        txtIPaddr.BackColor = Color.White;
                        label1.Text = "IP";
                        co.cmdModeFlg = false;
                    }

                    // モード処理
                    switch (co.modeType & 0xFF)
                    {
                        case 0x1:
                            // tモード
                            int timee = 0;
                            bool result = int.TryParse(str, out timee);

                            if (result)
                            {
                                // 0.1s~10s
                                if ((timee >= 100) && (timee <= 10000))
                                {
                                    retAppSettings.viewTime = timee;
                                    txtIPaddr.Clear();
                                    txtIPaddr.BackColor = Color.White;
                                    label1.Text = "IP";
                                    co.t_Mode = false;                        
                                }
                            }
                            break;
                        case 0x2:
                            // pモード
                            if(str == "test") MessageBox.Show("pmode");
                            break;
                        default:
                            break;
                    }
                }
            }

            // ESCキーでモードを抜ける
            if (co.cmdModeFlg && (e.KeyData == Keys.Escape))
            {
                txtIPaddr.Clear();
                txtIPaddr.BackColor = Color.White;
                label1.Text = "IP";
                co.cmdModeFlg = false;
            }
        }
    }
}

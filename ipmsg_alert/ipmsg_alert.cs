using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
using Microsoft.Win32;
using System.Diagnostics;
using ipmsg_alert.setting;
using System.IO;

namespace ipmsg_alert
{
    public partial class ipmsg_alert : Form
    {
        Dictionary<string, string> localIPDic = new Dictionary<string, string>();

        static func fc = new func();
        string screensaver = fc.GetScreenSaverName();
        int networkIndex;

        LivePcapDevice device;
        static char[] separator = {':'};
        static char[] separatorName = {'\0'};
        string sep_str = new String(separator);
        bool ssFlg = false;
        List<string> tipStack = new List<string>();

        public class setting
        {
            public string hostName { get; set; }
            public bool sendFlg { get; set; }
            public bool receiveFlg { get; set; }
            public bool openFlg { get; set; }
            public bool leaveFlg { get; set; }
            public bool defaultFlg { get; set; }
            public bool detailFlg { get; set; }
            public bool mykFlg { get; set; }
            public string ipAddr { get; set; }
            public int netWork { get; set; }

            public setting()
            {
                hostName = System.Net.Dns.GetHostName();
                sendFlg = false;
                receiveFlg = true;
                openFlg = true;
                leaveFlg = false;
                defaultFlg = true;
                detailFlg = false;
                mykFlg = false;
                ipAddr = "255.255.255.255";
                netWork = 0;
            }
        }

        setting appSettings = new setting();

        public ipmsg_alert()
        {
            InitializeComponent();

#if DEBUG
            this.Text = "[DEBUG]";
            notifyIcon1.Text = "[DEBUG]";
#endif
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ActiveControl = this.btnExit;
            picBoxMayuko.ImageLocation = @"myk.bmp";
            ssTimer.Enabled = true;
            ssTimer.Interval = 1000;

            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            // configファイルがある場合 setting を読み込む
            if (File.Exists(Constants.configFileName))
            {
                System.Xml.Serialization.XmlSerializer serializer = 
                    new System.Xml.Serialization.XmlSerializer(typeof(setting));
                
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    Constants.configFileName, new System.Text.UTF8Encoding(false));

                //XMLファイルから読み込み、逆シリアル化する
                appSettings = (setting)serializer.Deserialize(sr);
                
                sr.Close();

                if (appSettings.hostName != System.Net.Dns.GetHostName())
                {
                    MessageBox.Show(
                        "ネットワーク接続が別マシンの設定となっています。\nIP、ネットワーク設定を確認してください。",
                        "ipmsg_alert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            txtDefault.Visible = appSettings.defaultFlg;
            txtDetail.Visible = appSettings.detailFlg;
            picBoxMayuko.Visible = appSettings.mykFlg;

            // パケットキャプチャ開始
            PcapOpen();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // フォームを表示する
            this.Visible = true;
            
            // 現在の状態が最小化の状態であれば通常の状態に戻す
            if (this.WindowState == FormWindowState.Minimized)
            {   
                this.WindowState = FormWindowState.Normal;
            }
            
            // フォームをアクティブにする
            this.Activate(); 
        }

        private void ipmsg_alert_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                // フォームが最小化の状態であればフォームを非表示にする
                this.Hide();
                // トレイリストのアイコンを表示する
                notifyIcon1.Visible = true; 
            } 
        }

        private void ipmsg_alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        /// <summary>
        /// ipma load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ipmsg_alert_Load(object sender, EventArgs e)
        {
            label1.Text = "watching...";
        }
        
        /// <summary>
        /// WatchON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWatchOn_Click(object sender, EventArgs e)
        {
            if (!device.Opened)
            {
                PcapOpen();

                label1.Text = "watching...";
            }
        }

        /// <summary>
        /// WatchOFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWatchOff_Click(object sender, EventArgs e)
        {
            if (device.Opened)
            {
                PcapClose();

                label1.Text = "stop";

                txtDefault.Clear();
                txtDetail.Clear();
                localIPDic.Clear();
            }
        }

        /// <summary>
        /// BottunExit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            PcapClose();
            
            Application.Exit();
        }

        /// <summary>
        /// PacketCapture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // 0:ver(1fix), 1:Packet number, 2:username, 3, hostname, 4:command, 5:addition
            string[] splitted;
            string[] splittedName;
            
            int srcPort = (e.Packet.Data[34] << 8) + e.Packet.Data[35];
            int dstPort = (e.Packet.Data[36] << 8) + e.Packet.Data[37];

            if((srcPort == 2425) && (dstPort == 2425))
            {
                //Invoke(new Action<bool>((b) => btnExit.Enabled = b),false);
                // 必要な変数を宣言する
                DateTime dtNow = DateTime.Now;

                string srcIP = string.Format("{0}.{1}.{2}.{3}",
                    e.Packet.Data[26], e.Packet.Data[27], e.Packet.Data[28], e.Packet.Data[29]);

                string dstIP = string.Format("{0}.{1}.{2}.{3}",
                    e.Packet.Data[30], e.Packet.Data[31], e.Packet.Data[32], e.Packet.Data[33]);

                int srcIP_host = e.Packet.Data[29];
                int dstIP_host = e.Packet.Data[33];

                string noticeNameIP = appSettings.ipAddr;

                var segment = new ArraySegment<byte>(e.Packet.Data,42,e.Packet.Data.Length - 42);

                string stringbyte = System.Text.Encoding.GetEncoding(932).GetString((segment.ToArray()));
 
                splitted = stringbyte.Split(separator);

                splittedName = splitted[5].Split(separatorName);

                int command = int.Parse(splitted[4]);

                string notice = "";
                string responseMessage = "…";
                string commandMessage = splitted[4];
                string nameMessage = splittedName[0];
                string sendName = "誰か";
                bool flg = false;
                bool flg2 = false;

                switch(command & 0xff)
                {
                    case 0x20:
                        if (srcIP == appSettings.ipAddr)
                        {
                            notice = string.Format("[{0}] 送信したよ", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                            if(localIPDic.ContainsKey(dstIP)) sendName = localIPDic[dstIP];
                            responseMessage = sendName + " に送るで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            flg = appSettings.sendFlg;
                        }

                        break;

                    case 0x30:
                        if (srcIP != appSettings.ipAddr)
                        {
                            notice = string.Format("[{0}] 開封したよ", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                            responseMessage = "開けたで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            flg = appSettings.openFlg;
                        }

                        break;

                    case 0x21:
                        if (srcIP == appSettings.ipAddr)
                        {
                            notice = string.Format("[{0}] 受信したよ", dtNow.ToLongTimeString());
                            noticeNameIP = dstIP;
                            responseMessage = "から受け取ったで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            flg = appSettings.receiveFlg;
                        }

                        break;

                    case 0x3:

                        if (!localIPDic.ContainsKey(srcIP)) localIPDic.Add(srcIP,splittedName[0]);
                        responseMessage = "おるよー";
                        flg2 = true;
                        break;

                    case 0x1:
                        if (!localIPDic.ContainsKey(srcIP)) localIPDic.Add(srcIP,splittedName[0]);
                        responseMessage = "おるかー？";
                        flg2 = true;
                        break;
                    case 0x2:

                        if (localIPDic.ContainsKey(srcIP))
                        {
                            notice = string.Format("[{0}] 帰るよ", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            localIPDic.Remove(srcIP);
                            
                            flg = appSettings.leaveFlg;

                            flg2 = true;
                        }
                        responseMessage = "帰るで";
                        break;
                    default:
                        //responseMessage = splitted[4];
                        //commandMessage = "";
                        break;
                }

                if (flg)
                {
                    if (ssFlg)
                    {
                        tipStack.Add(string.Format("{0} : {1}",
                        notice,
                        nameMessage
                        ));
                    }
                    else
                    {
                        //バルーンヒントのタイトル
                        notifyIcon1.BalloonTipTitle = notice;
                        //バルーンヒントに表示するメッセージ
                        notifyIcon1.BalloonTipText = nameMessage;
                        //バルーンヒントに表示するアイコン
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
                        //バルーンヒントを表示する
                        //表示する時間をミリ秒で指定する
                        notifyIcon1.ShowBalloonTip(300000);
                    }

                }

                if (flg || flg2)
                {
                    Invoke(new Action<string>((msg) => txtDefault.AppendText( msg + Environment.NewLine )),
                        string.Format("[{0}] {1} < {2}",
                        dtNow.ToLongTimeString(),
                        nameMessage,
                        responseMessage));
                }

                Invoke(new Action<string>((msg) => txtDetail.AppendText( msg + Environment.NewLine )),
                    string.Format("[{0}] {1} < {2} < {3}",
                    dtNow.ToLongTimeString(),
                    nameMessage,
                    responseMessage,
                    commandMessage));

                //Invoke(new Action<bool>((b) => btnExit.Enabled = b),true);
            }
            
        }

        /// <summary>
        /// SettingForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm.showSettingForm( ref appSettings );

            if (networkIndex != appSettings.netWork)
            {
                PcapClose();
                PcapOpen();
            }

            txtDefault.Visible = appSettings.defaultFlg;
            txtDetail.Visible = appSettings.detailFlg;
            picBoxMayuko.Visible = appSettings.mykFlg;
        }

        /// <summary>
        /// VersionForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionForm.showVersionForm();
        }

        /// <summary>
        /// ipma close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ipmsg_alert_FormClosed(object sender, FormClosedEventArgs e)
        {
            PcapClose();
            
            Application.Exit();
        }

        /// <summary>
        /// TasktrayContext Exit Proc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitContextMenuItem_Click(object sender, EventArgs e)
        {
            PcapClose();
            
            Application.Exit();
        }

        /// <summary>
        /// menu status proc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusForm.showStatusForm(localIPDic);
        }

        /// <summary>
        /// menu exit proc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PcapClose();
        
            Application.Exit();
        }

        /// <summary>
        /// Clear Bottun Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDefault.Clear();
            txtDetail.Clear();
        }

        /// <summary>
        /// screensaver tail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ssTimer_Tick(object sender, EventArgs e)
        {
            Process[] processList = Process.GetProcesses();
            ssFlg = false;

            foreach (var a in processList)
            {
                if (a.ProcessName == screensaver) ssFlg = true;
            }

            if (!ssFlg)
            {
                if (tipStack.Count != 0) DisplayStackBalloon(tipStack);
            }
        }

        /// <summary>
        /// screenlock tail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            { 
                //I left my desk
                ssTimer.Stop();
                ssFlg = true;
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            { 
                //I returned to my desk
                ssTimer.Start();
                ssFlg = false;
                if(tipStack.Count != 0) DisplayStackBalloon(tipStack);
            }
        }

        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Suspend:
                    // スリープ直前
                    PcapClose();
                    break;
                case PowerModes.Resume:
                    PcapOpen();
                    // 復帰直後
                    break;
                case PowerModes.StatusChange:
                    // バッテリーや電源に関する通知があった
                    break;
            }
        }

        /// <summary>
        /// stack balloon display
        /// </summary>
        /// <param name="tS"></param>
        void DisplayStackBalloon( List<string> tS )
        {
            string tipText = "";

            foreach(string x in tS)
            {
                tipText += x + "\n";
            }
            tipText += "⊂二二二( ^ω^)二⊃";
            notifyIcon1.BalloonTipTitle = "離席中にきてたやつ";
            notifyIcon1.BalloonTipText = tipText;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon1.ShowBalloonTip(300000);

            tipStack.Clear();
        }

        /// <summary>
        /// pcap close
        /// </summary>
        private void PcapClose()
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;

            //await Task.Run(async () => {
            //    await Task.Delay(500);
            //            device.StopCapture();
            //            device.Close();
            //});

            //await Task.Delay(500);
            // キャプチャ停止
            System.Threading.Thread.Sleep(200);
            device.StopCapture();
            device.Close();
        }

        private void PcapOpen()
        {
            networkIndex = appSettings.netWork;

            device = LivePcapDeviceList.Instance[appSettings.netWork];
            // ハンドラ設定
            device.OnPacketArrival += OnPacketArrival;
            // デバイスオープン
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // キャプチャ開始
            device.StartCapture();
        }
    }
}

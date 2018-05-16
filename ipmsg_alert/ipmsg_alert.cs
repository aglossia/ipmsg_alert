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
        Dictionary<int, string> localIPDic = new Dictionary<int, string>();

        static func fc = new func();
        string screensaver = fc.GetScreenSaverName();
        int myIP;

        LivePcapDevice device = LivePcapDeviceList.Instance[0];
        static char[] separator = {':'};
        static char[] separatorName = {'\0'};
        string sep_str = new String(separator);
        bool ssFlg = false;
        List<string> tipStack = new List<string>();

        public class setting
        {
            //bool _sendFlg;
            //bool _receiveFlg;
            //bool _openFlg;
            //bool _leaveFlg;
            //bool _defaultFlg;
            //bool _detailFlg;
            //bool _mykFlg;

            public bool sendFlg { get; set; }
            public bool receiveFlg { get; set; }
            public bool openFlg { get; set; }
            public bool leaveFlg { get; set; }
            public bool defaultFlg { get; set; }
            public bool detailFlg { get; set; }
            public bool mykFlg { get; set; }
            public string ipAddr { get; set; }

            public setting()
            {
                sendFlg = false;
                receiveFlg = true;
                openFlg = true;
                leaveFlg = false;
                defaultFlg = true;
                detailFlg = false;
                mykFlg = false;
                ipAddr = "255.255.255.255";
            }
        }

        //public bool sendFlg 
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.send];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.send] = value;
        //    }
        //}
        //public bool receiveFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.receive];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.receive] = value;
        //    }
        //}
        //public bool openFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.open];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.open] = value;
        //    }
        //}

        //public bool leaveFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.leave];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.leave] = value;
        //    }
        //}

        //public bool defaultFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle._default];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle._default] = value;
        //    }
        //}

        //public bool detailFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.detail];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.detail] = value;
        //    }
        //}

        //public bool mykFlg
        //{
        //    get
        //    {
        //        return watchFlgDic[(int)watchEle.myk];
        //    }
        //    set
        //    {
        //        watchFlgDic[(int)watchEle.myk] = value;
        //    }
        //}

        setting appSettings = new setting();

        public ipmsg_alert()
        {
            InitializeComponent();

#if DEBUG
            this.Text = "[DEBUG]";
#endif
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);

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
            }

            ssTimer.Enabled = true;
            ssTimer.Interval = 1000;

            picBoxMayuko.ImageLocation = @"myk.bmp";

            myIP = fc.GetIPAddr(appSettings.ipAddr)[3];

            this.ActiveControl = this.btnExit;


            // ハンドラ設定
            device.OnPacketArrival += OnPacketArrival;

            // デバイスオープン
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // キャプチャ開始
            device.StartCapture();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //watchFlgDic[(int)watchEle.send] = false;
            //watchFlgDic[(int)watchEle.receive] = true;
            //watchFlgDic[(int)watchEle.open] = true;
            //watchFlgDic[(int)watchEle.leave] = false;
            //watchFlgDic[(int)watchEle._default] = true;
            //watchFlgDic[(int)watchEle.detail] = false;
            //watchFlgDic[(int)watchEle.myk] = false;

            txtDefault.Visible = appSettings.defaultFlg;
            txtDetail.Visible = appSettings.detailFlg;
            picBoxMayuko.Visible = appSettings.mykFlg;

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


        private void ipmsg_alert_Load(object sender, EventArgs e)
        {
            label1.Text = "watching...";
        }
        
        private void btnWatchOn_Click(object sender, EventArgs e)
        {
            if (!device.Opened)
            {
                // ハンドラ設定
                device.OnPacketArrival += OnPacketArrival;

                // デバイスオープン
                int readTimeoutMilliseconds = 1000;
                device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
                // キャプチャ開始
                device.StartCapture();

                label1.Text = "watching...";
            }
        }

        async private void btnWatchOff_Click(object sender, EventArgs e)
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;
            await Task.Delay(500);
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            label1.Text = "stop";

            txtDefault.Clear();
            txtDetail.Clear();
            localIPDic.Clear();
        }

        async private void btnExit_Click(object sender, EventArgs e)
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;
            await Task.Delay(500);
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        // イベントハンドラ
        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // 0:ver(1fix), 1:Packet number, 2:username, 3, hostname, 4:command, 5:addition
            string[] splitted;
            string[] splittedName;
            
            if(e.Packet.Data[34] == 9 && e.Packet.Data[35] == 121 && e.Packet.Data[36] == 9 && e.Packet.Data[37] == 121)
            {
                //Invoke(new Action<bool>((b) => btnExit.Enabled = b),false);
                // 必要な変数を宣言する
                DateTime dtNow = DateTime.Now;

                int srcIP = e.Packet.Data[29];
                int dstIP = e.Packet.Data[33];

                int noticeNameIP = 54;

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
                        if (e.Packet.Data[29] == myIP)
                        {
                            notice = string.Format("[{0}] 送信したよ", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                            if(localIPDic.ContainsKey(dstIP)) sendName = localIPDic[dstIP];
                            responseMessage = sendName + " に送るで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            if(appSettings.sendFlg) flg = true;
                        }

                        break;

                    case 0x30:
                        if (e.Packet.Data[29] != myIP)
                        {
                            notice = string.Format("[{0}] 開封したよ", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                            responseMessage = "開けたで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            if(appSettings.openFlg) flg = true;
                        }

                        break;

                    case 0x21:
                        if (e.Packet.Data[29] == myIP)
                        {
                            notice = string.Format("[{0}] 受信したよ", dtNow.ToLongTimeString());
                            noticeNameIP = dstIP;
                            responseMessage = "から受け取ったで";
                            nameMessage = localIPDic.ContainsKey(noticeNameIP) ? localIPDic[noticeNameIP] : "誰？";
                            if(appSettings.receiveFlg) flg = true;
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
                            
                            if(appSettings.leaveFlg) flg = true;

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

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm.showSettingForm( ref appSettings );

            txtDefault.Visible = appSettings.defaultFlg;
            txtDetail.Visible = appSettings.detailFlg;
            picBoxMayuko.Visible = appSettings.mykFlg;

            //picBoxMayuko.ImageLocation = mykFlg ? @"myk.bmp" : null;
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionForm.showVersionForm();

            foreach (var i in localIPDic)
            {
                Console.WriteLine(i.Value);
            }
            Console.WriteLine(localIPDic.Count);
        }

        async private void ipmsg_alert_FormClosed(object sender, FormClosedEventArgs e)
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;
            await Task.Delay(500);
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        async private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;
            await Task.Delay(500);
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusForm.showStatusForm(localIPDic);
        }

        async private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // キャプチャ停止中にキャプチャが走るのを防ぐため
            device.OnPacketArrival -= OnPacketArrival;
            await Task.Delay(500);
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDefault.Clear();
            txtDetail.Clear();
        }

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
    }
}

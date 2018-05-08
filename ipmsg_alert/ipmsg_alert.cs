﻿using System;
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

namespace ipmsg_alert
{
    public partial class ipmsg_alert : Form
    {
        Dictionary<int, string> localNameDic = new Dictionary<int, string>()
        {
            {53,"中村智行"},
            {54,"橋野公洋"},
            {100,"村上翔"},
            {101,"二村誠"},
            {102,"下野達也"},
            {103,"小川博文"},
            {104,"亀田甚八"},
            {105,"増見浩平"},
            {106,"神重憲夫"},
            {107,"廣田尚己"},
            {109,"吉田真介"},
            {110,"鍵原教克"},
            {112,"水本健一"},
            {113,"耕野正昭"},
            {114,"須賀和美"},
            {115,"丸山龍一"},
            {116,"久保田雄亮"},
            {117,"河本浩宜"},
            {118,"松井達郎"},
            {119,"雪丸僚"},
            {120,"小松立典"},
            {121,"森野大亮"},
            {123,"高山裕延"},
            {126,"赤木真"},
            {127,"北本敦"},
            {129,"ULLA(PC167)"},
        };

        int myIP = 54;

        LivePcapDevice device = LivePcapDeviceList.Instance[0];
        static char[] separator = {':'};
        string sep_str = new String(separator);

        public bool sendFlg 
        {
            get
            {
                return watchFlgDic[(int)watchEle.send];
            }
            set
            {
                watchFlgDic[(int)watchEle.send] = value;
            }
        }
        public bool receiveFlg
        {
            get
            {
                return watchFlgDic[(int)watchEle.receive];
            }
            set
            {
                watchFlgDic[(int)watchEle.receive] = value;
            }
        }
        public bool openFlg
        {
            get
            {
                return watchFlgDic[(int)watchEle.open];
            }
            set
            {
                watchFlgDic[(int)watchEle.open] = value;
            }
        }

        public bool mykFlg
        {
            get
            {
                return watchFlgDic[(int)watchEle.myk];
            }
            set
            {
                watchFlgDic[(int)watchEle.myk] = value;
            }
        }

        enum watchEle : int
        {
            send,
            receive,
            open,
            myk
        }

        Dictionary<int, bool> watchFlgDic = new Dictionary<int, bool>();

        public string SetMayuko
        {
            set
            {
                //picBoxMayuko.ImageLocation = value;
                label1.Text = value;
            }
        }

        public static ipmsg_alert IpInstance { get;set;}

        public ipmsg_alert()
        {
            InitializeComponent();

#if DEBUG
            this.Text = "[DEBUG]";
#endif

            // ハンドラ設定
            device.OnPacketArrival += OnPacketArrival;

            // デバイスオープン
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // キャプチャ開始
            device.StartCapture();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            watchFlgDic[(int)watchEle.send] = false;
            watchFlgDic[(int)watchEle.receive] = true;
            watchFlgDic[(int)watchEle.open] = true;
            watchFlgDic[(int)watchEle.myk] = false;
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
            // トレイリストのアイコンを非表示にする
            notifyIcon1.Visible = false; 
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

        private void btnWatchOff_Click(object sender, EventArgs e)
        {
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            label1.Text = "stop";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        // イベントハンドラ
        private  void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // 0:ver(1fix), 1:Packet number, 2:username, 3, hostname, 4:command, 5:addition
            string[] splitted;

            if(e.Packet.Data[34] == 9 && e.Packet.Data[35] == 121 && e.Packet.Data[36] == 9 && e.Packet.Data[37] == 121)
            {

                // 必要な変数を宣言する
                DateTime dtNow = DateTime.Now;

                int srcIP = e.Packet.Data[29];
                int dstIP = e.Packet.Data[33];

                int noticeNameIP = 54;

                var segment = new ArraySegment<byte>(e.Packet.Data,42,e.Packet.Data.Length - 42);

                var charbyte = new string(segment.Select(x => (char)x).ToArray());

                splitted = charbyte.Split(separator);

                Console.WriteLine(int.Parse(splitted[4]));

                int command = int.Parse(splitted[4]);

                string notice = "";
                bool flg = true;

                switch(command & 0xff)
                {
                    case 0x20:
                        if (e.Packet.Data[29] == myIP && sendFlg == true)
                        {
                            notice = string.Format("送信したよ\n[{0}]", dtNow.ToLongTimeString());

                            noticeNameIP = srcIP;
                        }
                        else
                        {
                            flg = false;
                        }

                        break;

                    case 0x30:
                        if (e.Packet.Data[29] != myIP && openFlg == true)
                        {
                            notice = string.Format("開封したよ [{0}]", dtNow.ToLongTimeString());
                            noticeNameIP = srcIP;
                        }
                        else
                        {
                            flg = false;
                        }

                        break;

                    case 0x21:
                        if (e.Packet.Data[29] == myIP && receiveFlg == true)
                        {
                            notice = string.Format("受信したよ [{0}]", dtNow.ToLongTimeString());
                            noticeNameIP = dstIP;
                        }
                        else
                        {
                            flg = false;
                        }

                        break;
                    default:
                        flg = false;
                        break;
                }

                if (flg)
                {
                    //バルーンヒントのタイトル
                    notifyIcon1.BalloonTipTitle = notice;
                    //バルーンヒントに表示するメッセージ

                    notifyIcon1.BalloonTipText = localNameDic.ContainsKey(noticeNameIP) ? localNameDic[noticeNameIP] : "誰？";
                    
                    //バルーンヒントに表示するアイコン
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
                    //バルーンヒントを表示する
                    //表示する時間をミリ秒で指定する
                    notifyIcon1.ShowBalloonTip(30000);
                }
                                
                //Invoke(new Action<string>((msg) => textBox1.AppendText( msg + Environment.NewLine )),splitted[2]);

            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            watchFlgDic = SettingForm.showSettingForm( watchFlgDic );

            picBoxMayuko.ImageLocation = mykFlg ? @"myk.bmp" : null;
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionForm.showVersionForm();
        }

        private void ipmsg_alert_FormClosed(object sender, FormClosedEventArgs e)
        {
            // キャプチャ停止
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            device.StopCapture();
            device.Close();
            
            Application.Exit();
        }
    }
}

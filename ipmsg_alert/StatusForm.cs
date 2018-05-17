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
    public partial class StatusForm : Form
    {
        func fc = new func();

        public StatusForm(Dictionary<string, string> IPDic)
        {
            InitializeComponent();

            labelIPCount.Text += IPDic.Count.ToString();

            foreach (var i in IPDic)
            {
                // ホスト部が1オクテットのためそこだけ表示
                txtIPView.AppendText(i.Value + ":" + fc.GetIPAddr(i.Key)[3] + Environment.NewLine);
            }
        }

        static public void showStatusForm(Dictionary<string, string> IPDic)
        {
            StatusForm fm = new StatusForm(IPDic);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();

            fm.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

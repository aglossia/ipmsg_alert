using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipmsg_alert
{
    public partial class StatusForm : Form
    {
        public StatusForm(Dictionary<int, string> IPDic)
        {
            InitializeComponent();

            labelIPCount.Text += IPDic.Count.ToString();

            foreach (var i in IPDic)
            {
                txtIPView.AppendText(i.Value + ":" + i.Key + Environment.NewLine);
            }
        }

        static public void showStatusForm(Dictionary<int, string> IPDic)
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

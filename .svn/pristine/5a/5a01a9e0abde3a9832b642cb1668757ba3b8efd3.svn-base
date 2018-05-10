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
    public partial class SettingForm : Form
    {
        static SettingForm fm;
        public Dictionary<int, bool> returnDic = new Dictionary<int, bool>();

        public SettingForm( Dictionary<int, bool> watchFlgDic )
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            chboxSend.Checked = watchFlgDic[0];

            chboxReceive.Checked = watchFlgDic[1];

            chboxOpen.Checked = watchFlgDic[2];

            chboxMayuko.Checked = watchFlgDic[3];

            returnDic = watchFlgDic;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            returnDic[0] = chboxSend.Checked;
            returnDic[1] = chboxReceive.Checked;
            returnDic[2] = chboxOpen.Checked;
            returnDic[3] = chboxMayuko.Checked;

            this.Close();
        }

        static public Dictionary<int, bool> showSettingForm( Dictionary<int, bool> inDic)
        {
            fm = new SettingForm( inDic );
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
            var insDic = fm.returnDic;
            fm.Dispose();

            return insDic;
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}

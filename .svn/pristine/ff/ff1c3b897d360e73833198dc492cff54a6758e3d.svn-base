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

        enum watchEle : int
        {
            send,
            receive,
            open,
            leave,
            _default,
            detail,
            myk
        }

        public SettingForm( Dictionary<int, bool> watchFlgDic )
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            chboxSend.Checked = watchFlgDic[(int)watchEle.send];

            chboxReceive.Checked = watchFlgDic[(int)watchEle.receive];

            chboxOpen.Checked = watchFlgDic[(int)watchEle.open];

            chboxLeave.Checked = watchFlgDic[(int)watchEle.leave];

            radioDefault.Checked = watchFlgDic[(int)watchEle._default];

            radioDetail.Checked = watchFlgDic[(int)watchEle.detail];

            radioMayuko.Checked = watchFlgDic[(int)watchEle.myk];

            returnDic = watchFlgDic;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            returnDic[(int)watchEle.send] = chboxSend.Checked;
            returnDic[(int)watchEle.receive] = chboxReceive.Checked;
            returnDic[(int)watchEle.open] = chboxOpen.Checked;
            returnDic[(int)watchEle.leave] = chboxLeave.Checked;
            returnDic[(int)watchEle._default] = radioDefault.Checked;
            returnDic[(int)watchEle.detail] = radioDetail.Checked;
            returnDic[(int)watchEle.myk] = radioMayuko.Checked;

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

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
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Text = "";

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            System.Reflection.Assembly     assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName asmName  = assembly.GetName();
            System.Version                 version  = asmName.Version;
 
            labelVer.Text = "Ver " + version.Major + "." + version.MinorRevision;
        }

        static public void showVersionForm()
        {
            VersionForm fm = new VersionForm();
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

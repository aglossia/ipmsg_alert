using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace ipmsg_alert.setting
{
    class func
    {
        public string GetScreenSaverName()
        {
            string ret = "";

            //キーを読み取り専用で開く
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", false);
            //キーが存在しないときは null が返される
            if (regkey == null) return "error";

            string ssFilePath = (string)regkey.GetValue("SCRNSAVE.EXE");

            string tmp = Path.GetExtension(ssFilePath);

            if(Path.GetExtension(ssFilePath) == ".exe")
            {
                ret = Path.GetFileNameWithoutExtension(ssFilePath);
            }else
            {
                ret = Path.GetFileName(ssFilePath);
            }
            return ret;
        }

        public int[] GetIPAddr(string IPAddrStr)
        {
            char[] separator = {'.'};
            string sep_str = new String(separator);

            string[] splitted = IPAddrStr.Split(separator);

            int[] IPAddr = splitted.Select(int.Parse).ToArray();

            return IPAddr;
        }
    }

    class Constants
    {
        public static string configFileName = "ipma.config";
    }
}

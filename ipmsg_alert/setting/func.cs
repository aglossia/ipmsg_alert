using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

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

        public bool CheckIpString(string str) {

            if (string.IsNullOrEmpty(str)) {
                throw new ArgumentException("str is null or empty.");
            }

            if (str.Length < 7 || str.Length > 15) {
                throw new FormatException("str is illegal fortmat (" + str + ")"); 
            }

            Match m = Regex.Match(str, @"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");
            if (m.Success) {
                for(int i = 1; i < 5; i++) {
                    if (!isInByteRange(m.Groups[i].Value)) {
                        throw new FormatException("str is illegal fortmat (" + str + ")"); 
                    }
                }
            }
            else
            {
                throw new FormatException("str is illegal fortmat (" + str + ")"); 

            }
            return true;
        }

        // 0 ～ 255 の範囲内かどうかチェックする
        private static bool isInByteRange(string block) {
            byte result;
            return byte.TryParse(block, out result);
        }
    }

    class Constants
    {
        public static string configFileName = "ipma.config";
    }
}

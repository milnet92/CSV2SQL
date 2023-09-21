using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Security
{
    public static class SecurityHelper
    {
        public static string SecureStringToString(SecureString secureString)
        {
            return new System.Net.NetworkCredential(string.Empty, secureString).Password;
        }

        public static SecureString StringToSecureString(string str)
        {
            unsafe
            {
                fixed(char* s = str)
                {
                    return new SecureString(s, str.Length);
                }
            }
        }
    }
}

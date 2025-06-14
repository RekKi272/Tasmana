using Meziantou.Framework.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class CredentialHandler
    {
        public static List<Credential> LoadCredential()
        {
            return CredentialManager.EnumerateCredentials().Where(x => x.ApplicationName.StartsWith("TasmanaAccount")).ToList();
        }
        public static void SaveCredential(string username, string password, bool saved)
        {
            if (saved)
            {
                CredentialManager.WriteCredential(
                applicationName: "TasmanaAccount_" + username,
                userName: username,
                secret: password,
                comment: "",
                persistence: CredentialPersistence.LocalMachine);
            }
            else
            {
                try
                {
                    CredentialManager.DeleteCredential("TasmanaAccount_" + username);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}

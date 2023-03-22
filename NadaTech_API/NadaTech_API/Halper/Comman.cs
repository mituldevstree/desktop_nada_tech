using NadaTech_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace NadaTech_API
{
    public class Common
    {
        //AssetStatus,TransactionType
        public enum AssetStatus 
        {
            InStock = 1,
            Checkout = 2
        }
        public enum ScanType    
        {
            Desktop = 1,
            Mobile = 2
        }

        public static string EncryptNumber(String Key, String Str)
        {
            Key = "ryh45aagite5895erktlwe";
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(Str);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptNumber(String Key, String Str)
        {
            Key = "ryh45aagite5895erktlwe";
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(Str);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static string GetString(Exception ex)
        {

            //ErrorSignal.FromCurrentContext().Raise(ex);

            if (ex.InnerException != null)
                if (ex.InnerException.InnerException != null)
                    return Regex.Replace(ex.InnerException.InnerException.Message.Replace("'", "").Replace(@"""", ""), @"\t|\n|\r", "").Trim().Replace(Environment.NewLine, " ");
                else
                    return Regex.Replace(ex.InnerException.Message.Replace("'", "").Replace(@"""", ""), @"\t|\n|\r", "").Trim().Replace(Environment.NewLine, " ");
            else
                return Regex.Replace(ex.Message.Replace("'", "").Replace(@"""", "").Replace("\r\n", ""), @"\t|\n|\r", "").Trim().Replace(Environment.NewLine, " ");
        }
        public static void TraceService(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(content);
            sw.Close();
        }
        public static DateTime DateTimeConvert(string Date)
        {
            var temp = Date.Split("/".ToCharArray());

            int Day = Convert.ToInt32(temp[0]);
            int Month = Convert.ToInt32(temp[1]);
            int Year = Convert.ToInt32(temp[2]);

            return new DateTime(Year, Month, Day);
        }
        internal static string CheckTokenAndVersion(HttpRequest _HttpRequest)
        {
            try
            {
                using (NadaTechEntities ctx = new NadaTechEntities())
                {
                    if (_HttpRequest == null)
                    {
                        return "Token is Invalid";
                    }
                    var data = System.Web.HttpContext.Current.Request;
                    var headers = data.Headers;
                    if (headers.AllKeys.Contains("userid"))
                    {
                        string UserId = data.Headers.GetValues("userid").First();
                        int UID = Convert.ToInt32(UserId);
                        if (ctx.AUTTokens.Any(x => x.UserId == UID))
                        {
                            if (headers.AllKeys.Contains("authtoken"))
                            {
                                string token = data.Headers.GetValues("authtoken").First();
                                if (token == ctx.AUTTokens.FirstOrDefault(x => x.UserId == UID).Token)
                                {
                                    return "";
                                }
                                else
                                {
                                    return "Token is Invalid";
                                }

                            }
                            else
                            {
                                return "Token is Invalid";
                            }
                        }
                        else
                        {
                            return "Token not generated";
                        }
                    }
                    else
                    {
                        return "UserId not Found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string ConvertASCIItoHex(string Value)
        {
            StringBuilder sb = new StringBuilder();

            byte[] inputByte = Encoding.UTF8.GetBytes(Value);

            foreach (byte b in inputByte)
            {
                sb.Append(string.Format("{0:x2}", b));
            }
            return sb.ToString().ToUpper();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NadaTech_EncodingStation
{
    public class Common
    {
        public enum AssetStatus
        {
            InStock = 1,
            Checkout = 2
        }
        public enum TransactionStatus
        {
            Approve = 'A',
            Reject = 'R'
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

        public static string ConvertHextoASCII(string hexString)
        {
            string ascii = string.Empty;
            try
            {
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    ulong decval = Convert.ToUInt64(hs, 16);
                    long deccc = Convert.ToInt64(hs, 16);
                    char character = Convert.ToChar(deccc);
                    ascii += character;
                }
            }
            catch (Exception ex)
            {

            }
            return ascii;
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

    public class TypeModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}

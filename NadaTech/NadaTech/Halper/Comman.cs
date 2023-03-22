using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NadaTech
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
		public static Dictionary<string, string> ParseNetConfig(
	  byte[] net_config,
	  int net_config_len)
		{
			Dictionary<string, string> netConfig = new Dictionary<string, string>();
			string str1 = Encoding.Default.GetString(net_config, 0, net_config_len);
			char[] chArray1 = new char[1] { ';' };
			foreach (string str2 in str1.Split(chArray1))
			{
				char[] chArray2 = new char[1] { '=' };
				string[] strArray = str2.Split(chArray2);
				if (strArray.Length == 2)
					netConfig.Add(strArray[0], strArray[1]);
				else
					break;
			}
			return netConfig;
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

        public static bool TestConnectionString()
        {
            NadaTechEntities _Entities = new NadaTechEntities();
            string connectionString = _Entities.Database.Connection.ConnectionString;
            connectionString = connectionString.Replace("Connect Timeout=300", "Connect Timeout=5");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return (conn.State == ConnectionState.Open);
                }
                catch
                {
                    return false;
                }
            }
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

        #region CiRFID

        public static void HexStringToBytesWithSpace(byte[] data, int offset, String hexString, int max)
        {
            String _hexString = hexString.Replace(" ", "");
            while (_hexString.Length < max * 2)
            {
                _hexString += "0";
            }
            for (int i = 0; i < max; i++)
            {
                data[offset + i] = Convert.ToByte(_hexString.Substring(i * 2, 2), 16);
            }
        }

        public static void HexStringToBytes(byte[] data, int offset, String hexString, int max)
        {
            while (hexString.Length < max * 2)
            {
                hexString += "0";
            }
            for (int i = 0; i < max; i++)
            {
                data[offset + i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
        }

        public static string BytesToHexString(byte[] ba, int offset, int length)
        {
            if (ba == null)
            {
                return "";
            }

            StringBuilder hex = new StringBuilder(length * 2);
            for (int index = 0; index < length; ++index)
            {
                hex.AppendFormat("{0:X2}", ba[offset + index]);
            }
            return hex.ToString();
        }

        public static String FormatIP(byte[] data)
        {
            return String.Format("{0:d}.{1:d}.{2:d}.{3:d}", data[0], data[1], data[2], data[3]);
        }

        public static byte[] GetIPBytes(String ip)
        {
            byte[] bs = null;
            String[] items = ip.Split('.');
            if (items.Length == 4)
            {
                bs = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    bs[i] = Convert.ToByte(items[i]);
                }
            }
            return bs;
        }

        public static short BytesToShort(byte[] data, int offset)
        {
            return (short)(data[offset] + data[offset + 1] * 256);
        }

        public static long BytesToLong(byte[] data, int offset)
        {
            return (long)(data[offset] + data[offset + 1] * 256 + data[offset + 2] * 256 * 256 + data[offset + 3] * 256 * 256 * 256);
        }

        public static uint U32FromLittleEndianU8s(byte[] data, int offset)
        {
            return (uint)(data[offset] | (data[offset + 1] << 8) | (data[offset + 2] << 16) | (data[offset + 3] << 24));
        }

        public static void U32ToLittleEndianU8s(uint value, byte[] data, int offset)
        {
            data[offset] = (byte)value;
            data[offset + 1] = (byte)(value >> 8);
            data[offset + 2] = (byte)(value >> 16);
            data[offset + 3] = (byte)(value >> 24);
        }

        public static ushort U16FromLittleEndianU8s(byte[] data, int offset)
        {
            return (ushort)(data[offset] | (data[offset + 1] << 8));
        }

        public static void U16ToLittleEndianU8s(ushort value, byte[] data, int offset)
        {
            data[offset] = (byte)value;
            data[offset + 1] = (byte)(value >> 8);
        }

        public static byte[] LongToBytes(long l)
        {
            byte[] bs = new byte[4];
            bs[0] = (byte)l;
            bs[1] = (byte)(l / 256);
            bs[2] = (byte)(l / 256 / 256);
            bs[3] = (byte)(l / 256 / 256 / 256);
            return bs;
        }

        public static byte[] ShortToBytes(short s)
        {
            byte[] bs = new byte[2];
            bs[0] = (byte)s;
            bs[1] = (byte)(s / 256);
            return bs;
        }

        public static byte[] ShortToBytes1(short s)
        {
            byte[] bs = new byte[2];
            bs[1] = (byte)s;
            bs[0] = (byte)(s / 256);
            return bs;
        }

        public static UInt32 ReverseUInt32Bytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        #region Func:cal_crc
        public static uint CAL_CRC(byte[] data, int size)
        {
            int i;
            int j = 0;
            uint crc = 0xffff;
            while (size-- != 0)
            {
                for (i = 0x80; i != 0; i /= 2)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc *= 2;
                        crc ^= 0x1021;
                    }
                    else
                    {
                        crc *= 2;
                    }
                    if ((data[j] & i) != 0)
                    {
                        crc ^= 0x1021;
                    }
                }
                j++;
            }
            return crc;
        }
        #endregion

        public static bool IsIP(string ip)
        {
            //如果为空，认为验证合格
            if (null == ip)
            {
                return false;
            }

            //清除要验证字符串中的空格
            ip = ip.Trim();
            if (ip.Length == 0)
            {
                return false;
            }

            try
            {
                IPAddress.Parse(ip);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion

    }

    public class ReportData
    {
        public uint reader_id;
        public uint cmd_code;
        public byte[] data;

        public ReportData(uint reader_id, uint cmd_code, byte[] data)
        {
            this.reader_id = reader_id;
            this.cmd_code = cmd_code;
            this.data = data;
        }

    };
}

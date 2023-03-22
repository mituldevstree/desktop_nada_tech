using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ReaderDemo
{
    public class Common
    {
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
    }
}

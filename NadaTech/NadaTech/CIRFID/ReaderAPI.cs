using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ReaderDemo
{
    class ReaderAPI
    {
        public enum CmdCode
        {
            // 设置网络心跳包上传时间间隔 -- passed
            CmdSetTcpHeartbeatInterval = 0x10, // 设置网络心跳包上传时间间隔 -- passed
            CmdGetInventoryStatistics = 0x20, // 获取盘寻统计信息 -- passed
            CmdBlockWrite = 0x21, // 块写标签信息 -- passed
            CmdBlockErase = 0x22, // 块擦除标签信息 -- passed
            CmdInventoryOnce = 0x25, // 所有使能天线进行一个周期寻卡 -- passed
            CmdReadTag = 0x26, // 读标签 -- passed
            CmdWriteTag = 0x27, // 写标签 -- passed
            CmdReaderOpStateReport = 0x28, // 读写器操作状态上报 -- passed
            CmdGetAntEchoDetectingParams = 0x29, // 获取读写器天线回波检测参数 -- passed
            CmdStartInventory = 0x2A, // 开始连续盘寻 -- passed
            CmdStopInventory = 0x2B, // 停止连续盘寻 -- passed
            CmdLockTag = 0x2C, // 锁标签 -- 锁定后密码不对还可以写
            CmdKillTag = 0x2D, // 销毁标签 -- passed
            CmdStartAutoRead = 0x2E, // 开始自动读卡 -- passed
            CmdStopAutoRead = 0x2F, // 停止自动读卡 -- passed
            CmdGetVersion = 0x31, // 获取设备版本号 -- passed
            CmdGetAntConfig = 0x32, // 获取天线配置参数 -- passed
            CmdSetAntConfig = 0x33, // 设置天线配置参数 -- passed
            CmdGetGpioTriggerStatus = 0x38, // 获取输入GPIO触发状态 -- passed
            CmdSetRelayStatus = 0x39, // 控制继电器状态 -- passed
            CmdSetQValue = 0x41, // 设置Q值 -- passed
            CmdGetQValue = 0x42, // 获取Q值 -- passed
            CmdSetQueryConfig = 0x43, // 设置读写器Query参数 -- passed
            CmdGetQueryConfig = 0x44, // 获取读写器Query参数 -- passed
            CmdSetInventoryConfig = 0x47, // 设置读写器盘点参数 -- passed
            CmdGetInventoryConfig = 0x48, // 获取读写器盘点参数 -- passed
            CmdSetTxOnOffTime = 0x49, // 设置读写器TX的开关时间 -- passed
            CmdGetTxOnOffTime = 0x4A, // 获取读写器TX的开关时间 -- passed
            CmdSetAdjustCwConfig = 0x4B, // 设置Adjust Carrier参数 -- passed
            CmdGetAdjustCwConfig = 0x4C, // 获取Adjust Carrier参数 -- passed
            CmdGetReaderState = 0xF0, // 获取读写器的状态 -- passed
            CmdReadMacRegister = 0xF2, // 读取MAC寄存器的值 -- passed
            CmdWriteMacRegister = 0xF3, // 设置MAC寄存器的值 -- passed
            CmdReadOemRegister = 0xF4, // 读取OEM寄存器的值 -- passed
            CmdWriteOemRegister = 0xF5, // 设置OEM寄存器的值 -- passed
            CmdSetLinkProfile = 0xF6, // 设置读写器的Link Profile -- passed
            CmdGetLinkProfile = 0xF7, // 获取读写器的Link Profile -- passed
            CmdResetUHF = 0xFA, // 软复位超高频模块 -- passed
            CmdResetReader = 0xFB, // 复位读写器 -- passed
            CmdSwitchCarrierWaveTransmit = 0x50, // 开关CW -- passed
            CmdSwitchHoppingChannel = 0x51, // Hopping 开关 -- passed
            CmdSetTestFrequency = 0x52, // 设置单个频点 -- passed
            CmdSetTestAntPower = 0x53, // 设置测试天线功率 -- passed
            CmdSelectTag = 0x60, // 标签选择 -- failed
            CmdCancelSelectTag = 0x61, // 取消标签选择 --
            CmdStartMultiBankAutoRead = 0x63, // 开始选择多区域自动读卡 -- passed
            CmdStopMultiBankAutoRead = 0x64, // 停止选择多区域自动读卡 -- passed
            CmdGetDeviceName = 0x65, // 获取设备名称 -- passed
            CmdSetDeviceName = 0x66, // 设置设备名称 -- passed
            CmdDeviceInfoReport = 0x67, // 上报设备参数信息(此功能只有当设备工作在TCP Client模式有效，设备连接到服务器时，主动上报设备相关信息) -- 抓包验证过
            CmdSetWorkMode = 0x70, // 设置读写器工作模式 -- passed
            CmdSetCommunicationMode = 0x71, // 设置读写器通讯方式 -- passed
            CmdSetRs485Address = 0x72, // 设置读写器RS485地址 -- passed
            CmdSetTriggerModeDelayStopReadTime = 0x73, // 设置触发模式延迟停止寻卡时间 -- passed
            CmdSetAutoReadParams = 0x74, // 设置读写器自动读卡参数 -- passed
            CmdSetRssiFilter = 0x75, // 设置读写器过滤RSSI值 -- passed
            CmdSetTagFilter = 0x76, // 设置读写器相同标签过滤时间 -- passed
            CmdSetWifiParams = 0x77, // 设置WIFI参数 -- no hardware
            CmdSetGprsParams = 0x78, // 设置GPRS参数 -- no hardware
            CmdSetBuzzerEnable = 0x79, // 控制蜂鸣器开关 -- no hardware
            CmdSetBaud = 0x7A, // 设置串口波特率 -- passed
            CmdSetWgParams = 0x7B, // 设置读写器韦根参数 -- passed
            CmdGetWorkMode = 0x80, // 获取读写器工作模式 -- passed
            CmdGetCommunicationMode = 0x81, // 获取读写器通讯方式 -- passed
            CmdGetRs485Address = 0x82, // 获取读写器RS485通讯地址 -- passed
            CmdGetTriggerModeDelayStopReadTime = 0x83, // 获取读写器触发结束延迟停止读卡时间 -- passed
            CmdGetAutoReadParams = 0x84, // 获取读写器自动读卡参数 -- passed
            CmdGetRssiFilter = 0x85, // 获取读写器过滤RSSI值 -- passed
            CmdGetTagFilter = 0x86, // 获取读写器相同标签过滤时间 -- passed
            CmdGetWifiParams = 0x87, // 获取读写器WIFI参数 -- no hardware
            CmdGetGprsParams = 0x88, // 获取读写器GPRS参数 -- no hardware
            CmdGetBuzzerEnable = 0x89, // 获取蜂鸣器控制状态 -- passed
            CmdGetBaud = 0x8A, // 获取串口通讯波特率 -- passed
            CmdGetWgParams = 0x8B, // 设置读写器韦根参数 -- passed
            CmdGetAllSystemParams = 0x8F, // 获取读写器参数 -- passed
            CmdReaderCommunicationBreak = 0xFF, // 读写器通讯断
        };

        public const UInt32 Err_noError = 0;
        public const UInt32 Err_notOpened = 1;
        public const UInt32 Err_openedFailed = 2;
        public const UInt32 Err_badArg = 3;
        public const UInt32 Err_communicationError = 4;
        public const UInt32 Err_alreadyOpened = 5;
        public const UInt32 Err_timeout = 6;
        public const UInt32 Err_needRetry = 7;
        public const UInt32 Err_request_failed = 8;
        public const UInt32 Err_bad_response = 9;
        public const UInt32 Err_bad_report = 0x0A;
        public const UInt32 Err_wait_no_response = 0x0B;
        public const UInt32 Err_insufficient_input_buffer = 0x0C;

        public const string UHFbaseReader = "uhf_reader_device_api.dll";
        public const string UHFReader = "uhf_reader_api.dll";
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        public delegate void UHFReaderReportCallback(byte reader_id, UInt32 report_cmd_code, IntPtr report_data, UInt32 report_data_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_Connect", CallingConvention = CallingConvention.Cdecl)]

        public static extern UInt32 UHFReader_Connect(ref IntPtr handler, string connect_str, UInt32 connect_str_len, UHFReaderReportCallback callback);

        [DllImport(UHFReader, EntryPoint = "UHFReader_GetFirmwareVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_GetFirmwareVersion(IntPtr handler, byte reader_id, byte[] version, ref UInt32 version_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_ReadOemRegister", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_ReadOemRegister(IntPtr handler, byte reader_id, uint vaddress, ref uint value);

        [DllImport(UHFReader, EntryPoint = "UHFReader_GetAntConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_GetAntConfig(IntPtr handler, byte reader_id, byte[] ant_config, ref UInt32 ant_config_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_SetAntConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_SetAntConfig(IntPtr handler, byte reader_id, byte[] ant_config, UInt32 ant_config_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_Inventory", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_Inventory(IntPtr handler, byte reader_id);

        [DllImport(UHFReader, EntryPoint = "UHFReader_StopInventory", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_StopInventory(IntPtr handler, byte reader_id);

        [DllImport(UHFReader, EntryPoint = "UHFReader_SetAutoReadParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_SetAutoReadParams(IntPtr handler, byte reader_id, byte bank, byte offset, byte length, byte[] password, UInt32 passwordlen);

        [DllImport(UHFReader, EntryPoint = "UHFReader_StartAutoRead", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_StartAutoRead(IntPtr handler, byte reader_id);

        [DllImport(UHFReader, EntryPoint = "UHFReader_StopAutoRead", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_StopAutoRead(IntPtr handler, byte reader_id);

        [DllImport(UHFReader, EntryPoint = "UHFReader_Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_Close(ref IntPtr handler);

        [DllImport(UHFReader, EntryPoint = "UHFReader_GetGprsParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_GetGprsParams(IntPtr handler, byte reader_id, byte index, byte[] pars, ref UInt32 params_len);


        [DllImport(UHFReader, EntryPoint = "UHFReader_SetGprsParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_SetGprsParams(IntPtr handler, byte reader_id, byte index, byte[] pars, UInt32 params_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_Listen", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_Listen(ref IntPtr handler, byte[] ip, UInt32 ipsize, UInt32 port, UHFReaderReportCallback callback);

        [DllImport(UHFReader, EntryPoint = "UHFReader_GetAntEchoDetectingParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_GetAntEchoDetectingParams(IntPtr handler, byte reader_id, byte[] ant_echo_detecting_params, ref UInt32 ant_echo_detecting_params_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_ReadTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_ReadTag(IntPtr handler, byte reader_id, byte bank, ushort offset, byte length, byte[] access_password,
            UInt32 access_password_len, byte[] tag_data, ref UInt32 tag_data_len);

        [DllImport(UHFReader, EntryPoint = "UHFReader_WriteTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 UHFReader_WriteTag(IntPtr handler, byte reader_id, byte bank, ushort offset, byte length, byte[] access_password,
         UInt32 access_password_len, byte[] tag_data, UInt32 tag_data_len);




    }
}

using System;
using System.Runtime.InteropServices;

namespace NadaTech
{
	internal class DeviceFinderApi
	{
		public const uint ErrNoError = 0;
		public const uint ErrNotOpened = 1;
		public const uint ErrOpenedFailed = 2;
		public const uint ErrBadArg = 3;
		public const uint ErrCommunicationError = 4;
		public const uint ErrAlreadyOpened = 5;
		public const uint ErrTimeout = 6;
		public const uint ErrNeedRetry = 7;
		public const uint ErrRequestFailed = 8;
		public const uint ErrBadResponse = 9;
		public const uint ErrBadReport = 10;
		public const uint ErrWaitNoResponse = 11;
		public const uint ErrInsufficientInputBuffer = 12;
		public const string DeviceFinder = "device_finder_api.dll";

		//[DllImport("device_finder_api.dll")]
		[DllImport("device_finder_api.dll", EntryPoint = "DeviceFinder_Open", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint DeviceFinder_Open(
		  ref IntPtr hwd,
		  DeviceFinderApi.DeviceFinder_ReportCallback deviceFinder_ReportCallback);

		//[DllImport("device_finder_api.dll", CallingConvention = CallingConvention.Cdecl)]
		[DllImport("device_finder_api.dll", EntryPoint = "UHFReader_Close", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint UHFReader_Close(ref IntPtr hwd);

		//[DllImport("device_finder_api.dll", CallingConvention = CallingConvention.Cdecl)]
		[DllImport("device_finder_api.dll", EntryPoint = "DeviceFinder_Discovery", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint DeviceFinder_Discovery(IntPtr hwd);

		//[DllImport("device_finder_api.dll", CallingConvention = CallingConvention.Cdecl)]
		[DllImport("device_finder_api.dll", EntryPoint = "DeviceFinder_GetNetConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint DeviceFinder_GetNetConfig(
		  IntPtr hwd,
		  byte[] mac_address,
		  uint mac_address_len,
		  byte[] net_config,
		  ref uint net_config_len);

		//[DllImport("device_finder_api.dll", CallingConvention = CallingConvention.Cdecl)]
		[DllImport("device_finder_api.dll", EntryPoint = "DeviceFinder_SetNetConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint DeviceFinder_SetNetConfig(
		  IntPtr hwd,
		  byte[] mac_address,
		  uint mac_address_len,
		  byte[] net_config,
		  uint net_config_len);

		//[DllImport("device_finder_api.dll", CallingConvention = CallingConvention.Cdecl)]
		[DllImport("device_finder_api.dll", EntryPoint = "DeviceFinder_Restart", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint DeviceFinder_Restart(
		  IntPtr hwd,
		  byte[] mac_address,
		  uint mac_address_len);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DeviceFinder_ReportCallback(IntPtr report_data, uint report_data_len);
	}
}

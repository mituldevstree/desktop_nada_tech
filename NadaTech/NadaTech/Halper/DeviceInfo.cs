
namespace NadaTech
{
  public class DeviceInfo
  {
    public int Index { get; set; }

    public string Mac { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public string IP { get; set; }

    public string Mask { get; set; }

    public string Gateway { get; set; }

    public int DHCP { get; set; }

    public short Port { get; set; }

    public uint Baudrate { get; set; }

    public int Parity { get; set; }

    public int Databit { get; set; }

    public int Stopbit { get; set; }

    public string ServerIP { get; set; } = (string) null;

    public short ServerPort { get; set; } = 0;

    public int NetMode { get; set; } = 0;
    public string NetMode1 { get; set; }
    public string Status { get; set; }
  }
}

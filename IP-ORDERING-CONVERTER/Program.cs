using System.Net;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ToInt("10.250.24.7"));
        Console.WriteLine(ToAddr(134744072));
    }

    static long ToInt(string addr)
    {
        // careful of sign extension: convert to uint first;
        // unsigned NetworkToHostOrder ought to be provided.
        return (long)(uint)IPAddress.NetworkToHostOrder(
             (int)IPAddress.Parse(addr).Address);
    }

    static string ToAddr(long address)
    {
        return IPAddress.Parse(address.ToString()).ToString();
        // This also works:
        // return new IPAddress((uint) IPAddress.HostToNetworkOrder(
        //    (int) address)).ToString();
    }

    public void OrdenarIpsString()
    {
        var unsortedIps =
                    new[]
                    {
                                    "192.168.1.4",
                                    "192.168.1.5",
                                    "132.26.211.21",
                                    "2.200.12.16",
                                    "160.87.56.54",
                                    "2.200.12.17",
                                    "192.168.2.1",
                                    "10.152.16.23",
                                    "69.52.220.44"
                    };

        var sortedIps = unsortedIps
            .Select(Version.Parse)
            .OrderBy(arg => arg)
            .Select(arg => arg.ToString())
            .ToList();

        foreach (var ip in sortedIps)
        {
            Console.WriteLine(ip);
        }

    }
}

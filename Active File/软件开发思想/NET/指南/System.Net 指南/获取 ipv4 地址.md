```cs
using System.Net;

var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
foreach (var ip in ipEntry.AddressList)
{
    if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        Console.WriteLine(ip.ToString());
}
```


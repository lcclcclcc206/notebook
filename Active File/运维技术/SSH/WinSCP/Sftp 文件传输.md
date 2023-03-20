```cs
using WinSCP;

SessionOptions sessionOptions = new SessionOptions
{
    Protocol = Protocol.Sftp,
    HostName = "10.232.39.171",
    UserName = "Administrator",
    Password = "LJTweb@2022",
    SshHostKeyFingerprint = "ssh-ed25519 255 wU5FJ2bb1w4sX/x1k7TX20IUuFe5k3qz3Nz3u1zrn2w"
};

using (Session session = new Session())
{
    // Connect
    session.Open(sessionOptions);

    // Upload files
    TransferOptions transferOptions = new TransferOptions();
    transferOptions.TransferMode = TransferMode.Automatic;

    var t = DateTime.Now;
    string folderName = $"{t.Year}_{t.Month}_{t.Day}_{t.Hour}_{t.Minute}_{t.Second}";

    TransferOperationResult transferResult;
    session.CreateDirectory($"D:/Remote/Download/{folderName}");
    transferResult =
        session.PutFiles(@"D:\Remote\Upload", $"D:/Remote/Download/{folderName}", false, transferOptions);


    // Throw on any error
    transferResult.Check();

    // Print results
    foreach (TransferEventArgs transfer in transferResult.Transfers)
    {
        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
    }

}

Console.ReadKey();
```


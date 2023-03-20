string FILE_NAME = "Test.data";
if (File.Exists(FILE_NAME))
{
    Console.WriteLine($"{FILE_NAME} already exists!");
    return;
}

using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
{
    using (BinaryWriter w = new BinaryWriter(fs))
    {
        for (int i = 0; i < 11; i++)
        {
            w.Write(i);
        }
    }
}

using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
{
    using (BinaryReader r = new BinaryReader(fs))
    {
        for (int i = 0; i < 11; i++)
        {
            Console.WriteLine(r.ReadInt32());
        }
    }
}
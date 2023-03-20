using System.Reflection;
using System.IO;

Assembly assembly = Assembly.GetExecutingAssembly();

Stream? stream = assembly.GetManifestResourceStream("ReadEmbeddedResource.Hello.txt");

if(stream is null)
{
    throw new Exception("The file is not exist!");
}

StreamReader reader = new StreamReader(stream);

string text = reader.ReadToEnd();

Console.WriteLine(text);

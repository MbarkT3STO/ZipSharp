// See https://aka.ms/new-console-template for more information

using ZipSharp.Archivers;

var zipArchiver = new ZipArchiver();

var source = @"C:\Users\MBARKT3STO_m\Desktop\test";
var destination = @"C:\Users\MBARKT3STO_m\Desktop";

zipArchiver.Archive(source, destination);

Console.WriteLine("Finished archiving.");



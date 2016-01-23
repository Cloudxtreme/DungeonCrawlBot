using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Controls;
using Jint;

namespace DungeonCrawlBot.Model
{
    class DeflateDecompressor : IMessageDecompressor
    {
        public byte[] WindowDecompress(byte[] byteArray)
        {
            var compressedStream = new MemoryStream(byteArray);
            using (var inflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            using (var decompressedStream = new MemoryStream())
            {
                inflateStream.CopyTo(decompressedStream);
                byte[] decompressed = decompressedStream.ToArray();
                return decompressed;
            }
        }

        public byte[] Decompress(byte[] byteArray)
        {
            //var pathInflaterSource = Path.Combine(Environment.CurrentDirectory, "JS", "Inflate.js");
            //var inflaterSource = File.ReadAllText(pathInflaterSource);
            //var inflater = new Engine()
            //    .Execute(inflaterSource)
            //    .Execute("var inf = new Inflater();");
            //var decompressed = inflater
            //    .SetValue("data", byteArray)
            //    .Execute("inf.append(data);")
            //    .GetCompletionValue()
            //    .ToObject();
            
            return new byte[3];
        }
    }
}

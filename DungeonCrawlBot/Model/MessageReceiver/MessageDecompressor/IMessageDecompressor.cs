namespace DungeonCrawlBot.Model
{
    public interface IMessageDecompressor
    {
        byte[] Decompress(byte[] byteArray);
    }
}

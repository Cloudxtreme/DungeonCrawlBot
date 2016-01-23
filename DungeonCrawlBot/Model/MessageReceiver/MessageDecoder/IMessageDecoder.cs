namespace DungeonCrawlBot.Model
{
    public interface IMessageDecoder
    {
        string Decode(byte[] byteArray);
    }
}

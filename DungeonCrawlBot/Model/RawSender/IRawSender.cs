namespace DungeonCrawlBot.Model
{
    public interface IRawSender
    {
        void SendRawMessage(byte[] byteArray);
    }
}

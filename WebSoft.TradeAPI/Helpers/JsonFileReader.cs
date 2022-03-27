using System.Text.Json;

namespace WebSoft.TradeAPI.Helpers
{
    public class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}

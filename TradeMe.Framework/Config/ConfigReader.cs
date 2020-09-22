using Newtonsoft.Json;
using System.IO;
using TradeMe.Framework.Helps;

namespace TradeMe.Framework.Config
{
    public class ConfigReader
    {
        public static void InitializeFrameworkSettings()
        {
            {
                var appRoot = PathHelper.ToApplicationPath("Config\\settings.json");
                using (StreamReader stream = new StreamReader(appRoot))
                {
                    var json = stream.ReadToEnd();
                    JsonConvert.DeserializeObject<Settings>(json);
                }
            }
        }
    }
}
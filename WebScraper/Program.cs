using HtmlAgilityPack;

namespace WebScraper
{
    class WebScraper
    {
        static void Main(String[] args)
        {
            //The URL that you want to scrap data
            String url = "https://weather.com/tr-TR/weather/today/l/9cbf96d0ac45000914fd2fa225257a3b6c1ad6e69141be1700d7b7b2efea3800";
            var httpClient = new HttpClient();

            //Request to the website
            var html = httpClient.GetStringAsync(url).Result; 
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Get the location of related weather condition
            var locationInspect = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationInspect.InnerText.Trim();
            Console.WriteLine("Today's date is: " + DateTime.Now);
            Console.WriteLine("\nLocation is: " + location);

            //Getting the weather temperature
            var temperatureInspect = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureInspect.InnerText.Trim(); 
            Console.WriteLine("\nToday's temperature is: " + temperature);

            //Getting the weather condition
            var conditionInspect = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionInspect.InnerText.Trim();
            Console.WriteLine("\nToday's condition is: " + condition);
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.IO;

namespace WikiRestRequest
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting response");
            Console.WriteLine("-----------------");
            WikiTextRequest retrievedJSON = await ProcessWikiSections();
            
            string wikiTable = retrievedJSON.parse.wikitext.content;

            Console.WriteLine("\n** Writing wikiTable to File **\n");

            using(StreamWriter writer = File.CreateText("WikiTemplateSeason.txt"))
            {
                writer.WriteLine(wikiTable);
            }

            Console.WriteLine("\n** File writing completed **\n");

            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("Finished");
        }

        private static async Task<WikiTextRequest> ProcessWikiSections()
        {
            string response = await client.GetStringAsync("https://en.wikipedia.org/w/api.php?action=parse&page=My_Hero_Academia_(season_2)&prop=wikitext&section=1&format=json");

            WikiTextRequest wikiParse = JsonSerializer.Deserialize<WikiTextRequest>(response);

            return wikiParse;
        }
    }
}

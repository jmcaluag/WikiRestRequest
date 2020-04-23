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
            Console.Write("\nEnter API URI: ");
            string wikiApiUri = Console.ReadLine();

            Console.WriteLine("-----------------");
            Console.WriteLine("Starting response");
            Console.WriteLine("-----------------");
            WikiTextRequest retrievedJSON = await ProcessWikiSections(wikiApiUri);
            
            string wikiTemplate = retrievedJSON.parse.wikitext.content;

            Console.WriteLine("\n** Writing wikiTemplate to File **\n");

            using(StreamWriter writer = File.CreateText("WikiTemplateSeason.txt"))
            {
                writer.WriteLine(wikiTemplate);
            }

            Console.WriteLine("\n** File writing completed **\n");

            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("Finished");
            Console.WriteLine("--------");
        }

        private static async Task<WikiTextRequest> ProcessWikiSections(string wikiApiUri)
        {
            string response = await client.GetStringAsync(wikiApiUri); //Wikipedia API to season section

            WikiTextRequest wikiParse = JsonSerializer.Deserialize<WikiTextRequest>(response);

            return wikiParse;
        }
    }
}

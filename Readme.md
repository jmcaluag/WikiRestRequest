# Wiki REST Request
This project is a pratice in RESTful API Requests and part of a larger project and program that utilises the concepts and code in this program.

This is a specific program in which it retrieves episode details of a television show's Season page on Wikipedia.

The *WikiText* class details the structure of the JSON object that is retrieved from Wikipedia's RESTful API request.

The program extracts the value from "content" key (Wikipedia's JSON key is `*`) and writes it to a text file.  Warning: The textfile is named "WikiTemplateSeason.txt" and will always be created.

## Example URI addresses
The format requires a specific section of the Wikipedia page.  Below are a few examples of URIs to try:

`https://en.wikipedia.org/w/api.php?action=parse&page=Castlevania_(TV_series)&prop=wikitext&section=4&format=json`

`https://en.wikipedia.org/w/api.php?action=parse&page=My_Hero_Academia_(season_4)&prop=sections&format=json`
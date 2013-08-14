/*Write a program that parses an URL address given in the format:[protocol]://[server]/[resource]
		and extracts from it the [protocol], [server] and [resource] elements. 
        For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"
 */

using System;
using System.Text;

class ParseURLAdress
{
    static void Main()
    {
        const string URLAdress = "http://telerikacademy.com/Courses/Courses/Details/97";
        string[] urlElements = URLAdress.Split(new string[] { "://", "/" }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("[protocol] = \"{0}\"",urlElements[0]);
        Console.WriteLine("[server] = \"{0}\"", urlElements[1]);
        StringBuilder resource = new StringBuilder();
        resource.Append("[resource] = \"/");
        for (int i = 2; i < urlElements.Length; i++)
        {
            resource.Append(urlElements[i]);
            if (i<urlElements.Length-1)
            {
                resource.Append("/");
            }
        }
        resource.Append("\"");
        Console.WriteLine(resource);
    }
}
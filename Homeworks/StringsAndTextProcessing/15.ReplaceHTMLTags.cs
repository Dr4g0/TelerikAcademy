//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> 
//with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
//      "<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. 
//      Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>"
//                  Transform to:
//      "<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
//      Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>"

using System;
using System.Text;

class ReplaceHTMLTags
{
    static void Main()
    {
        const string OriginalText = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        StringBuilder text = new StringBuilder();
        text.Append(OriginalText);
        text.Replace("<a href=\"", "[URL=");
        text.Replace("\">","]");
        text.Replace("</a>", "[/URL]");
        Console.WriteLine(text);
    }
}
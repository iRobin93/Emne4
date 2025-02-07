// Sample text
using System.Text.RegularExpressions;

string text = "Here are some emails: tåst@example,com, hello.world@domain.net, invalid-email.com";

// Define a simple regex pattern to match email addresses
string pattern = @"\b[A-Åa-å0-9._%+-]+@[A-Åa-å0-9.-]+\.[A-Åa-å]{2,}\b";

// Use Regex to find matches
MatchCollection matches = Regex.Matches(text, pattern);

// Output the matches
Console.WriteLine("Found email addresses:");
foreach (Match match in matches)
{
    Console.WriteLine(match.Value);
}
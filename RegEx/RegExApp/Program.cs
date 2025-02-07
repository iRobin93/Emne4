// Sample text
using System.Text.RegularExpressions;

string text = "this is a gorder with 2ord four letters";

// Define the regex pattern to match words starting with 'g' and ending with 'ord'
string pattern = @"\b[a-zA-Z0-9]ord[A-Za-z0-9]{0,1}";  // g at the start and ord at the end

// Use Regex to find matches
MatchCollection matches = Regex.Matches(text, pattern);

// Output the matches and rest of the string after the match
Console.WriteLine("Found " + matches.Count + " matches:");
foreach (Match match in matches)
{
    Console.WriteLine("Matched: " + match.Value);

    // Get the rest of the string after the match
    int matchEndIndex = match.Index + match.Length;
    string restOfString = text.Substring(matchEndIndex);

    Console.WriteLine("Rest of string after the match: " + restOfString);
}
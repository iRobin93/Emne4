
//Input: 100001111(binært)
//Output: 10F(hex)
//Input: 11000010110001001100011(binært)
//Output: abc(ascii)

//Input: 1A(hex)
//Output: 00011010(binært)
//Input: 61 62 63(hex)
//Output: abc(ascii)

//Input: abc(ascii)
//Output: 01100001 01100010 01100011(binært)
//Input: abc(ascii)
//Output: 61 62 63(hex)

using System.Text;
using BinaryTranslator;

var inputText = new object[]
{
    new { data = "011000010110001001100011" , inputFormat = format.Binary, outputFormat = format.Ascii},
    new { data = "100001111", inputFormat = format.Binary, outputFormat = format.Hex },
    new { data = "616263", inputFormat = format.Hex, outputFormat = format.Ascii},
    new { data = "10F", inputFormat = format.Hex, outputFormat = format.Binary},
    new { data = "Hello", inputFormat = format.Ascii, outputFormat = format.Binary},
    new { data = "Hello", inputFormat = format.Ascii, outputFormat = format.Hex},

}
;
string output = "";

foreach (dynamic item in inputText)
{
    //dynamic dynamicItem = item;  // Cast to dynamic
    output = translate(item.data, item.inputFormat, item.outputFormat);
    Console.WriteLine("Input: " + item.data + $" ({item.inputFormat.ToString()})");
    Console.WriteLine("Output: " + output);
    Console.WriteLine();
}



string translate(string input, format inputFormat, format outputFormat)
{
    string output = "";


    switch(inputFormat)
    {
        case format.Binary:
            switch(outputFormat)
            {
                case format.Ascii: output = translateFromBinaryToAscii(input);
                    break;
                case format.Hex: output = translateFromBinaryToHex(input);
                    break;
                default: 
                    Console.WriteLine("Ugyldig outputformat");
                    break;
            }
            break;
        case format.Hex:
            switch(outputFormat)
            {
                case format.Ascii: output = translateFromHexToAscii(input);
                    break;
                case format.Binary: output = translateFromHexToBinary(input);
                    break;
                default:
                    Console.WriteLine("Ugyldig outputformat");
                    break;
            }
            break;
        case format.Ascii:
            switch(outputFormat)
            {
                case format.Binary: output = translateFromAsciiToBinary(input);
                    break;
                case format.Hex: output = translateFromAsciiToHex(input);
                    break;
                default:
                    Console.WriteLine("Ugyldig outputformat");
                    break;
            }
            break;
        default:
            Console.WriteLine("Ugyldig inputformat");
            break;
    }


    return output;
}

string translateFromBinaryToAscii(string input)
{
    StringBuilder output = new StringBuilder();
    try
    {
    for (int i = 0; i < input.Length; i += 8)
    {
        
        string byteString = input.Substring(i, 8);
        int charCode = Convert.ToInt32(byteString, 2);
        output.Append((char)charCode);
    }
    }
    catch(Exception e) { Console.WriteLine("Feil med input!"); }



    output.Append(" (Ascii)");
    return output.ToString();
}

string translateFromBinaryToHex(string input)
{
    StringBuilder output = new StringBuilder();
    try
    {
        int paddingLength = 8 - (input.Length % 8); // Calculate how many leading zeros to add
        if (paddingLength != 8)  // Only pad if necessary
        {
            input = new string('0', paddingLength) + input;
        }
        for (int i = 0; i < input.Length; i += 8)
        {
            string byteString = input.Substring(i, 8);
            int decimalValue = Convert.ToInt32(byteString, 2);
            string hexString = decimalValue.ToString("X2");
            output.Append(hexString);
        }
    }
    catch (Exception e) { Console.WriteLine("Feil med input!"); }

    output.Append(" (Hex)");
    return output.ToString();
}

string translateFromHexToAscii(string input)
{
    StringBuilder output = new StringBuilder();

    try
    {
        int paddingLength = 2 - (input.Length % 2); // Calculate how many leading zeros to add
        if (paddingLength != 2)  // Only pad if necessary
        {
            input = new string('0', paddingLength) + input;
        }

        // Iterate through the hex string in steps of 2 characters (1 byte)
        for (int i = 0; i < input.Length; i += 2)
        {
            // Get the current pair of hex characters
            string hexPair = input.Substring(i, 2);

            // Convert the hex pair to a byte (decimal value)
            byte byteValue = Convert.ToByte(hexPair, 16);

            // Convert the byte to an ASCII character and append it to the output
            output.Append((char)byteValue);
        }
    }
    catch (Exception e) { Console.WriteLine("Feil med input!"); }

    output.Append(" (Ascii)");
    return output.ToString();
}

string translateFromHexToBinary(string input)
{
    StringBuilder output = new StringBuilder();


    try
    {
        foreach (char hexChar in input)
        {
            int decimalValue = Convert.ToInt32(hexChar.ToString(), 16);
            string binaryString = Convert.ToString(decimalValue, 2).PadLeft(4, '0');
            output.Append(binaryString);
        }
        int paddingLength = 8 - (output.Length % 8);
        if (paddingLength != 8) // Only pad if necessary
        {
            output.Insert(0, new string('0', paddingLength));
        }
    }
    catch (Exception e) { Console.WriteLine("Feil med input!"); }

    output.Append(" (Binary)");
    return output.ToString();
}

string translateFromAsciiToBinary(string input)
{
    StringBuilder output = new StringBuilder();

    try
    {


        foreach (char c in input)
        {
            // Convert the character to its binary representation (8 bits)
            string binaryString = Convert.ToString(c, 2).PadLeft(8, '0');

            // Append the binary string to the output
            output.Append(binaryString);
        }
    }
    catch (Exception e) { Console.WriteLine("Feil med input!"); }

    output.Append(" (Binary)");
    return output.ToString();
}

string translateFromAsciiToHex(string input)
{
    StringBuilder output = new StringBuilder();


    try
    {


        foreach (char c in input)
        {
            // Convert each character to its hexadecimal equivalent
            string hexString = ((int)c).ToString("X");

            // Append the hex string to the output
            output.Append(hexString);
        }
    }
    catch (Exception e) { Console.WriteLine("Feil med input!"); }

    output.Append(" (Hex)");
    return output.ToString();
}
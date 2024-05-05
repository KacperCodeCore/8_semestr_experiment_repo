using System;

class CaesarCipher
{
    static string Encrypt(string text, int shift)
    {
        string result = "";

        foreach (char ch in text)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsUpper(ch) ? 'A' : 'a';
                result += (char)((((ch + shift) - offset) % 26) + offset);
            }
            else
            {
                result += ch;
            }
        }

        return result;
    }

    static string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift);
    }

    static void Main()
    {
        string message = "123 Intruz";
        Console.WriteLine("message: " + message);
        int shift = 3;

        string encrypted = Encrypt(message, shift);
        Console.WriteLine("encrypted: " + encrypted);

        string decrypted = Decrypt(encrypted, shift);
        Console.WriteLine("decrypted: " + decrypted);
    }
}

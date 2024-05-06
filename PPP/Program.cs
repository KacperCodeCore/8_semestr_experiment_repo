// PPP
using System.Numerics;

BigInteger[] v = [3, 7, 12, 29, 61, 129];
BigInteger m = 263;
BigInteger a = 67;
int[] message = [1, 1, 1, 1, 0, 1];
BigInteger x = 0;


BigInteger[] v2 = [0, 0, 0, 0, 0, 0];
Console.Write("v2: ");
for (int i = 0; i < v.Length; i++)
{
    v2[i] = (v[i] * a) % m;
    Console.Write($"{v2[i]} ");
}

Array.Reverse(message);
for (int i = 0; i < v.Length; i++)
{
    if (message[i] == 1)
    {
        x += v2[i];
    }
}
Console.Write($"\nx: {x}\n");

// b = a^-1 mod m
BigInteger b = ModularInverse(a, m);
Console.WriteLine($"b: {b}");

BigInteger d = b * x % m;
Console.WriteLine($"d: {d}");

Array.Reverse(message);
Console.Write("  message: ");
for (int i = 0; i < v.Length; i++)
{
    Console.Write($"{message[i]} ");
}

int[] decrypted = [0, 0, 0, 0, 0, 0];
Array.Reverse(v);
for (int i = 0; i < v.Length; i++)
{
    if (d >= v[i])
    {
        d -= v[i];
        decrypted[i] = 1;
    }
}

Console.Write("\ndecrypted: ");
for (int i = 0; i < v.Length; i++)
{
    Console.Write($"{decrypted[i]} ");
}





BigInteger ModularInverse(BigInteger a, BigInteger m)
{
    BigInteger m0 = m;
    BigInteger y = 0;
    BigInteger x = 1;

    if (m == 1)
        return 0;

    while (a > 1)
    {
        // q to iloraz
        BigInteger q = a / m;
        BigInteger t = m;

        // m staje się resztą, proces taki sam jak w algorytmie Euklidesa
        m = a % m;
        a = t;
        t = y;

        // Aktualizacja y i x
        y = x - q * y;
        x = t;
    }

    // Sprawdzamy, czy x jest ujemne i korygujemy
    if (x < 0)
        x += m0;

    return x;
}
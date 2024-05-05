using System.Numerics;

Random random = new Random();

BigInteger p = 3407;
BigInteger q = 3779;
BigInteger e = 421;
BigInteger message = 2137;

Console.WriteLine($"p: {p}");
Console.WriteLine($"q: {q}");

// n = p * q
BigInteger n = p * q;
Console.WriteLine($"n: {n}");

//Euler function phi(n) = (p-1)*(q-1)
BigInteger phi = (p - 1) * (q - 1);

// e coprime with phi(n)
// BigInteger e = 7;
if (!IsCoprime(e, phi))
{
   Console.WriteLine($"e:{e} is not coprime with phi(n):{phi}");
   Environment.Exit(0);
}
Console.WriteLine($"e: {e}");

// d = the modular multiplicative inverse of e modulo phi(n)
BigInteger d = ModInverse(e, phi);
Console.WriteLine($"d: {d}");

// public key
Tuple<BigInteger, BigInteger> publicKey = new(e, n);
Console.WriteLine($"publicKey: ({e}, {n})");

// private key
Tuple<BigInteger, BigInteger> privateKey = new(d, n);
Console.WriteLine($"publicKey: ({d}, {n})");

// message
// BigInteger message = 2744;
Console.WriteLine($"message: {message}");

// encryption
BigInteger encrypted = Encrypt(message, publicKey);
Console.WriteLine($"encrypted: {encrypted}");

// decryption
BigInteger decrypted = Decrypt(encrypted, privateKey);
Console.WriteLine($"decrypted: {decrypted}");




bool IsCoprime(BigInteger a, BigInteger b)
{
   return NWD(a, b) == 1;
}

BigInteger NWD(BigInteger a, BigInteger b)
{
   while (b != 0)
   {
      BigInteger temp = b;
      b = a % b;
      a = temp;
   }
   return a;
}

BigInteger Encrypt(BigInteger message, Tuple<BigInteger, BigInteger> publicKey)
{
   BigInteger e = publicKey.Item1;
   BigInteger n = publicKey.Item2;

   return BigInteger.ModPow(message, e, n);
}

BigInteger Decrypt(BigInteger cipherText, Tuple<BigInteger, BigInteger> privateKey)
{
   BigInteger d = privateKey.Item1;
   BigInteger n = privateKey.Item2;

   // Message = CipherText^d mod n
   return BigInteger.ModPow(cipherText, d, n);
}


BigInteger ModInverse(BigInteger a, BigInteger m)
{
   BigInteger m0 = m;
   BigInteger y = 0, x = 1;

   if (m == 1)
      return 0;

   while (a > 1)
   {
      // q is quotient
      BigInteger q = a / m;
      BigInteger t = m;

      // m is remainder now, process same as
      // Euclid's algo
      m = a % m;
      a = t;
      t = y;

      // Update y and x
      y = x - q * y;
      x = t;
   }

   // Make x positive
   if (x < 0)
      x += m0;

   return x;
}

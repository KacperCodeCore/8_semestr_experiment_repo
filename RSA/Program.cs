// toworzenie klucza
using System.Numerics;

Random random = new Random();

int p = 7;
int q = 13;
BigInteger n = p*q;
BigInteger e = random.Next(1,Euler(p, q));



 Console.WriteLine($"p: {p}");
 Console.WriteLine($"q: {q}");
 Console.WriteLine($"n: {n}");



 int Euler(int p, int q){
    return (p-1)*(q-1);
 }




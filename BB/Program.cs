// BB 
//--Preparation-----------------------------------------------------------------
const int N = 4;
List<int> A = new List<int>();
List<int> B = new List<int>();
Random rand = new Random();
Point[] points = new Point[N];

// int timeOut = 999;
double currentDistance = 0;
double bestDistance = 9999999;
double lastMoveDistance = 0;

for (int i = 1; i < N + 1; i++)
{
    B.Add(i);
}

//creating random B
for (int i = B.Count - 1; i > 0; i--)
{
    int j = rand.Next(1, i + 1);
    int temp = B[i];
    B[i] = B[j];
    B[j] = temp;
}
//add starting point
int x = B[0];
A.Add(x);
B.RemoveAt(0);

//set points
for (int i = 0; i < N; i++)
{
    points[i] = new Point(rand.Next(1, 400), rand.Next(1, 400));
}







//--Start----------------------------------------------------------------------------------
PrintPoints();
BB();






//--functions-----------------------------------------------------------------------------------
void PrintAB()
{
    Console.Write("\nA: ");
    foreach (var item in A)
    {
        Console.Write(item + " ");
    }
    foreach (var item in B)
    {
        Console.Write("  ");
    }
    Console.Write("  B: ");
    foreach (var item in B)
    {
        Console.Write(item + " ");
    }
    foreach (var item in A)
    {
        Console.Write("  ");
    }
    Console.Write($"CurrentDistance: {currentDistance,-10:F2}");
    Console.Write($"LastMoveDistance: {lastMoveDistance,-10:F2}");
    Console.Write($"BestDistance: {bestDistance:F2}");
}
void PrintPoints()
{
    Console.Write("\nPoints: ");
    foreach (var item in points)
    {
        Console.Write($"({item.X},{item.Y}) ");
    }
}

double DistanceBetweenPoints(Point a, Point b)
{
    double deltaX = b.X - a.Y;
    double deltaY = b.Y - a.Y;
    return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
}

bool Oracle()
{
    return currentDistance < bestDistance;
}

void BB()
{
    // PrintAB();
    if (B.Count == 0)
    {
        Console.Write($"\n  -CurrentDistance: {currentDistance:F2}   BestDistance: {bestDistance:F2}");
        if (currentDistance < bestDistance)
        {
            bestDistance = currentDistance;
        }
        // return;
    }
    else
    {
        int n = B.Count;
        for (int i = 0; i < n; i++)
        {
            int x = B[0];
            A.Add(x);
            B.RemoveAt(0);
            lastMoveDistance = DistanceBetweenPoints(points[A.Count - 1], points[A.Count - 2]);
            currentDistance += lastMoveDistance;
            PrintAB();
            // if (B.Count == 0){
            //     Console.Write($"\n  -CurrentDistance: {currentDistance:F2}   BestDistance: {bestDistance:F2}");
            //     if (currentDistance < bestDistance)
            //     {
            //         bestDistance = currentDistance;
            //     }
            // }

            if (Oracle())
            {
                BB();
                // Console.Write($"\n  -CurrentDistance: {currentDistance:F2}   BestDistance: {bestDistance:F2}");
                // if (currentDistance < bestDistance)
                // {
                //     bestDistance = currentDistance;
                // }
            }

            lastMoveDistance = -DistanceBetweenPoints(points[A.Count - 1], points[A.Count - 2]);
            currentDistance += lastMoveDistance;
            x = A[A.Count - 1];
            A.RemoveAt(A.Count - 1);
            B.Add(x);
            PrintAB();


            // timeOut--;
            // if(timeOut <= 0){break;}
        }
    }
}





//--Classes-------------------------------------------------------------------------------------------
class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

}


using System;
public class Rng
{
    Random rndm = new Random();
    public int d4()
    {
        return rndm.Next(1, 5);
    }
    public int d6()
    {
        return rndm.Next(1, 7);
    }
    public int d8()
    {
        return rndm.Next(1, 9);
    }
    public int d12()
    {
        return rndm.Next(1, 13);
    }
    public int d20()
    {
        return rndm.Next(1, 21);
    }
    public int d100()
    {
        return rndm.Next(1, 101);
    }

}
public class Methods
{


    public static void GameplayLoop(ConsoleKeyInfo input = new ConsoleKeyInfo())
    {
        var rndm = new Rng();
        do
        {       //detta är till för att kunna ändra koordinater i arrayen. Planen är att ´man kan flytta sig med w,a,s,d.
            while (Console.KeyAvailable == false)  //så länge något inte är inskrivet så kommer det nedan loopas
            {
                System.Threading.Thread.Sleep(1); //loopas till något har skrivits in
                Console.Clear();
            }
            input = Console.ReadKey(true); //'true' gör så att det man skriver in, inte visas på skärmen

            if (input.Key == ConsoleKey.W)      // du kan skriva in vilken tangent som helst här
            {

                Console.WriteLine(input.Key);
                switch (rndm.d4())
                {

                }
            }

            if (input.Key == ConsoleKey.A)
            {


            }

            if (input.Key == ConsoleKey.S)
            {


            }

            if (input.Key == ConsoleKey.D)
            {

            }
        } while (input.Key != ConsoleKey.Escape);  //TRycker man på escape slutar loopen.

    }
}

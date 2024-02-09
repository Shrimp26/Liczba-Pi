using System;

//Napisz program, który za pomocą metody Monte Carlo oblicza liczbę Pi z określoną dokładnością.
//Skorzystaj z rysunku pomocniczego i następującej listy kroków:
//Wpisz koło o promieniu r w kwadrat o boku 2r
//Losowo wygeneruj punkty i umieść je w kwadracie
//Wyznacz liczbę punktów, które znajdują się jednocześnie w kwadracie i kole
//Niech promień r będzie wyznaczony przez stosunek liczby punktów znajdujących się w kole do liczby punktów znajdujących się w kwadracie
//Pi~4.0·r
//Dodatkowo należy zmierzyć czas obliczeń sekwencyjnych.

class LiczbaPi {
    static void Main()
    {
        Console.WriteLine(" Porogram obliczający liczbę Pi za pomocą metody Monte Carlo.");

        int liczbaPunktow;
        while (true)
        {
            try
            {
                Console.WriteLine("Podaj liczbę punktów do wygenerowania: ");
                liczbaPunktow = Convert.ToInt32(Console.ReadLine());
                if (liczbaPunktow <= 0)
                {
                    throw new ArgumentException("Liczba punktów musi być liczbą dodatnią, większą od zera.");
                }
                break;

            }
            catch (FormatException)
            {
                Console.WriteLine("Podaj poprawną liczbę całkowitą.");
            } 
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        double pi = ObliczPiMetodaMonteCarlo(liczbaPunktow);
        Console.WriteLine($"Przybliżona wartość liczby Pi wynosi: {pi}.");

    }

    static double ObliczPiMetodaMonteCarlo(int liczbaPunktow)
    {
        Random rand = new Random();
        int punktyWKole = 0;

        for (int i = 0; i < liczbaPunktow; i++)
        {
            double x = rand.NextDouble() * 2 - 1;
            double y = rand.NextDouble() * 2 - 1;

            if (x * x + y * y <= 1)
            {
                punktyWKole++;
            }
        }

        double stosunek = (double)punktyWKole / liczbaPunktow;
        double pi = 4.0 * stosunek;

        return pi;
    }
}
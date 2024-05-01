namespace SieveOfEratosthenes;

public class GeneratorPrimes
{
    private static void InitializeArray(Boolean[] array, int size)
    {
        for (int i = 0; i < size; i++)
            array[i] = true;
    }

    private static void DeleteInitialNonPrimeNumbers(Boolean[] array)
    {
        array[0] = array[1] = false;
    }

    private static void DeleteNonPrimeNumbers(Boolean[] array, int size)
    {
            for (int i = 2; i < Math.Sqrt(size) + 1; i++)
            {
                if (array[i])
                {
                    for (int j = 2 * i; j < size; j += i)
                        array[j] = false;
                }
            }
    }

    private static int CountPrimeNumbers(Boolean[] array, int size)
    {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (array[i])
                    count++;
            }
            return count;
    }

    private static int[] ExtractPrimeNumbers(Boolean[] array, int size, int count)
    {
            int[] primes = new int[count];
            for (int i = 0, j = 0; i < size; i++)
            {
                if (array[i])
                    primes[j++] = i;
            }
            return primes;
    }

    public static int[] generatePrimes(int maxValue)
    {
        if (maxValue >= 2)
        {
            // Объявления
            int s = maxValue + 1;
            Boolean[] f = new bool[s];

            InitializeArray(f, s);

            DeleteInitialNonPrimeNumbers(f);

            DeleteNonPrimeNumbers(f, s);

            int count = CountPrimeNumbers(f, s);

            return ExtractPrimeNumbers(f, s, count);
        }
        else return new int[0];
    }
}

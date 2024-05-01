namespace SieveOfEratosthenes;

public class GeneratorPrimes
{
    int size, count;
    Boolean[] array;
    private void InitializeArray()
    {
        for (int i = 0; i < size; i++)
            array[i] = true;
    }

    private void DeleteInitialNonPrimeNumbers()
    {
        array[0] = array[1] = false;
    }

    private void DeleteNonPrimeNumbers()
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

    private void CountPrimeNumbers()
    {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (array[i])
                    count++;
            }
            this.count = count;
    }

    private int[] ExtractPrimeNumbers()
    {
            int[] primes = new int[count];
            for (int i = 0, j = 0; i < size; i++)
            {
                if (array[i])
                    primes[j++] = i;
            }
            return primes;
    }

    public int[] generatePrimes(int maxValue)
    {
        this.size = maxValue + 1;
        this.array = new Boolean[size];

        InitializeArray();
        DeleteInitialNonPrimeNumbers();
        DeleteNonPrimeNumbers();
        CountPrimeNumbers();
        return ExtractPrimeNumbers();
    }
}

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
                if (array[i]) //Если элемент i не вычеркнут, вычеркнуть кратные ему
                {
                    for (int j = 2 * i; j < size; j += i)
                        array[j] = false; //Кратные числа не являются простыми
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
                if (array[i]) //Если простое
                    primes[j++] = i;
            }
            return primes;
    }

    public static int[] generatePrimes(int maxValue)
    {
        if (maxValue >= 2) // Единственно допустимый случай
        {
            // Объявления
            int s = maxValue + 1; // Размер массива
            Boolean[] f = new bool[s];

            //Инициализировать массив значением true
            InitializeArray(f, s);

            //Удалить числа, заведомо не являющиеся простыми
            DeleteInitialNonPrimeNumbers(f);

            //Отсев
            DeleteNonPrimeNumbers(f, s);

            //Сколько простых чисел осталось?
            int count = CountPrimeNumbers(f, s);

            return ExtractPrimeNumbers(f, s, count); //Вернуть простые числа
        }
        else //maxValue < 2
            return new int[0]; //Вернуть пустой массив
    }
}

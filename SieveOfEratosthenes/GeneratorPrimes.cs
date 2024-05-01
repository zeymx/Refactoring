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

    public static int[] generatePrimes(int maxValue)
    {
        if (maxValue >= 2) // Единственно допустимый случай
        {
            // Объявления
            int s = maxValue + 1; // Размер массива
            Boolean[] f = new bool[s];
            int i;

            //Инициализировать массив значением true
            InitializeArray(f, s);

            //Удалить числа, заведомо не являющиеся простыми
            DeleteInitialNonPrimeNumbers(f);

            //Отсев
            int j = 0;
            DeleteNonPrimeNumbers(f, s);

            //Сколько простых чисел осталось?
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i])
                    count++; //Приращение счетчика
            }

            int[] primes = new int[count];
            //Переместить простые числа в результат
            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i]) //Если простое
                    primes[j++] = i;
            }
            return primes; //Вернуть простые числа
        }
        else //maxValue < 2
            return new int[0]; //Вернуть пустой массив
    }
}

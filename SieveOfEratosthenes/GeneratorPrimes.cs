namespace SieveOfEratosthenes;

public class GeneratorPrimes
{
    public static int[] generatePrimes(int maxValue)
    {
        if (maxValue >= 2) // Единственно допустимый случай
        {
            // Объявления
            int s = maxValue + 1; // Размер массива
            Boolean[] f = new bool[s];
            int i;

            //Инициализировать массив значением true
            for (i = 0; i < s; i++)
                f[i] = true;

            //Удалить числа, заведомо не являющиеся простыми
            f[0] = f[1] = false;

            //Отсев
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i]) //Если элемент i не вычеркнут, вычеркнуть кратные ему
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false; //Кратные числа не являются простыми
                }
            }

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

namespace SieveOfEratosthenes.Tests;

public class UnitTest1
{
    [Fact]
    public void PrimeNumbersBefore15()
    {
        int[] primeNumbersActual = [2, 3, 5, 7, 11, 13];
        int[] primeNumbers = GeneratorPrimes.generatePrimes(15);

        Assert.Equal(primeNumbersActual, primeNumbers);
    }
}
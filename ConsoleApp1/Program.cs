

const int N = 100;
const int max = 10000;

// Generate an unsorted array of numbers
int[] numbers = GenerateUnsortedArray(max);

// Find a number bigger than N using a parallel algorithm
int result = FindNumberBiggerThanN(numbers, N);

// Print the result
if (result > N)
{
    Console.WriteLine($"Found a number bigger than {N}: {result}");
}
else
{
    Console.WriteLine($"No bigger number found {N}");
}

// Method to generate an unsorted array of a given size
static int[] GenerateUnsortedArray(int size)
{
    // Create an array with numbers from 0 to size-1
    int[] numbers = Enumerable.Range(0, size).ToArray();
    Random random = new Random();

    // Shuffle the array to make it unsorted
    for (int i = 0; i < numbers.Length; i++)
    {
        int j = random.Next(i, numbers.Length);
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }

    return numbers;
}

// Method to find a number bigger than N using parallel processing
static int FindNumberBiggerThanN(int[] numbers, int N)
{
    int output = -1;

    // Use Parallel.ForEach to search for a number bigger than N in parallel
    Parallel.ForEach(numbers, (number, state) =>
    {
        if (number > N)
        {
            // If a number is found, set the output and break the loop
            output = number;
            state.Break();
        }
    });

    return output;
}

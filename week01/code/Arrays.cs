public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //PLAN;
       // Step 1: Create an array of the given length to hold the multiples
        double[] multiples = new double[length];

        // Step 2: Begin by filling the array with multiples of the number
        // so for example, for number = 7 and length = 5, the output should be {7, 14, 21, 28, 35}.
        for (int counter = 0; counter < length; counter++)
        {
            multiples[counter] = number * (counter + 1); // counter + 1 ensures we get multiples starting from the number itself
        }

        // Step 3: Return the array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// <parameter name="integers">List of integers to rotate</parameter>
    /// <parameter name="position">Number of positions to rotate to the right</parameter>
    public static void RotateListRight(List<int> integers, int position)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
         // Step 1: Normalize the amount by taking modulo to avoid unnecessary rotations
        position = position % integers.Count;

        // Step 2: Create two slices
        // The first slice is the last 'position' elements from the end of the list
        List<int> lastPart = integers.GetRange(integers.Count - position, position);
        
        // The second slice is the first part of the list (remaining elements)
        List<int> firstPart = integers.GetRange(0, integers.Count - position);

        // Step 3: Clear the original list and add the rotated elements back
        integers.Clear();
        integers.AddRange(lastPart);
        integers.AddRange(firstPart);
    }
}

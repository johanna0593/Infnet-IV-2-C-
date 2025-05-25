using System;

class Program
{
    static void Main()
    {
        Func<string, string, string> combineNames = (firstName, lastName) =>
        {
            string result = firstName + " " + lastName;
            Console.WriteLine("Concatenação: " + result);
            return result;
        };

        Func<string, string> toUpper = (input) =>
        {
            string result = input.ToUpper();
            Console.WriteLine("Maiúsculas: " + result);
            return result;
        };

        Func<string, string> removeSpaces = (input) =>
        {
            string result = input.Replace(" ", "");
            Console.WriteLine("Sem espaços: " + result);
            return result;
        };

        string fullName = combineNames("Maria", "Silva");
        string upper = toUpper(fullName);
        string noSpaces = removeSpaces(upper);

        Console.WriteLine($"\nResultado Final: {noSpaces}");
    }
}

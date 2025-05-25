using System;

class Program
{
    static void Main()
    {
        Func<string, string, string> combineNames = (firstName, lastName) =>
        {
            string result = firstName + " " + lastName;
            Console.WriteLine("Concatena��o: " + result);
            return result;
        };

        Func<string, string> toUpper = (input) =>
        {
            string result = input.ToUpper();
            Console.WriteLine("Mai�sculas: " + result);
            return result;
        };

        Func<string, string> removeSpaces = (input) =>
        {
            string result = input.Replace(" ", "");
            Console.WriteLine("Sem espa�os: " + result);
            return result;
        };

        string fullName = combineNames("Maria", "Silva");
        string upper = toUpper(fullName);
        string noSpaces = removeSpaces(upper);

        Console.WriteLine($"\nResultado Final: {noSpaces}");
    }
}

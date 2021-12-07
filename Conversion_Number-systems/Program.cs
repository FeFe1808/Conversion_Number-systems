using System.Numerics;

class Program
{
    static void Main()
    {
        Menü(false);
    }

    static void Menü(bool wrong_num)
    {
        Console.WriteLine("Welcome to converting a number to another number system!");
        Console.WriteLine("Choose, from which number system you want to convert and to which one:");
        Console.WriteLine();
        if (wrong_num)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please insert a valid number!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        Console.WriteLine("[1]Decimal to Hexadecimal");
        Console.WriteLine("[2]Hexadecimal to Decimal");
        Console.WriteLine("[3]Decimal to Binary");
        Console.WriteLine("[4]Binary to Decimal");
        Console.WriteLine("[5]Hexadecimal to Binary");
        Console.WriteLine("[6]Binary to Hexadecimal");
        int input = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        if (input == 1)
        {
            Console.WriteLine("Insert a number to convert from Decimal to Hexadecimal: ");
            BigInteger input1 = BigInteger.Parse(Console.ReadLine());
            string result = Decimal_to_Hexadecimal(input1);
            Console.Write("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (input == 2)
        {
            Console.WriteLine("Insert a number to convert from Hexadecimal to Decimal: ");
            BigInteger result = Hexadecimal_to_Decimal(Convert.ToString(Console.ReadLine()));
            Console.Write("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (input == 3)
        {
            Console.WriteLine("Gib eine Zahl zum konvertieren von Dezimal in Binär an: ");
            BigInteger input1 = BigInteger.Parse(Console.ReadLine());
            string result = Decimal_to_Binary(input1);
            Console.Write("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (input == 4)
        {
            Console.WriteLine("Insert a number to convert from Binary to Decimal: ");
            BigInteger result = Binary_to_Decimal(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (input == 5)
        {
            Console.WriteLine("Insert a number to convert from Hexadecimal to Binary: ");
            string result = Decimal_to_Binary(Hexadecimal_to_Decimal(Convert.ToString(Console.ReadLine())));
            Console.WriteLine("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (input == 6)
        {
            Console.WriteLine("Insert a number to convert from Binary to Hexadecimal: ");
            string result = Decimal_to_Hexadecimal(Binary_to_Decimal(Convert.ToString(Console.ReadLine())));
            Console.WriteLine("The result is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Menü(true);
        }
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

        Menü(false);
    }

    static string Decimal_to_Hexadecimal(BigInteger zahl)
    {
        BigInteger rest;
        BigInteger quotient = zahl;
        string hexa = "";

        while (quotient != 0)
        {
            rest = quotient % 16;
            quotient /= 16;

            if (rest == 10) { hexa = hexa.Insert(0, "A"); }

            else if (rest == 11) { hexa = hexa.Insert(0, "B"); }

            else if (rest == 12) { hexa = hexa.Insert(0, "C"); }

            else if (rest == 13) { hexa = hexa.Insert(0, "D"); }

            else if (rest == 14) { hexa = hexa.Insert(0, "E"); }

            else if (rest == 15) { hexa = hexa.Insert(0, "F"); }

            else { hexa = hexa.Insert(0, Convert.ToString(rest)); }
        }
        return hexa;
    }

    static BigInteger Hexadecimal_to_Decimal(string hexa)
    {
        hexa = hexa.ToUpper();
        char[] chars = hexa.ToCharArray();

        for (long i = 0; i < chars.Length / 2; i++)
        {
            char tmp = chars[i];
            if (chars.Length - i - 1 >= 0)
            {
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = tmp;
            }
        }
        BigInteger deci = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            char tmp = chars[i];
            BigInteger tmp1 = 0;

            if (Convert.ToString(tmp) == "A") { tmp1 = 10; }
            else if (Convert.ToString(tmp) == "B") { tmp1 = 11; }
            else if (Convert.ToString(tmp) == "C") { tmp1 = 12; }
            else if (Convert.ToString(tmp) == "D") { tmp1 = 13; }
            else if (Convert.ToString(tmp) == "E") { tmp1 = 14; }
            else if (Convert.ToString(tmp) == "F") { tmp1 = 15; }
            else { tmp1 = chars[i] - 48; }

            deci += tmp1 * BigInteger.Pow(16, i);

        }
        return deci;
    }

    static string Decimal_to_Binary(BigInteger dezi)
    {
        string binary = "";
        BigInteger quotient = dezi;
        BigInteger rest;

        while (quotient != 0)
        {
            rest = quotient % 2;
            quotient /= 2;

            binary = binary.Insert(0, Convert.ToString(rest));
        }

        return binary;
    }

    static BigInteger Binary_to_Decimal(string binary)
    {
        char[] chars = binary.ToCharArray();

        for (long i = 0; i < chars.Length / 2; i++)
        {
            char tmp = chars[i];
            if (chars.Length - i - 1 >= 0)
            {
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = tmp;
            }
        }

        BigInteger deci = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            deci += (chars[i] - 48) * BigInteger.Pow(2, i);
        }
        return deci;
    }
}

decimal ReadDec(string prompt,decimal min)
{

    string? amountConsole;
    while (true)
    {
        Console.Write(prompt);
        amountConsole = Console.ReadLine();
        if (!decimal.TryParse(amountConsole, out decimal amount) || amount <= min)
        {
            Console.Write("Napiste prosim spravnou cenu\n");
        }
        else
        {
            return amount;
        }
        
    }
}

int ReadInt(string prompt, int min)
{
    string? countConsole;
    while (true)
    {
        Console.Write(prompt);
        countConsole = Console.ReadLine();
        if (!int.TryParse(countConsole, out int result) || result < min)
        {
            Console.Write("Napiste prosim spravny pocet\n");
        }
        else
        {
            return result;
        }
        
    }
}

(decimal WithoutDPH, decimal DPH, decimal sum) Calculate(decimal price, int count,decimal dph)
{
    decimal withoutDPH = price * count;
    decimal DPH = withoutDPH *dph/ 100;
    decimal sum = withoutDPH + DPH;
    return (withoutDPH, DPH, sum);
}

const decimal dph = 21m;
string? name;
while (true)
{
    Console.WriteLine("Uvedte prosim nazev");
    name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Uvedte ne prazdny nazev:");
    }
    else
    {
        break;
    }
}
decimal price = ReadDec("Uvedte prosim cenu bez DPH",0);
int count = ReadInt("Uvedte prosim pocet productu", 1);
var (withoutDPH, DPH, sum) = Calculate(price, count,dph);
Console.WriteLine($" {name}: x{count}");
Console.WriteLine($"Bez DPH: {withoutDPH:F2}");
Console.WriteLine($"DPH: {DPH:F2}");
Console.WriteLine($"Sum: {sum:F2}");

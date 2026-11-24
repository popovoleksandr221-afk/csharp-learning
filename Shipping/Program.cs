

using System.Globalization;

const decimal SmallPrice = 79m;
const decimal MiddlePrice = 129m;
const decimal LargePrice = 199m;

int count01= 0;
int count15= 0;
int count520= 0;

while (true)
{
    Console.Write("> ");
    string? input = Console.ReadLine();
    if (input == "exit" || string.IsNullOrWhiteSpace(input))
    {
        decimal maxPrice = 0;
        if (count520 > 0) maxPrice = LargePrice;
        else if (count15 > 0) maxPrice = MiddlePrice;
        else if (count01 > 0) maxPrice = SmallPrice;
        if (count01 > 0 || count15 > 0 || count520 > 0)
        {
            Console.WriteLine($"Parcels: {count01 + count15 + count520}, total: {(count01 *SmallPrice)+(count15*MiddlePrice)+(count520*LargePrice)} Kč, max: {maxPrice} Kč" );
        }
        else
        {
            Console.WriteLine("No parcels");
        }
        break;
    }
    if (!decimal.TryParse(input, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
            CultureInfo.InvariantCulture, out decimal weight))
    {
        Console.WriteLine("Invalid input");
        continue;
    }
    
    
    switch (weight)
    {
        case <=0:
            Console.WriteLine("Weight must be > 0");
            break;
        case <=1:
            Console.WriteLine($"{SmallPrice} Kč");
            count01++;
            break;
        case <=5:
            Console.WriteLine($"{MiddlePrice} Kč");
            count15++;
            break;
        case <=20:
            Console.WriteLine($"{LargePrice} Kč");
            count520++;
            break;
        case > 20:
            Console.WriteLine($"Too heavy (max 20 kg)");
            break;
                
    }
    
}

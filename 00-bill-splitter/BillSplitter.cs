#!/usr/bin/env dotnet

decimal[] CalculateBill(string amount, string extra, string count)
{
    decimal amountD = decimal.Parse(amount);
    decimal diskoD = decimal.Parse(extra);
    int pocetD = int.Parse(count);

    decimal disR = amountD * diskoD / 100;
    decimal sumR = disR + amountD;
    decimal zvlastR = sumR / pocetD;

    decimal[] res = new decimal[3];
    res[0] = disR;
    res[1] = sumR;
    res[2] = zvlastR;
    return res;
}

string castka;
while (true)
{
    Console.WriteLine("Uvedte prosim castku");
    castka = Console.ReadLine();
    if (!decimal.TryParse(castka, out decimal num) ||  num<0)
    {
        Console.WriteLine("Uvedte prosim decimal castku");
    }
    else
    {
        break;
    }
}

string pocet;
while (true)
{
    Console.WriteLine("Uvedte pocet osob");
    pocet = Console.ReadLine();
    if (!int.TryParse(pocet, out int num2) ||  num2<=0)
    {
        Console.WriteLine("Uvedte prosim spravny pocet osob");
    }
    else
    {
        break;
    }
}

string disko;
while (true)
{ 
    Console.WriteLine("Uvedte % diska");
    disko = Console.ReadLine();
    
    if (!decimal.TryParse(disko, out decimal num3)|| num3 < 0)
    {
        Console.WriteLine("Uvedte prosim spravne spropitne");
    }
    else
    {
        break;
    }
    
}
decimal[] res = CalculateBill(castka,disko,pocet);
// output
Console.WriteLine($"Spropitne: {res[0]:F2} Kč");
Console.WriteLine($"Dohromady: {res[1]:F2} Kč");
Console.WriteLine($"Z kazdyho:{res[2]:F2} Kč");
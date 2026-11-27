
static bool TryParseOrder(string line, out string item, out int quantity)
{

    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length != 2)
    {
        item = null;
        quantity = 0;
        return false;
    }
    if(!int.TryParse(parts[1], out quantity ) || quantity <= 0 )
    {
        item = null;
        quantity = 0;
        return false;
    }
    item = parts[0];
    return true;
}

Dictionary<string, int> stock = new Dictionary<string, int>
{
    ["apple"] = 10,
    ["banana"] = 4,
    ["milk"] = 6,
    ["bread"] = 5
};
string item;
int quantity;
List<string> shipped = new List<string>();
while (true)
{
    string line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) break;
    if (!TryParseOrder(line, out item, out quantity))
    {
        Console.WriteLine($"Ошибка формата: \"{line}\"");
    }
    else
    {
        if (!stock.TryGetValue(item, out int inStock))
        {
            Console.WriteLine($"Неизвестный товар: {item}");
            continue;
        }
        if (inStock < quantity)
        {
            Console.WriteLine($"Недостаточно: {item} (есть {inStock}, нужно {quantity})");
            continue;
        }

        stock[item]= inStock - quantity;
        shipped.Add(string.Format("{0} x{1}", item, quantity));
        Console.WriteLine($"ОК: {item} x{quantity}");
    }
}
Console.WriteLine();
if (shipped.Count > 0)
{
    Console.WriteLine($"Отгружено: {string.Join(", ", shipped)}");
}

List<string> lowStock = new List<string>();
foreach (var (key, value) in stock)
{
    if (value < 5)
    {
        lowStock.Add(string.Format("{0}: {1}", key, value));   
    }
}

if (lowStock.Count > 0)
{
    Console.WriteLine($"Мало на складе (< 5): {string.Join(", ", lowStock)}");
}
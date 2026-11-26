
string Ask(string prompt)
{
    Console.Write(prompt);
    return (Console.ReadLine() ?? "").Trim();
}

string username;
int age;
string mail;
while (true)
{
    username = Ask("Username: ");
    if (RegistrationValidator.IsValidUsername(username, out string error))
        break;                          
    Console.WriteLine($"❌ {error}");
}
while (true)
{
    string vek = Ask("Age: ");
    if (RegistrationValidator.TryParseAge(vek, out  age, out string error)) break;   
    
    Console.WriteLine($"❌ {error}");
}
while (true)
{
    mail = Ask("Email: ");
    if (RegistrationValidator.IsValidEmail(mail, out string error))
        break;                          
    Console.WriteLine($"❌ {error}");
}
Console.WriteLine($"✅Registered: {username} , {age} , {mail}");
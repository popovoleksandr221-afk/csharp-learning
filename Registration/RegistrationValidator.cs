
public static class RegistrationValidator
{
    public static bool IsValidUsername(string? input, out string error)
    {
        if (input is null)
        {
            error = "Input cannot be null";
            return false;
        }
        if (input.Length < 3 || input.Length > 16)
        {
            error = "Username must be 3–16 characters.";
            return false;
        }
        foreach (var c in input)
        {
            if (!char.IsLetterOrDigit(c) && c != '_'){
                error = "Username can only contain letters, digits and _.";
                return false;   
             }
        }
        error = "";
        return true;
    }

    public static bool TryParseAge(string? input, out int age, out string error)
    {
        if (!int.TryParse(input, out age))
        {
            error = "Age must be a number.";
            return false;
        }
        if (age < 16 || age > 120)
        {
            error = "Age must be between 16 and 120.";
            age = 0;
            return false;
        }
        error = "";
        return true;
    }

    public static bool IsValidEmail(string? input, out string error)
    {
        if (input is null)
        {
            error = "Email cannot be null";
            return false;
        }
        int atIndex =  input.IndexOf('@');
        if (atIndex == -1)
        {
            error = "Invalid email.";
            return false;
        }
        int lastAtIndex = input.LastIndexOf('@');
        if (atIndex != lastAtIndex)
        {
            error = "Invalid email.";
            return false;
        }
        if (atIndex == 0 || atIndex == input.Length - 1)
        {
            error = "Invalid email.";
            return false;
        }
        int dotIndex = input.IndexOf('.', atIndex);
        if (dotIndex == -1 || dotIndex == atIndex + 1 || dotIndex == input.Length - 1)
        {
            error = "Invalid email.";
            return false;
        }
        error = "";
        return true;
    }
}
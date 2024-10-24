namespace HW5;

internal class Users
{

    public string UserName { get; set; }
    public string Password { get; private set; }
    public bool AdminAccess { get; set; }

    public Users()
    {
    }

    public Users(string username, string password)
    {
        UserName = username;
        SetPass(password);
    }

    public Users(string username, string pass, bool adminAccess)
    {
        UserName = username;
        SetPass(pass);
        AdminAccess = adminAccess;
    }

    public void SetPass(string pass)
    {
        if (ValidPass(pass))
        {
            Password = pass;
        }
        else
        {
            Console.WriteLine($"Password is Invalid!!!");
        }
    }

    public bool ValidPass(string pass)
    {
        char[] specialCharacters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '/', '\\', '<', '>', '{', '}', '[', ']', '|', '`' };

        if (string.IsNullOrWhiteSpace(pass) || pass.Length < 8 || !pass.Any(char.IsUpper) || !pass.Any(char.IsLower) || !pass.Any(char.IsDigit))
        {
            return false;
        }

        bool containsSpecialChar = false;
        foreach (char c in pass)
        {
            if (specialCharacters.Contains(c))
            {
                containsSpecialChar = true;
                break;
            }
        }

        if (!containsSpecialChar)
        {
            return false;
        }

        return true;

    }
}


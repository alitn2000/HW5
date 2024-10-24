namespace HW5;

internal class UserServices
{

    public static void ChangePass(Users user, bool isAdmin = false)
    {
        Console.Clear();
        Console.WriteLine("Enter new password:");
        string newpass = Console.ReadLine();

        if (user.ValidPass(newpass))
        {
            user.SetPass(newpass);
            Console.WriteLine("Password changed successfully.");
        }
        else
        {
            Console.WriteLine("The password you entered is invalid. Please ensure it meets the requirements.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ShowUsers(Users[] users)
    {
        Console.Clear();
        Console.WriteLine("List of Users:");
        int count = 1;
        foreach (var user in users)
        {
            if (user != null)
            {
                Console.WriteLine($" {count}. {user.UserName}");
                count++;
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

 
    public static bool LogIn(Users[] users, string username, string pass)
    {
        Console.Clear();
        foreach (var user in users)
        {
            if (user != null && username == user.UserName && pass == user.Password)
            {
                Console.WriteLine("LogIn Successful");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

                if (user.AdminAccess)
                {
                    AdminMenu(user, users);  
                }
                else
                {
                    UserMenu(user);  
                }

                return true;
            }
        }

        Console.WriteLine("UserName or Password is incorrect!!!");
        Console.WriteLine("Press any key to try again...");
        Console.ReadKey();
        Console.Clear();
        return false;
    }

   
    public static void AddNewUser(Users[] users)
    {
        Console.Clear();
        Console.WriteLine("Enter username:");
        string newUser = Console.ReadLine();

        foreach (var user in users)
        {
            if (user != null && user.UserName.ToLower() == newUser.ToLower())
            {
                Console.WriteLine("User with this username already exists. Please try a different username.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }

        Console.WriteLine("Enter password:");
        string newPass = Console.ReadLine();

        if (!new Users().ValidPass(newPass))
        {
            Console.WriteLine("The password you entered is invalid. Please ensure it meets the requirements.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == null)
            {
                users[i] = new Users(newUser, newPass);
                Console.WriteLine("New user added successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }

        Console.WriteLine("Array is full, cannot add more users.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // منوی ادمین
    public static void AdminMenu(Users admin, Users[] users)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Change My Password");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddNewUser(users);
                    break;
                case 2:
                    ShowUsers(users);
                    break;
                case 3:
                    ChangePass(admin, true);  
                    break;
                case 4:
                    exit = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }

    // منوی کاربر عادی
    public static void UserMenu(Users user)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("User Menu:");
            Console.WriteLine("1. Change Password");
            Console.WriteLine("2. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ChangePass(user);  
                    break;
                case 2:
                    exit = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}






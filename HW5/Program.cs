using HW5;

int count = 0;
Users[] users = new Users[100];

users[0] = new Users() { UserName = "admin", AdminAccess = true }; users[0].SetPass("12345!aA");
users[1] = new Users() { UserName = "u1", AdminAccess = false }; users[1].SetPass("12345!bB");
users[2] = new Users() { UserName = "u2", AdminAccess = false }; users[2].SetPass("12345!cC");
users[3] = new Users() { UserName = "u3", AdminAccess = false }; users[3].SetPass("12345!dD");
users[4] = new Users() { UserName = "u4", AdminAccess = false }; users[4].SetPass("12345!eE");

Console.WriteLine("***********************************LogIn***********************************");
Console.Write("Enter username: ");
string user = Console.ReadLine();
Console.Write("Enter password: ");
string pass = Console.ReadLine();
UserServices.LogIn(users, user, pass);


public static class UserData
{
    public static List<User> Users = new List<User>
        {
            new User{Id= 1,Name= "Admin User",Email= "admin@example.com",Password= "admin123",IsAdmin= true},
            new User{Id= 2,Name= "John Doe",Email= "john@example.com",Password= "john123",IsAdmin= false},
            new User{Id= 3,Name= "Jane Smith",Email= "jane@example.com",Password= "jane123",IsAdmin= false},
            new User{Id= 4,Name= "Alice Johnson",Email= "alice@example.com",Password= "alice123",IsAdmin= false},
            new User{Id= 5,Name= "Bob Brown",Email= "bob@example.com",Password= "bob123",IsAdmin= false}
        };
}

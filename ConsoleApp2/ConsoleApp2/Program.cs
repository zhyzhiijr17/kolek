// Клас для представлення користувача
class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void DisplayUser()
    {
        Console.WriteLine($"ID: {Id}, Ім'я: {Name}");
    }
}

// Клас для керування списком користувачів
class UserManager
{
    private List<User> users = new List<User>();
    private int nextUserId = 1;

    // Метод для додавання нового користувача
    public void AddUser(string name)
    {
        User newUser = new User(nextUserId, name);
        users.Add(newUser);
        Console.WriteLine($"Користувача з ID {nextUserId} додано.");
        nextUserId++;
    }

    // Метод для видалення користувача за ідентифікатором
    public void RemoveUser(int id)
    {
        User userToRemove = users.Find(u => u.Id == id);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            Console.WriteLine($"Користувача з ID {id} видалено.");
        }
        else
        {
            Console.WriteLine($"Користувача з ID {id} не знайдено.");
        }
    }

    // Метод для пошуку користувача за ідентифікатором
    public void FindUser(int id)
    {
        User userToFind = users.Find(u => u.Id == id);
        if (userToFind != null)
        {
            Console.WriteLine("Знайдено користувача:");
            userToFind.DisplayUser();
        }
        else
        {
            Console.WriteLine($"Користувача з ID {id} не знайдено.");
        }
    }

    // Метод для виведення всіх користувачів
    public void DisplayAllUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Список користувачів порожній.");
        }
        else
        {
            Console.WriteLine("Список усіх користувачів:");
            foreach (var user in users)
            {
                user.DisplayUser();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Додати нового користувача");
            Console.WriteLine("2. Видалити користувача за ID");
            Console.WriteLine("3. Знайти користувача за ID");
            Console.WriteLine("4. Показати всіх користувачів");
            Console.WriteLine("5. Вийти");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть ім'я користувача: ");
                    string name = Console.ReadLine();
                    userManager.AddUser(name);
                    break;

                case 2:
                    Console.Write("Введіть ID користувача для видалення: ");
                    int idToDelete = int.Parse(Console.ReadLine());
                    userManager.RemoveUser(idToDelete);
                    break;

                case 3:
                    Console.Write("Введіть ID користувача для пошуку: ");
                    int idToFind = int.Parse(Console.ReadLine());
                    userManager.FindUser(idToFind);
                    break;

                case 4:
                    userManager.DisplayAllUsers();
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Завершення програми.");
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
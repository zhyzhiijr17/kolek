// Клас для представлення завдання
class Task
{
    public int TaskId { get; private set; }
    public string Description { get; private set; }

    public Task(int taskId, string description)
    {
        TaskId = taskId;
        Description = description;
    }

    public void DisplayTask()
    {
        Console.WriteLine($"ID завдання: {TaskId}, Опис: {Description}");
    }
}

// Клас для керування списком завдань
class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextTaskId = 1;

    // Метод для додавання нового завдання
    public void AddTask(string description)
    {
        Task newTask = new Task(nextTaskId, description);
        tasks.Add(newTask);
        Console.WriteLine($"Завдання з ID {nextTaskId} додано.");
        nextTaskId++;
    }

    // Метод для видалення завдання за ідентифікатором
    public void RemoveTask(int taskId)
    {
        Task taskToRemove = tasks.Find(t => t.TaskId == taskId);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            Console.WriteLine($"Завдання з ID {taskId} видалено.");
        }
        else
        {
            Console.WriteLine($"Завдання з ID {taskId} не знайдено.");
        }
    }

    // Метод для виведення всіх завдань
    public void DisplayAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список завдань порожній.");
        }
        else
        {
            Console.WriteLine("Список усіх завдань:");
            foreach (var task in tasks)
            {
                task.DisplayTask();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Додати нове завдання");
            Console.WriteLine("2. Видалити завдання за ID");
            Console.WriteLine("3. Показати всі завдання");
            Console.WriteLine("4. Вийти");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть опис завдання: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(description);
                    break;

                case 2:
                    Console.Write("Введіть ID завдання для видалення: ");
                    int taskId = int.Parse(Console.ReadLine());
                    taskManager.RemoveTask(taskId);
                    break;

                case 3:
                    taskManager.DisplayAllTasks();
                    break;

                case 4:
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
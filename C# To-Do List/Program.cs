
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    // Task class to hold each to-do item
    class Task
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public Task(string description)
        {
            Description = description;
            IsDone = false;
        }

        public override string ToString()
        {
            return $"{(IsDone ? "[X]" : "[ ]")} {Description}";
        }
    }

    static List<Task> tasks = new List<Task>();
    static string filePath = "todoList.txt";

    static void Main(string[] args)
    {
        Console.WriteLine(1);
        // Load tasks from file on start
        LoadTasks();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Chukwuemeks's To-Do List App");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Mark a task as done");
            Console.WriteLine("4. Remove a task");
            Console.WriteLine("5. Save and Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkTaskAsDone();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    SaveTasks();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please choose a valid option.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Add a Task");
        Console.Write("Enter the task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(description));
        Console.WriteLine("Task added successfully!");
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void ViewTasks()
    {
        Console.Clear();
        Console.WriteLine("View Tasks");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void MarkTaskAsDone()
    {
        Console.Clear();
        Console.WriteLine("Mark a Task as Done");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to mark as done.");
        }
        else
        {
            ViewTasks();
            Console.Write("Enter the number of the task to mark as done: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks[index - 1].IsDone = true;
                Console.WriteLine("Task marked as done!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void RemoveTask()
    {
        Console.Clear();
        Console.WriteLine("Remove a Task");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
        }
        else
        {
            ViewTasks();
            Console.Write("Enter the number of the task to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void SaveTasks()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.Description}|{task.IsDone}");
            }
        }
        Console.WriteLine("Tasks saved successfully!");
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    var task = new Task(parts[0]) { IsDone = bool.Parse(parts[1]) };
                    tasks.Add(task);
                }
            }
        }
    }
}


//List<string> ToDoLists = new List<string>();
//int editNum = 0;

//while (editNum != 7)
//{
//    Console.WriteLine(" Todolist " +
//    "\n Enter 1: if you want to add to the list " +
//    "\n Enter 2: if you want to delete from the list" +
//    "\n Enter 3: if you want to view the whole list " +
//    "\n Enter 4: if you want to checkoff an item on the list" +
//    "\n Enter 5: if you want to clear the list  " +
//    "\n Enter 6 : if you want to change an item on the list" +
//    "\n Enter 7: if you want to close the app");
//    Console.WriteLine();

//    try
//    {

//        editNum = Convert.ToInt32(Console.ReadLine());
//        Console.WriteLine();
//        Console.Clear();

//        {
//            if (editNum == 1)
//            {
//                for (int i = 0; i < ToDoLists.Count; i++)
//                {
//                    int aNum = i + 1;
//                    Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                }

//                Console.WriteLine(" \n What do you want to add to the list? ");
//                string addToList = Console.ReadLine();
//                if (!ToDoLists.Contains(addToList))
//                {
//                    ToDoLists.Add(addToList);
//                    for (int i = 0; i < ToDoLists.Count; i++)
//                    {
//                        int aNum = i + 1;
//                        Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                    }


//                }
//                else
//                {
//                    Console.WriteLine("item already exists");
//                }
//                Console.WriteLine();
//            }
//            else if (editNum == 2)
//            {
//                for (int i = 0; i < ToDoLists.Count; i++)
//                {
//                    int aNum = i + 1;
//                    Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                }
//                Console.WriteLine("\n What number do you want to delete from the list");
//                int deleteFromList = Convert.ToInt32(Console.ReadLine());

//                if (ToDoLists.Count >= deleteFromList)
//                {

//                    ToDoLists.RemoveAt(deleteFromList - 1);

//                    for (int i = 0; i < ToDoLists.Count; i++)
//                    {
//                        int aNum = i + 1;
//                        Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                    }


//                }
//                else
//                {
//                    Console.WriteLine(" item not found");
//                }
//                Console.WriteLine();

//            }
//            else if (editNum == 3)
//            {


//                if (ToDoLists.Count != 0)
//                {

//                    for (int i = 0; i < ToDoLists.Count; i++)
//                    {
//                        int aNum = i + 1;
//                        Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                    }
//                }
//                else
//                {
//                    Console.WriteLine("list is empty");
//                }

//            }
//            else if (editNum == 4)
//            {
//                for (int i = 0; i < ToDoLists.Count; i++)
//                {
//                    int aNum = i + 1;
//                    Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                }
//                Console.WriteLine("\nWhat number do you want to checkoff ?");
//                int checkOffList = Convert.ToInt32(Console.ReadLine());

//                if (ToDoLists.Count >= checkOffList && checkOffList > 0)
//                {
//                    if (!ToDoLists[checkOffList - 1].Contains(" #Done"))
//                    {
//                        ToDoLists[checkOffList - 1] += (" #Done");
//                    }
//                    else
//                    {
//                        Console.WriteLine(" item has been marked already");
//                    }



//                    for (int i = 0; i < ToDoLists.Count; i++)
//                    {
//                        int aNum = i + 1;
//                        Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                    }

//                }
//                else
//                {
//                    Console.WriteLine(" item not found");
//                }
//                Console.WriteLine();

//            }
//            else if (editNum == 5)
//            {
//                ToDoLists.Clear();
//                Console.WriteLine();
//            }
//            else if (editNum == 6)
//            {
//                for (int i = 0; i < ToDoLists.Count; i++)
//                {
//                    int aNum = i + 1;
//                    Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                }
//                Console.WriteLine("\n What number do you want to change on the list");
//                int changeOnList = Convert.ToInt32(Console.ReadLine());

//                if (ToDoLists.Count >= changeOnList && changeOnList > 0)
//                {
//                    Console.WriteLine("\n Enter new item: ");
//                    string newItem = Console.ReadLine();

//                    if (!ToDoLists.Contains(newItem))
//                    {
//                        ToDoLists[changeOnList - 1] = newItem;

//                        for (int i = 0; i < ToDoLists.Count; i++)
//                        {
//                            int aNum = i + 1;
//                            Console.WriteLine(aNum + " : " + ToDoLists[i]);

//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("item already exists");
//                    }


//                }
//                else
//                {
//                    Console.WriteLine(" item not found");
//                }
//                Console.WriteLine();

//            }

//            else
//            {
//                editNum = 7;
//                Console.WriteLine(" Thanks for Using the Todolist app \n Good Bye");
//            }
//            Console.WriteLine();

//        }



//    }
//    catch
//    {

//        Console.WriteLine("Enter only numbers between 1 and 7");
//        Console.WriteLine();
//    }
//}


//Console.ReadLine();
//}
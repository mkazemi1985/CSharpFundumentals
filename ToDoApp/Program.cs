Console.WriteLine("Hello. Wellcome to ToDo App. Please Select an Option to Continue...!");
bool isExitSelected = false;
List<string> Todos = [];

while (!isExitSelected)
{
    Console.WriteLine();
    Console.WriteLine("[S]ee all Todos");
    Console.WriteLine("[A]dd a Todo");
    Console.WriteLine("[R]emove a Todo");
    Console.WriteLine("[E]xit the App");

    char userInput = Console.ReadKey().KeyChar;


    switch (userInput)
    {
        case 'S':
        case 's':
            SeeAllToDos();
            break;
        case 'A':
        case 'a':
            addToDo();
            break;
        case 'R':
        case 'r':
            removeTodo();
            break;
        case 'E':
        case 'e':
            isExitSelected = true;
            break;
        default:
            PrintMessage("Invalid Character Please Try Again!");
            break;

    }
}

void SeeAllToDos()
{
    Console.WriteLine("ToDo items are:");
    if (Todos.Count == 0)
    {
        Console.WriteLine("There is no ToDo!");
    }

    for (int i = 0; i < Todos.Count; i++)
    {
        string? item = Todos[i];
        Console.WriteLine($"{i + 1}: {item}");
    }
}

void removeTodo()
{
    bool isValidMessage = false;
    while (!isValidMessage)
    {
        Console.WriteLine("ToDo items are:");
        if (Todos.Count == 0)
        {
            Console.WriteLine("There is no ToDo!");
        }
        Console.WriteLine("Please Select a ToDo Number for Remove:");

        SeeAllToDos();

        Console.WriteLine("Selected index is:");
        string inputIndex = Console.ReadLine();
        if (inputIndex == "")
        {
            Console.WriteLine("Invalid Index! Index can not be Empty!");
            continue;
        }
        if (int.TryParse(inputIndex, out int index))
        {
            if (index >= 1 && index <= Todos.Count)
            {
                isValidMessage = true;
                string todoForDelete = Todos[index - 1];
                Todos.RemoveAt(index - 1);
                Console.WriteLine($"ToDo Removed: {todoForDelete}");
            }
            else
            {
                Console.WriteLine("invalid Index! Index is not in correct Range.");
            }
        }
        else
        {
            Console.WriteLine("invalid Index! Index Format is invalid.");
        }
    }
    

}

void addToDo()
{
    bool isValidMessage = false;

    while (!isValidMessage)
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter ToDo Message:");
        string inputMessage = Console.ReadLine();
        if (inputMessage == "")
        {
            Console.WriteLine("Invalid Message! Message can not be Empty!");
        }
        else if (Todos.Contains(inputMessage))
        {
            Console.WriteLine("Invalid Message! Message can not be Duplicate!");
        }
        else
        {
            isValidMessage = true;
            Todos.Add(inputMessage);
        }
    }
  
}

//void PrintMessage(string userInputMessage)
//{
//    Console.WriteLine("User Select: " + userInputMessage);
//}


/*if (userInput == 'S')
{
    PrintMessage("See All Todos");
}

else if (userInput == 'A')
{
    PrintMessage("Add a todo");
}

else if (userInput == 'R')
{
    PrintMessage("Remove a todo");
}

else if (userInput == 'E')
{
    PrintMessage("Exit todo app");
}

else
{
    PrintMessage("Invalid Character Please Try Again!");
}*/


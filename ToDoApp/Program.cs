Console.WriteLine("Hello. Wellcome to ToDo App. Please Select an Option to Continue...!");
bool isExitSelected = false;
List<string> todos = [];

while (!isExitSelected)
{
    Console.WriteLine();
    Console.WriteLine("[S]ee all Todos");
    Console.WriteLine("[A]dd a Todo");
    Console.WriteLine("[R]emove a Todo");
    Console.WriteLine("[E]xit the App");

    string userInput = Console.ReadLine();


    switch (userInput)
    {
        case "S":
        case "s":
            SeeAllToDos();
            break;
        case "A":
        case "a":
            AddToDo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        case "E":
        case "e":
            isExitSelected = true;
            break;
        default:
            Console.WriteLine("Invalid Character Please Try Again!");
            break;

    }
}

void SeeAllToDos()
{
    if (!AllowContinue())
        return;

    WriteWithWhiteSpace("ToDo items are:");
  

    for (int i = 0; i < todos.Count; i++)
    {
        string? item = todos[i];
        Console.WriteLine($"{i + 1}: {item}");
    }
}

void AddToDo()
{
    string inputMessage = string.Empty;
    do
    {
        WriteWithWhiteSpace("Please Enter ToDo Message:");
        inputMessage = Console.ReadLine();
    } while (!IsValidMessage(inputMessage));
    todos.Add(inputMessage);

}

bool IsValidMessage(string message)
{
   
    bool isValid = true;
    if (message == "")
    {
        Console.WriteLine("Invalid Message! Message can not be Empty!");
        isValid = false;
    }
    else if (todos.Contains(message))
    {
        Console.WriteLine("Invalid Message! Message can not be Duplicate!");
        isValid =  false;
    }
    return isValid;
}

void RemoveTodo()
{
    if (!AllowContinue())
    {
        return;
    }

    while (true)
    {
        WriteWithWhiteSpace("Please select a ToDo number to remove:");

        SeeAllToDos();

        Console.Write("Enter the index of the ToDo you want to remove: ");
        string inputIndex = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputIndex))
        {
            Console.WriteLine("Invalid input! Index cannot be empty or whitespace.");
            continue;
        }

        if (!int.TryParse(inputIndex, out int index))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer.");
            continue;
        }

        if (index < 1 || index > todos.Count)
        {
            Console.WriteLine($"Invalid index! Please enter a number between 1 and {todos.Count}.");
            continue;
        }

        string todoForDelete = todos[index - 1];
        todos.RemoveAt(index - 1);
        Console.WriteLine($"ToDo removed: {todoForDelete}");
        break;
    }
}


bool AllowContinue()
{
    if (todos.Count == 0)
    {
        WriteWithWhiteSpace("There is no ToDo!");
        return false;
    }
    else
    {
        return true;
    }
}

void WriteWithWhiteSpace(string text)
{
    Console.WriteLine();
    Console.WriteLine(text);
}



//Code before Improvement

//void RemoveTodo()
//{
//    if (!AllowContinue())
//    {
//        return;
//    }

//    bool isValidMessage = false;
//    while (!isValidMessage)
//    {

//        WriteWithWhiteSpace("Please Select a ToDo Number for Remove:");

//        SeeAllToDos();

//        Console.WriteLine("Selected index is:");
//        string inputIndex = Console.ReadLine();
//        if (inputIndex == "")
//        {
//            Console.WriteLine("Invalid Index! Index can not be Empty!");
//            continue;
//        }
//        if (int.TryParse(inputIndex, out int index))
//        {
//            if (index >= 1 && index <= todos.Count)
//            {
//                isValidMessage = true;
//                string todoForDelete = todos[index - 1];
//                todos.RemoveAt(index - 1);
//                Console.WriteLine($"ToDo Removed: {todoForDelete}");
//            }
//            else
//            {
//                Console.WriteLine("invalid Index! Index is not in correct Range.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("invalid Index! Index Format is invalid.");
//        }
//    }


//}

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


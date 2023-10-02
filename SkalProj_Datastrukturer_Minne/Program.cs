using Microsoft.VisualBasic;
using System;
using System.Collections;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            string input;
            List<string> theList = new List<string>();
            do
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting \n(+, -, Q/q) of your choice"
                    + "\n+: As the first character to add an element to list(like '+Adam')"
                    + "\n-: As the first character to remove an element from list(like '-Adam')"
                    + "\nQ/q: Return to main menu");
                Console.WriteLine(new string('=', 30));

                Console.WriteLine(theList.Count == 0 ? "At the beginning\nCount: 0\nCapacity: 0" : $"Count: {theList.Count}\nCapacity: {theList.Capacity}");

                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    char nav = Char.ToLower(input[0]);
                    string value = input.Substring(1);
                    if (input.ToLower() != "q")
                    {
                        switch (nav)
                        {
                            case '+':
                                {
                                    theList.Add(value);
                                    break;
                                }
                            case '-':
                                {
                                    if (theList.Remove(value))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"To be able to remove '{value}' from the list, first you have to add it to the list. ");
                                        goto default;
                                    }
                                }
                            default:
                                Console.WriteLine("The value you entered is not valid! Press a key!");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You have to enter a valid input! Press a key!");
                    Console.ReadKey();
                    continue;
                }

            } while (input.ToLower() != "q");

            Console.Clear();
        }

        /*
            2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            Svar: Storlek är antingen mindre än eller lika med kapacitet. 
            Till exempel, när man lägger till element i listan, om storlek överskrider kapaciteten, flyttas kapaciteten automatiskt till en övre gräns.

            3. Med hur mycket ökar kapaciteten?
            Svar: 
            Om det inte finns någon förutbestämd gräns:
                Den initiala kapaciteten är 0. När det första elementet läggs till ökar kapaciteten till 4.
                Så snart storleken överstiger 4 fördubblas kapaciteten till 8. 
                När antalet överstiger 8 fördubblas det till 16 och så vidare.

            Om det finns en förutbestämd kapacitet (Till exempel:5):
                I detta fall ökar antalet tills det når den förutbestämda kapaciteten. 
                När den överskrider kapaciteten fördubblas kapaciteten (Till exempel: 5*2 =10) igen och så vidare.

            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
            Svar: För att eliminera kostnaden för nya array-prototyper och kopiering av den interna arrayen, 
                  och för att kunna få en bättre prestanda.

            5. Minskar kapaciteten när element tas bort ur listan?
            Svar: När element tas bort från listan ändras inte kapaciteten. 
                  Kapaciteten kan minskas genom att anropa TrimToSize eller genom att ställa in egenskapen kapacitet explicit.

            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            Svar: När man lägger till eller tar bort data är det inte nödvändigt. 
                  Även om det är viktigt att få tillgång till hastigheten till elementen. Slutligen är minnesanvändningen mindre.           
         */

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            string input;
            Queue<string> queueICA = new Queue<string>();
            do
            {
                Console.Clear();
                if (queueICA.Count != 0)
                {
                    foreach (var pers in queueICA)
                    {
                        Console.Write($"{pers} is in the queue\n");
                    }
                    Console.WriteLine(new string('=', 30));
                }

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, Q/q ) of your choice"
                   + "\n1. Enqueue"
                   + "\n2. Dequeue"
                   + "\nQ/q. Return to main menu");

                input = Console.ReadLine();


                if (input.ToLower() != "q")
                {
                    switch (input)
                    {
                        case "1":
                            {
                                Console.WriteLine("Enter the name of the person that joins the queue: ");
                                string person = Console.ReadLine();
                                queueICA.Enqueue(person);
                                Console.WriteLine($"{person} has joined the queue!");
                                break;
                            }

                        case "2":
                            {
                                if (queueICA.Count > 0)
                                {
                                    string person = queueICA.Dequeue();
                                    Console.WriteLine($"{person} was dispatched and has left the queue!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The checkout line is empty");
                                    goto default;
                                }
                            }
                        default:
                            Console.WriteLine("Please choice a valid option! Press a key!");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input.ToLower() != "q");
            Console.Clear();
        }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, Q/q ) of your choice"
                   + "\n1. Reverse the text"
                   + "\nQ/q. Return to main menu");

                input = Console.ReadLine();

                if (input.ToLower() != "q")
                {
                    switch (input)
                    {
                        case "1":
                            {
                                Console.WriteLine("Enter your text to see it in reverse order: ");
                                string inputText = Console.ReadLine();
                                char[] charArr = inputText.ToCharArray();
                                int sizeOfInputText = charArr.Length;
                                Stack stack = new Stack(sizeOfInputText);

                                int i;
                                for (i = 0; i < sizeOfInputText; ++i)
                                {
                                    stack.Push(inputText[i]);
                                }

                                for (i = 0; i < sizeOfInputText; ++i)
                                {
                                    charArr[i] = (char)stack.Pop();
                                }
                                Console.WriteLine(new string(charArr));
                                Console.WriteLine("Please Press a key!");
                                Console.ReadKey();
                                break;
                            }
                        default:
                            Console.WriteLine("Please choice a valid option! Press a key!");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input.ToLower() != "q");
            Console.Clear();

            /* 1.Simulera ännu en gång ICA-kön på papper. Denna gång med en stack.Varför är det inte så smart att använda en stack i det här fallet?
               Svar: Ingen kommer att acceptera en verklighet där den första personen i kö är den sista som ska behandlas. 
                     Det kommer inte att vara kompatibelt med det verkliga livet.          
             */
        }



        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the parenthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, Q/q ) of your choice"
                   + "\n1. Check the paranthesis"
                   + "\nQ/q. Return to main menu");

                input = Console.ReadLine();

                if (input.ToLower() != "q")
                {
                    switch (input)
                    {
                        case "1":
                            {
                                Console.WriteLine("Enter your text to see whether it is a well-formed text or not: ");
                                string inputText = Console.ReadLine();

                                Stack<char> stack = new Stack<char>();
                                Stack<char> stack2 = new Stack<char>();
                                Queue<char> queue = new Queue<char>();
                                if (inputText.Length > 1)
                                {
                                    foreach (char ch in inputText)
                                    {
                                        if (OpeningParanthesis(ch))
                                        {
                                            stack.Push(ch);
                                        }
                                        else if (ClosingParanthesis(ch))
                                        {
                                            queue.Enqueue(ch);
                                            stack2.Push(ch);
                                        }
                                    }
                                    Console.WriteLine(IsSame(stack, stack2, queue) ? "The string is well-formed" : "The string is not well-formed");
                                    Console.WriteLine("Press a key!");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                    break;
                                }


                                bool OpeningParanthesis(char ch)
                                {
                                    return ch == '(' || ch == '{' || ch == '[';
                                }

                                bool ClosingParanthesis(char ch)
                                {
                                    return ch == ')' || ch == '}' || ch == ']';
                                }

                                bool IsSame(Stack<char> stack, Stack<char> stack2, Queue<char> queue)
                                {

                                    if (stack.Count != queue.Count || stack.Count == 0) { return false; }


                                    while (stack.Count != 0)
                                    {
                                        if ((stack.Peek() == '(' && queue.Peek() == ')') || (stack.Peek() == '{' && queue.Peek() == '}') || (stack.Peek() == '[' && queue.Peek() == ']') ||
                                            (stack.Peek() == '(' && stack2.Peek() == ')') || (stack.Peek() == '{' && stack2.Peek() == '}') || (stack.Peek() == '[' && stack2.Peek() == ']'))
                                        {
                                            stack.Pop();
                                            stack2.Pop();
                                            queue.Dequeue();
                                            continue;
                                        }
                                        else { return false; }
                                    }
                                    return true;
                                }

                            }
                        default:
                            Console.WriteLine("Please choice a valid option! Press a key!");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input.ToLower() != "q");
            Console.Clear();

            /* 1.Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper.
                 Du ska använda dig av någon eller några av de datastrukturer vi precis gått igenom.Vilken datastruktur använder du?
               Svar: Jag använde både stack och queue för att täcka alla situationer.
            */
        }


        /*  Frågor & Svar:
            1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion?
            Svar: Så här fungerar stack och heap, baserat på ett exempel:
                  Value type:  
                    int firstNum = 1; // Value type
                    int secondNum = firstNum; // Creates a copy of the value
                    secondNum = 2; // firstNum remains unchanged. 

                    Console.WriteLine($"First Number = {firstNum}");
                    Console.WriteLine($"Second Number = {secondNum}");

                Output:
                    First Number = 1
                    Second Number = 2
                Som vi kan se resultatet fungerar båda variablerna oberoende av varandra.


                Reference type:
                Om vi tilldelar en referenstypsvariabel till en annan, eftersom referenstypsvariablerna representerar variabelns adress, 
                kopieras referensen och båda variablerna pekar på samma plats på högen.

                    class Employee
                    {
                        public string FirstName { get; set; }
                    }

                    static void Main(string[] args)
                    {
                        Employee bethany = new Employee { FirstName = "Bethany"}; // Reference type
                        Employee john = bethany; // Creates a new reference to the same object on the stack.
                        john.FirstName = "John"; // Modifies the object shared by 'bethany' and 'john'

                        Console.WriteLine($"Bethany's name: {bethany.FirstName} \nJohn's name: {john.FirstName}");
                    }

                Output:
                    Bethany's name: John
                    John's name: John
                Nu ser vi att Bethanys namn också ändras.



            2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
            Svar:
                Value Types är en datatyp som håller data inom sin egen minnesallokering medan Reference Types lagrar en referens till sina data.
                Förutom nyckelskillnaden i definition finns det följande skillnader mellan dem.
                    1. Värdetyper kan inte ärvas, medan referenstyper kan.
                    2. Reference Types går alltid till heap, medan Value Types alltid går där de deklarerades.
                    3. Value Types ger effektiv minnesanvändning, medan Reference Types erbjuder flexibilitet och stöder komplexa datastrukturer.



            3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den
            andra returnerar 4, varför?
            Svar: 
                 Den första:
                    public int ReturnValue() 
                    {
                        int x = new int(); // It is the same as: int x = 0;
                        x = 3;  // Assign 3 to x
                        int y = new int(); //It is the same as: int y = 0;
                        y = x; // y = 3 & x = 3
                        y = 4; // y = 4 & x = 3 
                        return x;
                    }
            Så "new" betyder inte "skapa objekt på Heap" - det antyder bara "call the constructer of int class". 
            För Value Types skapar det inte en ny objekt, initierar det bara ett nytt värde.

                 Den andra:
                     public int ReturnValue2()   
                    {
                        MyInt x = new MyInt(); // It creates new instance of MyInt class that is a reference type. So data will be located on the heap, but the pointer will be located on the stack.
                        x.MyValue = 3; // 3 is assigned to x.MyValue that is stored on the heap.
                        MyInt y = new MyInt(); // This creates a new instance of MyInt class, y will be the pointer that is located on the stack and the data will be located on the heap.
                        y = x; //  Now, y and x refer to the same object.
                        y.MyValue = 4; // 4 is assigned to the MyValue of the same object.
                        return x.MyValue; // So MyValue of the same object will be 4.
                    }
            Dessa typer av tilldelningar kan resultera i oväntade beteenden i referenstyper med avseende på värdetyper.

        */
    }
}


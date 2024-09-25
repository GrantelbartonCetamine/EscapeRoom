using System;
class EscapeRoom
{
    static int height;
    static int width;
    enum ObjectType
    {
        Ground,
        Wall,
        Player,
        Door,
        Key,
    }
    static ObjectType[,] mapArray;
    static void Main()
    {
        PlayerGreeting();
        HandleMapSize();
        InitialzeMap();
        SetPlayertoMap();
        PrintMap();
        DetectWalls();
        HandlePlayerMovement();
    }
    static void PlayerGreeting()
    {
        Console.WriteLine("This is a EscapeRoom \nThe Goal is to find the Exit");
    }
    static void HandleMapSize()
    {
        {
            Console.WriteLine("Before you can Play Enter youre Prefered Map Size Recomended size : (20,20)");
            Console.WriteLine("Height : ");
            string UserInput = Console.ReadLine();
            if (!int.TryParse(UserInput, out height) || height < 0)
            {
                Console.WriteLine("Sorry Invalid Input , try small Integer");
            }
            else
            {
                Console.WriteLine($"Set Map Height to {height}");
            }
            Console.WriteLine("Width : ");
            string WidthUserInput = Console.ReadLine();
            if (!int.TryParse(WidthUserInput, out width) || width < 0)
            {
                Console.WriteLine("Please Enter a Valid Width");
            }
            Console.Clear();
            Console.WriteLine($"Set Map Size to {width} , {height} ");
        }
    }
    static void SetPlayertoMap()
    {
        mapArray[2, 2] = ObjectType.Player;
    }
    static void InitialzeMap()
    {
        mapArray = new ObjectType[height, width];
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                mapArray[x, y] = 0;
            }
        }
    }
    static void DetectWalls()
    {
        if (mapArray[height - 1, 0] == ObjectType.Wall)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" ");
            Console.ResetColor();
        }
    }
    static void PrintMap()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                switch (mapArray[x, y])
                {
                    case ObjectType.Ground:
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.ResetColor();
                        break;
                    case ObjectType.Player:
                        Console.Write("P");
                        break;
                    case ObjectType.Wall:
                        DetectWalls();
                        break;
                    case ObjectType.Door:
                        break;
                    case ObjectType.Key:
                        break;
                }
            }
            Console.WriteLine();
        }
    }
    static void HandlePlayerMovement()
    {
        Console.Write("You can Press W for going Forward\nA for going Left\nS for going Back \nAnd D for going to the Right");
        Console.WriteLine("\nOr you can use Numpad or Arrow buttons");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        while (true)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.A:
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.S:
                    break;
                case ConsoleKey.W:
                    break;
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.NumPad2:
                    break;
                case ConsoleKey.NumPad8:
                    break;
                case ConsoleKey.NumPad6:
                    break;
            }
        }
    }
}
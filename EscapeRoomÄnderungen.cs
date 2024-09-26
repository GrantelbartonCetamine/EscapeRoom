using System;
class EscapeRoom
{
    static int height;
    static int width;
    static int PlayerX = 2;
    static int PlayerY = 2;
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
        }
        Console.WriteLine($"Set Map Size to {width} , {height} ");

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
                if (x == 0 || x == height - 1 || y == 0 || y == width - 1)
                {
                    mapArray[x, y] = ObjectType.Wall;
                }
                else
                {

                    mapArray[x, y] |= ObjectType.Ground;
                }

            }
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
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                        Console.ResetColor();
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

    static void PlayerMoved(int PlayerX, int PlayerY, int HorizontalX, int VerticalY)
    {
        int newPlayerPositionX = PlayerX + HorizontalX;
        int newPlayerPositionY = PlayerY + VerticalY;

        if (newPlayerPositionX >= 0 && newPlayerPositionX <= width &&
            newPlayerPositionY >= 0 && newPlayerPositionY <= height &&
            mapArray[newPlayerPositionX, newPlayerPositionY] != ObjectType.Wall)
        {
            mapArray[PlayerX, PlayerY] = ObjectType.Ground;

            PlayerX = newPlayerPositionX;
            PlayerY = newPlayerPositionY;
            mapArray[PlayerX, PlayerY] = ObjectType.Player;


        }
    }
    static void HandlePlayerMovement()
    {
        Console.Write("You can Press W for going Forward\nA for going Left\nS for going Back \nAnd D for going to the Right");
        Console.WriteLine("\nOr you can use Numpad or Arrow buttons");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.NumPad4:
                    PlayerMoved(PlayerX, PlayerY, -1, 0);
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.W:
                    PlayerMoved(PlayerX, PlayerY, 0, +1);
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                case ConsoleKey.D:
                    PlayerMoved(PlayerX, PlayerY, +1, 0);
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.S:
                    PlayerMoved(PlayerX, PlayerY, +1, 0);
                    break;
            }
            Console.Clear();
            PrintMap();
        }
    }
}

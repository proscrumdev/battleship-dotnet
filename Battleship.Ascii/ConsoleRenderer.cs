using System;
using Battleship.GameController.Contracts;

namespace Battleship.Ascii;

public class ConsoleRenderer
{
    private string _separator = "---------------------";
    public virtual void Render(ConsoleColor color, Action textWritter)
    {
        var currentForeground = Console.ForegroundColor;
        Console.ForegroundColor = color;
        textWritter();
        Console.ForegroundColor = currentForeground;
    }

    public virtual void RenderLine(ConsoleColor color, string text)
    {
        Render(color, () => Console.WriteLine(text));
    }

    public virtual void Render(ConsoleColor color, string text)
    {
        Render(color, () => Console.Write(text));
    }

    public virtual void RenderCannon()
    {
        Render(ConsoleColor.DarkMagenta, () =>
        {
            Console.WriteLine("                  __");
            Console.WriteLine(@"                 /  \");
            Console.WriteLine("           .-.  |    |");
            Console.WriteLine(@"   *    _.-'  \  \__/");
            Console.WriteLine(@"    \.-'       \");
            Console.WriteLine("   /          _/");
            Console.WriteLine(@"  |      _  /""");
            Console.WriteLine(@"  |     /_\'");
            Console.WriteLine(@"   \    \_/");
            Console.WriteLine(@"    """"""""");
        });
    }

    public virtual void RenderExplosion(string message)
    {
        Render(ConsoleColor.Red, () =>
        {
            Console.Beep();
            Console.WriteLine(message);
            Console.WriteLine(@"                \         .  ./");
            Console.WriteLine(@"              \      .:"";'.:..""   /");
            Console.WriteLine(@"                  (M^^.^~~:.'"").");
            Console.WriteLine(@"            -   (/  .    . . \ \)  -");
            Console.WriteLine(@"               ((| :. ~ ^  :. .|))");
            Console.WriteLine(@"            -   (\- |  \ /  |  /)  -");
            Console.WriteLine(@"                 -\  \     /  /-");
            Console.WriteLine(@"                   \  \   /  /");
        });
    }

    public virtual void RenderMiss(string message)
    {
        Render(ConsoleColor.Blue, () =>
        {
            Console.Beep();
            Console.WriteLine(message);
            Console.WriteLine(@"                ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"              ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"              ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"                 ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"               ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"            ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"                 ~~~~~~~~~~~~~~~~~");
            Console.WriteLine(@"                   ~~~~~~~~~~~~~~~~~");
        });
    }

    public virtual void RenderLandingScreen()
    {
        Render(ConsoleColor.Green, () =>
        {
            Console.WriteLine("                                     |__");
            Console.WriteLine(@"                                     |\/");
            Console.WriteLine("                                     ---");
            Console.WriteLine("                                     / | [");
            Console.WriteLine("                              !      | |||");
            Console.WriteLine("                            _/|     _/|-++'");
            Console.WriteLine("                        +  +--|    |--|--|_ |-");
            Console.WriteLine(@"                     { /|__|  |/\__|  |--- |||__/");
            Console.WriteLine(@"                    +---------------___[}-_===_.'____                 /\");
            Console.WriteLine(@"                ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _");
            Console.WriteLine(@" __..._____--==/___]_|__|_____________________________[___\==--____,------' .7");
            Console.WriteLine(@"|                        Welcome to Battleship                         BB-61/");
            Console.WriteLine(@" \_________________________________________________________________________|");
        });
    }

    public virtual void RenderStartRound(int round)
    {
        Render(ConsoleColor.Magenta, () =>
        {
            Console.WriteLine($"================ROUND {round}===================");
        });
    }

    public virtual Position AskPlayerForPosition()
    {
        Render(ConsoleColor.Yellow, () =>
        {
            Console.WriteLine(_separator);
            Console.WriteLine("Player, it's your turn");
            Console.Write("Enter coordinates for your shot: ");
        });
        var position = ParsePosition(Console.ReadLine());
        Render(ConsoleColor.Yellow, () =>
        {
            Console.WriteLine(_separator);
        });
        return position;
    }

    public static Position ParsePosition(string input)
    {
        var letter = (Letters)Enum.Parse(typeof(Letters), input.ToUpper().Substring(0, 1));
        var number = int.Parse(input.Substring(1, 1));
        return new Position(letter, number);
    }
}

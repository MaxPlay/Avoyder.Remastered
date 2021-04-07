using System;

namespace Avoyder.Remastered
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameCore())
                game.Run();
        }
    }
}

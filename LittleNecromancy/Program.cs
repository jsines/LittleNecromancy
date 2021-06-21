using System;

namespace LittleNecromancy
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LittleNecromancy())
                game.Run();
        }
    }
}

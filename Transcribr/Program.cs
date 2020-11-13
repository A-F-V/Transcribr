using System;
using Dash;

namespace Transcribr
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleMenu welcome = new ConsoleMenu(), mainMenu = new ConsoleMenu(), converter = new ConsoleMenu();

            var pc = new PastelConsole(ColourPalette.MarineFields);

            welcome.SetDetails(new[] {"Welcome"}, new Action[] {() => WishWelcome(pc)},
                new[] {mainMenu});
            mainMenu.SetDetails(new[] {"Convert Panopto", "Done"}, new Action[] {() => CaptionConverter.PanoptoRun(pc), null},
                new[] {mainMenu, new ConsoleMenu()});


            pc.SetStartingMenu(welcome);
            pc.Run();
        }

        private static void WishWelcome(PastelConsole pc)
        {
            pc.FormatWriteLine("{-3} - {-2}", "Welcome to Transcribr",
                "A tool for converting different auto-captioned slides to notes.");
            pc.WriteEmpty();
        }
    }
}
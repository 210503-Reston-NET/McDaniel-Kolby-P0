using CSDL;
using CSBL;

namespace CSUI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            switch (menuType.ToLower())
            {
                case "welcome":
                    return new WelcomeMenu();
                case "main":
                    return new MainMenu(new ColorBL(new RepoFile()));
                default:
                    return null;
            }
        }

    }
}
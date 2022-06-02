using System;
using UI;
using Unity.Collections.LowLevel.Unsafe;

namespace Sanity
{
    public class PlayerInstance
    {
        public readonly MenuController MainMenu;
        public readonly AboutController AboutScreen;
        
        public PlayerInstance(MenuController mainMenu, AboutController about)
        {
            this.MainMenu = mainMenu;
            this.AboutScreen = about;
        }
    }
}
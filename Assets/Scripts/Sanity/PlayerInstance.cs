using System;
using UI;
using Unity.Collections.LowLevel.Unsafe;

namespace Sanity
{
    public class PlayerInstance
    {
        public readonly MenuController MainMenu;
        public readonly AboutController AboutScreen;
        public readonly HudController Hud;
        
        public PlayerInstance(MenuController mainMenu, AboutController about, HudController hud)
        {
            this.MainMenu = mainMenu;
            this.AboutScreen = about;
            this.Hud = hud;
        }
    }
}
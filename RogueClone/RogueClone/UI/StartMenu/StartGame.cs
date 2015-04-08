namespace RogueClone.UI.StartMenu
{
    using System.Collections.Generic;

    public class StartGame : Menu
    {
        public StartGame()
            : base(new List<string> { GlobalMenuOptions.WishMessage })
        {
        }
    }
}

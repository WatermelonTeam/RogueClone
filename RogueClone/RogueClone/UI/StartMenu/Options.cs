using System.Collections.Generic;
namespace RogueClone.UI.StartMenu
{
    public class Options : Menu
    {
        public Options()
            : base(new List<string> {
                GlobalMenuOptions.TweakSomething, 
                GlobalMenuOptions.TweakSomethingElse, 
                GlobalMenuOptions.ChangeAnOption, 
                GlobalMenuOptions.BackToMainMenu })
        { }
    }
}

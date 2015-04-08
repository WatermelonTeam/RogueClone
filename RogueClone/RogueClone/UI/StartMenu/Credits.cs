namespace RogueClone.UI.StartMenu
{
    using System.Collections.Generic;

    public class Credits : Menu
    {
        public Credits()
            : base(new List<string> { 
                GlobalMenuOptions.ReasonForCreation, 
                GlobalMenuOptions.TeamMembers, 
                GlobalMenuOptions.BackToMainMenu})
        { }
    }
}

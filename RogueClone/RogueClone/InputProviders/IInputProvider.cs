namespace RogueClone.InputProviders
{
    using RogueClone.Common;
    using System;

    public interface IInputProvider
    {

        Move GetNextPlayerMove(Hero hero);
    }
}

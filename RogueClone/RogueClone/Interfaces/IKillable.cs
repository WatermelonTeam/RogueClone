namespace RogueClone
{
    using System;

    public interface IKillable
    {
        event EventHandler Dead;
    }
}
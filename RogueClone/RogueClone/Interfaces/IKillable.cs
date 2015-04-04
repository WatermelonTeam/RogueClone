namespace RogueClone
{
    using System;

    public interface IKillable
    {
        event EventHandler Death;

        void Die();
    }
}
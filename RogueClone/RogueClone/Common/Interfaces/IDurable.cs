namespace RogueClone
{
    public interface IDurable
    {
        int MaxDurability
        {
            get;
            set;
        }

        int CurrentDurability
        {
            get;
            set;
        }
    }
}

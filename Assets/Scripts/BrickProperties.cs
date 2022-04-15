public class BrickProperties
{
    public int Durability;
    public readonly int Score;
    public readonly float BonusChance;

    public BrickProperties(int durability, int score, float bonusChance)
    {
        this.Durability = durability;
        this.Score = score;
        this.BonusChance = bonusChance;
    }
}

/// <summary>
/// Stores the brick properties.
/// </summary>
public class BrickProperties
{
    public int Durability;
    public readonly int Score;

    public BrickProperties(int durability, int score)
    {
        this.Durability = durability;
        this.Score = score;
    }
}

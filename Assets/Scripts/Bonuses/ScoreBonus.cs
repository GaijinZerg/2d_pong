using UnityEngine;

/// <summary>
/// Specifies score bonus properties.
/// </summary>
public class ScoreBonus : MonoBehaviour, IBonusInterface
{
    private readonly int _bonusType = 1;

    public int ReturnBonusType()
    {
        return _bonusType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

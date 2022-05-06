using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class SpeedUpBonus : MonoBehaviour, IBonusInterface
{
    private readonly int _bonusType = 3;

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

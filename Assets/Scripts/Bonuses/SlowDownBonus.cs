using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class SlowDownBonus : MonoBehaviour, IBonusInterface
{
    private readonly int _bonusType = 4;

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

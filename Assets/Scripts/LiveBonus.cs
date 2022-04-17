using UnityEngine;

/// <summary>
/// Specifies live bonus properties.
/// </summary>
public class LiveBonus : MonoBehaviour, IBonusInterface
{
    private readonly int _bonusType = 2;

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

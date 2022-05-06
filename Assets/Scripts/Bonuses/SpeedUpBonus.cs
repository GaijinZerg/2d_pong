using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class SpeedUpBonus : MonoBehaviour, IBonusInterface
{
    private readonly int _bonusType = 3;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }

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

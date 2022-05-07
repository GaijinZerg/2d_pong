using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class CharacterBonus : MonoBehaviour, IBonusInterface
{
    [SerializeField] private Sprite[] sprites;
    private int _bonusType = 5;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
        _bonusType += Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_bonusType - 5];
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

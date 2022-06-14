using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class CharacterBonus : BonusParent
{
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        _bonusType = 5;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
        _bonusType += Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_bonusType - 5];
    }
}

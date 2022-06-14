using UnityEngine;

/// <summary>
/// Specifies live bonus properties.
/// </summary>
public class LifeBonus : BonusParent
{
    private void Start()
    {
        _bonusType = 2;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }
}

using UnityEngine;

/// <summary>
/// Specifies speed up bonus properties.
/// </summary>
public class SpeedUpBonus : BonusParent
{
    private void Start()
    {
        _bonusType = 3;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }
}

using UnityEngine;

/// <summary>
/// Specifies score bonus properties.
/// </summary>
public class ScoreBonus : BonusParent
{
    private void Start()
    {
        _bonusType = 1;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }
}

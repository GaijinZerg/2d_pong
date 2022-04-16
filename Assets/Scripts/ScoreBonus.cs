using UnityEngine;
public class ScoreBonus : MonoBehaviour, IBonusInterface
{
    private readonly int bonusType = 1;
    public int ReturnBonusType()
    {
        return bonusType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

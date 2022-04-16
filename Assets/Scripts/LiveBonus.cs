using UnityEngine;
public class LiveBonus : MonoBehaviour, IBonusInterface
{
    private readonly int bonusType = 2;
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

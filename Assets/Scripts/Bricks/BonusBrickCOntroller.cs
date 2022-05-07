using UnityEngine;

/// <summary>
/// Provides unique functions for the soft brick.
/// </summary>
public class BonusBrickController : Brick, IBrickInterface
{
    BrickProperties properties = new(1, 100);
    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 0)
        {
            _ = Instantiate(splashPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            BonusAction(gameObject);
            Destroy(gameObject);
        }
    }

    public void Catch()
    {
        // This block never falls.
    }

    private void OnDestroy()
    {
        GeneralComponent.SceneChanger();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

/// <summary>
/// Provides unique functions for the soft brick.
/// </summary>
public class SoftBrickController : Brick, IBrickInterface
{
    BrickProperties properties = new(1, 100, 0.2f);
    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 0)
        {
            _ = Instantiate(splashPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            if (properties.BonusChance > Random.Range(0f, 1f))
            {
                BonusAction(gameObject);
            }
            PlayerController.AddScore(properties.Score);
            GeneralComponent.SceneChanger(PlayerController.GetPlayerData());
            Destroy(gameObject);
        }
    }
}

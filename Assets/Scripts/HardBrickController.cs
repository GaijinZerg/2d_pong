using UnityEngine;

/// <summary>
/// Provides unique functions for the hard brick.
/// </summary>
public class HardBrickController : Brick, IBrickInterface
{
    BrickProperties properties = new(2, 400, 0.2f);
    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 1)
        {
            // We change only transparency of the sprite here.
            // We can directly input the numbers of RGB but the code below can be used in any set of RGB.
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 0.7f);
        }
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

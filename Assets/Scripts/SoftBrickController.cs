using UnityEngine;

public class SoftBrickController : Brick, IBrickInterface
{
    private GameObject player;
    private PlayerController playerController;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    BrickProperties properties = new(1, 100, 0.2f);
    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 0)
        {
            if (properties.BonusChance > Random.Range(0f, 1f))
            {
                BonusAction(gameObject);
            }
            playerController.AddScore(properties.Score);
            Destroy(gameObject);
        }
    }
}

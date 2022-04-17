using UnityEngine;

public class HardBrickController : Brick, IBrickInterface
{
    private GameObject player, generalObject;
    private General generalComponent;
    private PlayerController playerController;

    public void Start()
    {
        generalObject = GameObject.FindGameObjectWithTag("General");
        generalComponent = generalObject.GetComponent<General>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

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
            if (properties.BonusChance > Random.Range(0f, 1f))
            {
                BonusAction(gameObject);
            }
            playerController.AddScore(properties.Score);
            generalComponent.SceneChanger(playerController.GetPlayerData());
            Destroy(gameObject);
        }
    }
}

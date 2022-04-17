using UnityEngine;

public class SoftBrickController : Brick, IBrickInterface
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
            playerController.AddScore(properties.Score);
            generalComponent.SceneChanger(playerController.GetPlayerData());
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class HardBrickController : Brick, IBrickInterface
{
    private GameObject player;
    private PlayerController playerController;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    BrickProperties properties = new BrickProperties(2, 400, 0.1f);
    public void Action()
    {
        properties.Durability--;
        Debug.Log(properties.Durability);
        if (properties.BonusChance > Random.Range(0f, 1f))
        {
            BonusAction();
        }
        if (properties.Durability == 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void BonusAction()
    {
        // Bonus action.
    }

    private void OnDestroy()
    {
        playerController.AddScore(properties.Score);
    }
}

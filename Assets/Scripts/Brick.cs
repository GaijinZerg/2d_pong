using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject scoreBonusPrefab, liveBonusPrefab;
    [SerializeField] protected GameObject splashPrefab;
    protected GameObject player, generalObject;
    protected General generalComponent;
    protected PlayerController playerController;

    public void Start()
    {
        generalObject = GameObject.FindGameObjectWithTag("General");
        generalComponent = generalObject.GetComponent<General>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    protected void BonusAction(GameObject generator)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            _ = Instantiate(scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _ = Instantiate(liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}

using UnityEngine;

/// <summary>
/// Describes general brick behavior.
/// </summary>
public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject _scoreBonusPrefab, _liveBonusPrefab;
    [SerializeField] protected GameObject splashPrefab;
    protected GameObject Player, GeneralObject;
    protected General GeneralComponent;
    protected PlayerController PlayerController;

    public void Start()
    {
        GeneralObject = GameObject.FindGameObjectWithTag("General");
        GeneralComponent = GeneralObject.GetComponent<General>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
    }

    // We have two types of bonuses with equal chance but it can be adjusted.
    protected void BonusAction(GameObject generator)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            _ = Instantiate(_scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _ = Instantiate(_liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}

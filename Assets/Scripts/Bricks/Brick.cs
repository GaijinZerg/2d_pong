using UnityEngine;

/// <summary>
/// Describes general brick behavior.
/// </summary>
public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject _scoreBonusPrefab, _liveBonusPrefab, _speedUpBonusPrefab, _slowDownBonusPrefab;
    [SerializeField] protected GameObject splashPrefab;
    protected GameObject Player, GeneralObject;
    protected General GeneralComponent;
    protected PlayerController PlayerController;
    protected BoxCollider2D _collider2D;
    protected Rigidbody2D _rigidbody;

    public void Start()
    {
        GeneralObject = GameObject.FindGameObjectWithTag("General");
        GeneralComponent = GeneralObject.GetComponent<General>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
        _collider2D = gameObject.GetComponent<BoxCollider2D>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // There are several types of bonuses.
    // extra life - 5%
    // score - 65%
    // slow down - 10%
    // speed up - 10%
    // character - 10%
    protected void BonusAction(GameObject generator)
    {
        float x = Random.Range(0f, 1f);
        if (x < 0.05f)
        {
            _ = Instantiate(_liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.05f) && (x < 0.7f))
        {
            _ = Instantiate(_scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.7f) && (x < 0.8f))
        {
            _ = Instantiate(_speedUpBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.8f) && (x < 0.9f))
        {
            _ = Instantiate(_slowDownBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {

        }
    }
}

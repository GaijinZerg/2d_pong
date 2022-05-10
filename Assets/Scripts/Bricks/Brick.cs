using UnityEngine;

/// <summary>
/// Describes general brick behavior.
/// </summary>
public class Brick : MonoBehaviour
{
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
}

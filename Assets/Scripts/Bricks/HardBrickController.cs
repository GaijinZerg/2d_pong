using UnityEngine;

/// <summary>
/// Provides unique functions for the hard brick.
/// </summary>
public class HardBrickController : Brick, IBrickInterface
{
    [SerializeField] private Sprite[] sprites;
    BrickProperties properties = new(2, 400);

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        if (properties.Durability == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            _ = Instantiate(splashPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            _collider2D.isTrigger = true;
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rigidbody.gravityScale = 1;
            _rigidbody.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
        }
    }

    public void Catch()
    {
        PlayerController.AddScore(properties.Score);
        Destroy(gameObject);
    }
}

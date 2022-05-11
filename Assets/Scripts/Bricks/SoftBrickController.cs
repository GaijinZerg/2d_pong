using UnityEngine;

/// <summary>
/// Provides unique functions for the soft brick.
/// </summary>
public class SoftBrickController : Brick, IBrickInterface
{
    [SerializeField] private int blockType;
    [SerializeField] private Sprite[] sprites;
    BrickProperties properties = new(1, 100);

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[blockType];
        int score = 100;
        switch (blockType)
        {
            case 0:
                score = 100;
                break;
            case 1:
                score = 150;
                break;
            case 2:
                score = 200;
                break;
            case 3:
                score = 300;
                break;
            case 4:
                score = 400;
                break;
            case 5:
                score = 500;
                break;
            case 6:
                score = 600;
                break;
        }
        properties = new(1, score);
    }

    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 0)
        {
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

    private void OnDestroy()
    {
        GeneralComponent.SceneChanger();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

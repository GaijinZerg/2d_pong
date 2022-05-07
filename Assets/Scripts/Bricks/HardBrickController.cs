using UnityEngine;

/// <summary>
/// Provides unique functions for the hard brick.
/// </summary>
public class HardBrickController : Brick, IBrickInterface
{
    BrickProperties properties = new(2, 400);
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

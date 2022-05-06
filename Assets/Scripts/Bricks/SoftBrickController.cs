using UnityEngine;

/// <summary>
/// Provides unique functions for the soft brick.
/// </summary>
public class SoftBrickController : Brick, IBrickInterface
{
    BrickProperties properties = new(1, 100);
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
        GeneralComponent.SceneChanger(PlayerController.GetPlayerData());
    }
}

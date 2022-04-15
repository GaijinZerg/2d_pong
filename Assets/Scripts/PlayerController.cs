using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float horizontalRestriction = 6.7f;
    private readonly float playerSpeed = 100f;
    private int playerScore = 0;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        // Restrict horizontal movement of the player.
        if (Mathf.Abs(gameObject.transform.position.x) <= horizontalRestriction)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(Input.GetAxis("Mouse X") * playerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.position = new Vector2(horizontalRestriction * Mathf.Sign(gameObject.transform.position.x), gameObject.transform.position.y);
        }
    }

    public void AddScore(int add)
    {
        playerScore += add;
    }

    // This method is not necessary and can be deleted.
    public int GetScore()
    {
        return playerScore;
    }
}

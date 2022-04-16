using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab, gameOverMenu, pauseMenu, scoresText, livesText;
    private TextMeshProUGUI scoresTextMesh, livesTextMesh;
    private readonly float horizontalRestriction = 5.7f;
    private readonly float playerSpeed = 100f;
    private int playerScore = 0, lives = 3;
    private bool gameOverFlag = false;

    private void Start()
    {
        Cursor.visible = false;
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        scoresTextMesh = scoresText.GetComponent<TextMeshProUGUI>();
        scoresTextMesh.text = playerScore.ToString();
        livesTextMesh = livesText.GetComponent<TextMeshProUGUI>();
        livesTextMesh.text = lives.ToString();
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

        // Call for the pause menu.
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverFlag)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void AddScore(int add)
    {
        playerScore += add;
        scoresTextMesh.text = playerScore.ToString();
    }

    // This method is not necessary and can be deleted.
    public int GetScore()
    {
        return playerScore;
    }

    public void ChangeLivesCount(int count)
    {
        lives += count;
        livesTextMesh.text = lives.ToString();
    }

    public void GameEndController()
    {
        if (lives > 0)
        {
            _ = Instantiate(ballPrefab, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            gameOverFlag = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            gameOverMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            ProcessBonus(collision.gameObject.GetComponent<IBonusInterface>().ReturnBonusType());
        }
    }

    private void ProcessBonus(int type)
    {
        switch (type)
        {
            case 1:
                this.AddScore(500);
                break;

            case 2:
                this.ChangeLivesCount(1);
                break;

            default:
                break;
        }
    }
}

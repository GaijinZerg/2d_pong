using TMPro;
using UnityEngine;

/// <summary>
/// Provides functions for the player and some scene management.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab, _gameOverMenu, _pauseMenu, _scoresText, _livesText;
    private TextMeshProUGUI _scoresTextMesh, _livesTextMesh;
    private readonly float _horizontalRestriction = 5.7f;
    private readonly float _playerSpeed = 50f;
    private float _sensitivity;
    private int _playerScore, _lives;
    private bool _gameOverFlag = false;

    public bool gameOverFlag
    {
        get { return _gameOverFlag; }
        set { _gameOverFlag = value; }
    }

    private void Start()
    {
        _sensitivity = PlayerPrefs.HasKey("Sensitivity") ? PlayerPrefs.GetFloat("Sensitivity") : 1;
        _playerScore = PlayerPrefs.HasKey("Score") ? PlayerPrefs.GetInt("Score") : 0;
        _lives = PlayerPrefs.HasKey("Lives") ? PlayerPrefs.GetInt("Lives") : 3;
        Cursor.visible = false;
        _gameOverMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _scoresTextMesh = _scoresText.GetComponent<TextMeshProUGUI>();
        _scoresTextMesh.text = _playerScore.ToString();
        _livesTextMesh = _livesText.GetComponent<TextMeshProUGUI>();
        _livesTextMesh.text = _lives.ToString();
    }

    public void Move(Vector2 move)
    {
        // Restrict horizontal movement of the player.
        if (Mathf.Abs(gameObject.transform.position.x) <= _horizontalRestriction)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(move.x * _playerSpeed * _sensitivity * Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.position = new Vector2(_horizontalRestriction * Mathf.Sign(gameObject.transform.position.x), gameObject.transform.position.y);
        }
    }

    public void AddScore(int add)
    {
        _playerScore += add;
        _scoresTextMesh.text = _playerScore.ToString();
    }

    public int[] GetPlayerData()
    {
        return new int[] { _playerScore, _lives };
    }

    public void ChangeLivesCount(int count)
    {
        _lives += count;
        _livesTextMesh.text = _lives.ToString();
    }

    public void GameEndController()
    {
        if (_lives > 0)
        {
            _ = Instantiate(_ballPrefab, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _gameOverFlag = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            _gameOverMenu.SetActive(true);
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

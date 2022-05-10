using TMPro;
using UnityEngine;

/// <summary>
/// Provides functions for the player and some scene management.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab, _gameOverMenu, _pauseMenu, _scoresText, _livesText, _general;
    private ValeraManager _manager;
    private GameObject _ballObject;
    private TextMeshProUGUI _scoresTextMesh, _livesTextMesh;
    private readonly float _horizontalRestriction = 6.5f;
    private readonly float _playerSpeed = 50f;
    private float _sensitivity;
    private int _playerScore, _lives = 3;
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
        Cursor.visible = false;
        _gameOverMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _scoresTextMesh = _scoresText.GetComponent<TextMeshProUGUI>();
        _scoresTextMesh.text = _playerScore.ToString();
        _livesTextMesh = _livesText.GetComponent<TextMeshProUGUI>();
        _livesTextMesh.text = _lives.ToString();
        _ballObject = GameObject.FindGameObjectWithTag("Ball");
        _manager = _general.GetComponent<ValeraManager>();
    }

    public void ResetBall()
    {
        _ballObject = GameObject.FindGameObjectWithTag("Ball");
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
        PlayerPrefs.SetInt("Score", _playerScore);
        _scoresTextMesh.text = _playerScore.ToString();
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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<IBrickInterface>().Catch();
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

            case 3:
                _ballObject.GetComponent<BallController>().SetSpeedModifier(1.2f);
                break;

            case 4:
                _ballObject.GetComponent<BallController>().SetSpeedModifier(0.85f);
                break;
            
            // Cases 5-10 are the same but only the character is different.
            // ToDo: add character catching.
            case 5:
                _manager.ActivateCharacter(0);
                break;
            case 6:
                _manager.ActivateCharacter(1);
                break;
            case 7:
                _manager.ActivateCharacter(2);
                break;
            case 8:
                _manager.ActivateCharacter(3);
                break;
            case 9:
                _manager.ActivateCharacter(4);
                break;
            case 10:
                _manager.ActivateCharacter(5);
                break;

            default:
                break;
        }
    }
}

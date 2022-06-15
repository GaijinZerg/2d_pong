using TMPro;
using UnityEngine;

/// <summary>
/// Provides functions for the player and some scene management.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab, _gameOverMenu, _pauseMenu, _scoresText, _livesText, _general;
    [SerializeField] private AudioClip[] _audioClips;
    private BonusGenerator _bonusGenerator;
    private ValeraManager _manager;
    private GameObject _ballObject;
    private TextMeshProUGUI _scoresTextMesh, _livesTextMesh;
    private AudioSource _audioSource;
    private readonly float _horizontalRestriction = 6.1f;
    private readonly float _playerSpeed = 50f;
    private float _sensitivity;
    private readonly float _sensitivityCorrector = 0.02f;
    private int _playerScore, _lives = 3;
    private bool _gameOverFlag = false;
    private float _restriction = 0;

    public bool gameOverFlag
    {
        get { return _gameOverFlag; }
        set { _gameOverFlag = value; }
    }

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
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
        _bonusGenerator = _general.GetComponent<BonusGenerator>();
    }

    public void ResetBall()
    {
        _ballObject = GameObject.FindGameObjectWithTag("Ball");
    }

    public void Move(float move)
    {
        // ToDo: check if it could be done better like checking if it was change or not.
        _sensitivity = PlayerPrefs.HasKey("Sensitivity") ? PlayerPrefs.GetFloat("Sensitivity") : 1;
        // This restriction is necessary to avoid shattering when collapsing with colliders.
        _restriction = gameObject.transform.position.x + move * _playerSpeed * _sensitivity * _sensitivityCorrector * Time.deltaTime;
        if (Mathf.Abs(_restriction) < _horizontalRestriction)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(move * _playerSpeed * _sensitivity * _sensitivityCorrector * Time.deltaTime, 0, 0);
        }
    }

    public void AddScore(int add)
    {
        _playerScore += add;
        PlayerPrefs.SetInt("Score", _playerScore);
        _scoresTextMesh.text = _playerScore.ToString();
        _bonusGenerator.Comparator(_playerScore);
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
            _ = Instantiate(_ballPrefab, new Vector2(0, -1), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _audioSource.clip = _audioClips[2];
            _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
            _audioSource.Play();
            _gameOverFlag = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            _gameOverMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        if (collision.gameObject.CompareTag("Bonus"))
        {
            _audioSource.clip = _audioClips[1];
            _audioSource.Play();
            ProcessBonus(collision.gameObject.GetComponent<IBonusInterface>().ReturnBonusType());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            _audioSource.clip = _audioClips[0];
            _audioSource.Play();
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
                this.AddScore(100);
                this.ChangeLivesCount(1);
                break;

            case 3:
                this.AddScore(100);
                _ballObject.GetComponent<BallController>().SetSpeedModifier(1.2f);
                break;

            case 4:
                this.AddScore(100);
                _ballObject.GetComponent<BallController>().SetSpeedModifier(0.85f);
                break;
            
            // Cases 5-10 are the same but only the character is different.
            // ToDo: add character catching.
            case 5:
                this.AddScore(100);
                _manager.ActivateCharacter(0);
                break;
            case 6:
                this.AddScore(100);
                _manager.ActivateCharacter(1);
                break;
            case 7:
                this.AddScore(100);
                _manager.ActivateCharacter(2);
                break;
            case 8:
                this.AddScore(100);
                _manager.ActivateCharacter(3);
                break;
            case 9:
                this.AddScore(100);
                _manager.ActivateCharacter(4);
                break;
            case 10:
                this.AddScore(100);
                _manager.ActivateCharacter(5);
                break;

            default:
                break;
        }
    }
}

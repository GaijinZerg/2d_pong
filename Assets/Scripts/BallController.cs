using UnityEngine;

/// <summary>
/// Provides operations for controlling the ball object.
/// </summary>
public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _soundEffects;
    [SerializeField] private GameObject _ballLostSplash1, _ballLostSplash2, _ballNewSplash1, _ballNewSplash2;
    private AudioSource _soundComponent;
    private GameObject _player;
    private PlayerController _playerController;
    private Rigidbody2D _ballRigidbody;
    private float _ballSpeed = 6f, _speedModifier = 1f, _timer = 0f, _speedUpTime = 30f, diffAngle = 0f, tempMagnitude = 1f;
    private Vector2 _bounceDirection, _lastVelocity;
    private bool _isPushed = false;

    private void Start()
    {
        _soundComponent = gameObject.GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _playerController.ResetBall();
        _ = Instantiate(_ballNewSplash1, transform.position, Quaternion.Euler(0, 0, 0));
        _ = Instantiate(_ballNewSplash2, transform.position, Quaternion.Euler(0, 0, 0));
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if ((_timer > 1) && !_isPushed)
        {
            // Start pulse.
            _ballRigidbody.AddForce(new Vector2(100f, -100f), ForceMode2D.Force);
            _isPushed = true;
        }
        if (_timer > _speedUpTime)
        {
            _speedModifier = Mathf.Clamp(_speedModifier * 1.2f, 0.5f, 1.9f); ;
            _timer = 0f;
        }
        StuckCorrector();
        MoveCorrector();
        _lastVelocity = _ballRigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                _soundComponent.clip = _soundEffects[2];
                break;
            case "Brick":
                _soundComponent.clip = _soundEffects[3];
                break;
            default:
                _soundComponent.clip = _soundEffects[0];
                break;
        }
        _soundComponent.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        _soundComponent.Play();
        // We need to keep the ball speed constant.
        _bounceDirection = Vector2.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        _ballRigidbody.velocity = _bounceDirection * _ballSpeed * _speedModifier;
        if (collision.gameObject.GetComponent<IBrickInterface>() != null)
        {
            collision.gameObject.GetComponent<IBrickInterface>().Action();
        }
    }

    // Used in case if player looses the ball.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            AudioSource.PlayClipAtPoint(_soundEffects[1], gameObject.transform.position, PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1);
            _playerController.ChangeLivesCount(-1);
            _playerController.GameEndController();
            _ = Instantiate(_ballLostSplash1, transform.position, Quaternion.Euler(0, 0, 0));
            _ = Instantiate(_ballLostSplash2, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }

    public void SetSpeedModifier(float modifier)
    {
        _speedModifier = Mathf.Clamp(_speedModifier * modifier, 0.5f, 2f);
    }

    // Avoids near to horizontal bouncing and normilizes speed.
    private void MoveCorrector()
    {
        if (_ballRigidbody.velocity.magnitude < 0.95f * _ballSpeed * _speedModifier)
        {
            float corrector = Mathf.Clamp(_ballSpeed * _speedModifier / _ballRigidbody.velocity.magnitude, 0f, 100f);
            _ballRigidbody.velocity = new Vector2(_ballRigidbody.velocity.x * corrector, _ballRigidbody.velocity.y * corrector);
        }
        if (Mathf.Abs(_ballRigidbody.velocity.x / _ballRigidbody.velocity.y) > 4)
        {
            _ballRigidbody.velocity = new Vector2(Mathf.Sign(_ballRigidbody.velocity.x) * _ballRigidbody.velocity.magnitude * 0.74f, Mathf.Sign(_ballRigidbody.velocity.y) * _ballRigidbody.velocity.magnitude * 0.25f);
        }
        if (Mathf.Abs(_ballRigidbody.velocity.y / _ballRigidbody.velocity.x) > 4)
        {
            _ballRigidbody.velocity = new Vector2(Mathf.Sign(_ballRigidbody.velocity.x) * _ballRigidbody.velocity.magnitude * 0.25f, Mathf.Sign(_ballRigidbody.velocity.y) * _ballRigidbody.velocity.magnitude * 0.74f);
        }
    }

    /* Avoids ball stuck.
     * When angle of reflection is less than 45 degrees we add a random shift.
     */
    private void StuckCorrector()
    {
        diffAngle = 180 - Vector2.Angle(_lastVelocity, _ballRigidbody.velocity);
        if (Mathf.Abs(diffAngle) < 45)
        {
            tempMagnitude = _ballRigidbody.velocity.magnitude;
            _ballRigidbody.velocity = new Vector2(_ballRigidbody.velocity.x + Random.Range(0f, _ballRigidbody.velocity.magnitude * 0.2f), _ballRigidbody.velocity.y + Random.Range(0f, _ballRigidbody.velocity.magnitude * 0.2f));
            _ballRigidbody.velocity = _ballRigidbody.velocity.normalized * tempMagnitude;
        }
    }
}

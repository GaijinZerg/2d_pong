using UnityEngine;

/// <summary>
/// Provides operations for controlling the ball object.
/// </summary>
public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _soundEffects;
    private AudioSource _soundComponent;
    private GameObject _player;
    private PlayerController _playerController;
    private Rigidbody2D _ballRigidbody;
    private float _ballSpeed = 5, _speedModifier = 1f, _timer = 0f, _speedUpTime = 30f;
    private Vector2 _bounceDirection, _lastVelocity;

    private void Start()
    {
        _soundComponent = gameObject.GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
        // Start pulse.
        _ballRigidbody.AddForce(new Vector2(100f, -100f), ForceMode2D.Force);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _speedUpTime)
        {
            _speedModifier = Mathf.Clamp(_speedModifier * 1.1f, 0.5f, 2f); ;
            _timer = 0f;
        }
        _lastVelocity = _ballRigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _soundComponent.clip = _soundEffects[0];
        _soundComponent.Play();
        // We need to keep the ball speed constant.
        _bounceDirection = Vector2.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        _ballRigidbody.velocity = _bounceDirection * _ballSpeed * _speedModifier;
        // Avoid near to horizontal bouncing.
        if (Mathf.Abs(_ballRigidbody.velocity.x) > 5 * Mathf.Abs(_ballRigidbody.velocity.y))
        {
            _ballRigidbody.velocity = new Vector2(_ballRigidbody.velocity.x * 0.8f, _ballRigidbody.velocity.y * 1.5f);
        }
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
            AudioSource.PlayClipAtPoint(_soundEffects[1], gameObject.transform.position);
            _playerController.ChangeLivesCount(-1);
            _playerController.GameEndController();
            Destroy(gameObject);
        }
    }

    public void SetSpeedModifier(float modifier)
    {
        _speedModifier = Mathf.Clamp(_speedModifier * modifier, 0.5f, 2f);
    }
}

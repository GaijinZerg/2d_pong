using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    private float ballSpeed = 5;
    private Vector2 bounceDirection, lastVelocity;

    private void Start()
    {
        ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
        // Start pulse.
        ballRigidbody.AddForce(new Vector2(100f, -100f), ForceMode2D.Force);
    }

    private void Update()
    {
        lastVelocity = ballRigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // We need to keep the ball speed constant.
        // It can be avoided if we do not use Rigidbody but we must use Rigidbody due to the task requirements.
        bounceDirection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        ballRigidbody.velocity = bounceDirection * ballSpeed;
        if (collision.gameObject.GetComponent<IBrickInterface>() != null)
        {
            collision.gameObject.GetComponent<IBrickInterface>().Action();
        }
    }
}

using UnityEngine;

/// <summary>
/// Controls splash effect object.
/// </summary>
public class SplashController : MonoBehaviour
{
    private float _timer = 1;

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class SplashController : MonoBehaviour
{
    private float timer = 1;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(gameObject);
    }
}

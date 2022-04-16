using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject scoreBonusPrefab, liveBonusPrefab;

    protected void BonusAction(GameObject generator)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            _ = Instantiate(scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _ = Instantiate(liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}

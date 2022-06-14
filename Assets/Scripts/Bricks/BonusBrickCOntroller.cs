using UnityEngine;

/// <summary>
/// Provides unique functions for the soft brick.
/// </summary>
public class BonusBrickController : Brick, IBrickInterface
{
    [SerializeField] private GameObject _scoreBonusPrefab, _liveBonusPrefab, _speedUpBonusPrefab, _slowDownBonusPrefab, _characterBonusPrefab;

    BrickProperties properties = new(1, 100);
    public void Action()
    {
        properties.Durability--;
        if (properties.Durability == 0)
        {
            _ = Instantiate(splashPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            BonusAction(gameObject);
            Destroy(gameObject);
        }
    }

    public void Catch()
    {
        // This block never falls.
    }

    // There are several types of bonuses.
    // extra life - 5%
    // score - 60%
    // slow down - 10%
    // speed up - 10%
    // character - 15%
    private void BonusAction(GameObject generator)
    {
        float x = Random.Range(0f, 1f);
        if (x < 0.05f)
        {
            _ = Instantiate(_liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.05f) && (x < 0.65f))
        {
            _ = Instantiate(_scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.65f) && (x < 0.75f))
        {
            _ = Instantiate(_speedUpBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if ((x >= 0.75f) && (x < 0.85f))
        {
            _ = Instantiate(_slowDownBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _ = Instantiate(_characterBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}

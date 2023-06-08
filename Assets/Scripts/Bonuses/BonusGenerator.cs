using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _liveBonusPrefab, _characterBonusPrefab, _liveBonusImage, _characterBonusImage;
    [SerializeField] private GameObject[] _bonusSplashPrefab;
    private int _liveScoreCount = 1, _characterScoreCount = 1;
    private readonly int _livePrice = 30000;
    private readonly int _charcterPrice = 40000;

    public void Comparator(int score)
    {
        if (score >= _livePrice * _liveScoreCount)
        {
            _liveScoreCount++;
            GenerateBonus(1);
        }
        if (score >= _charcterPrice * _characterScoreCount)
        {
            _characterScoreCount++;
            GenerateBonus(2);
        }
    }

    private void GenerateBonus(int type)
    {
        switch (type)
        {
            case 1:
                _ = Instantiate(_liveBonusPrefab, new Vector2(Random.Range(-6f, 6f), gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                _ = Instantiate(_bonusSplashPrefab[0], _liveBonusImage.transform.position, Quaternion.Euler(0, 0, 0));
                _ = Instantiate(_bonusSplashPrefab[1], _liveBonusImage.transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 2:
                _ = Instantiate(_characterBonusPrefab, new Vector2(Random.Range(-6f, 6f), gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                _ = Instantiate(_bonusSplashPrefab[0], _characterBonusImage.transform.position, Quaternion.Euler(0, 0, 0));
                _ = Instantiate(_bonusSplashPrefab[1], _characterBonusImage.transform.position, Quaternion.Euler(0, 0, 0));
                break;
        }
    }
}

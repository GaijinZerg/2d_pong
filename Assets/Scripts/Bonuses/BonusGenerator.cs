using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _liveBonus, _characterBonus;
    private int _liveScoreCount = 1, _characterScoreCount = 1;
    private int _livePrice = 20000, _charcterPrice = 30000;

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
                _ = Instantiate(_liveBonus, new Vector2(Random.Range(-6f, 6f), gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                break;
            case 2:
                _ = Instantiate(_characterBonus, new Vector2(Random.Range(-6f, 6f), gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                break;
        }
    }
}

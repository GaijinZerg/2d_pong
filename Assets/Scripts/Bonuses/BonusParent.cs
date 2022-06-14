using UnityEngine;

public class BonusParent : MonoBehaviour, IBonusInterface
{
    private General _general;
    protected int _bonusType;

    private void Awake()
    {
        _general = GameObject.Find("General").GetComponent<General>();
    }

    public int ReturnBonusType()
    {
        return _bonusType;
    }

    public void OnDestroy()
    {
        if (_general != null)
        {
            _general.SceneChanger();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

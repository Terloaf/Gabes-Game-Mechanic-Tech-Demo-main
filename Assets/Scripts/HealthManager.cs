using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int _maxHealth;

    public int _health;

    private void Awake()
    {
        _maxHealth = _health;
    }



    public void TakeDmg(int damage)
    {
        _health -= damage;
    }

    public void OnDeath()
    {
        if(_health <= 0)
        {
            gameObject.transform.position = CheckPointSystem._position;
        }
    }
}

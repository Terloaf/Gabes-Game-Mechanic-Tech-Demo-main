using UnityEngine;

public class KillBox : MonoBehaviour
{

    public int dmg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthManager health =  other.gameObject.GetComponent<HealthManager>();
            health.TakeDmg(dmg);
            
        }
    }
}

using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject _player;
    public GameObject _platform;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}

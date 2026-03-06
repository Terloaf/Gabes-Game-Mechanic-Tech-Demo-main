using UnityEngine;

public class OutOfBounds : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = CheckPointSystem._position;
            Debug.Log("this has been called");
        }
    }
}

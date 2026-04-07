using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public GameObject _door;
    public GameObject _doorEndPos;
    public float _speed;
    Vector3 _doorStartPos;
    bool isInTrigger = false;
    private void Start()
    {
        _doorStartPos = _door.transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           _door.transform.position = Vector3.MoveTowards(_door.transform.position, _doorEndPos.transform.position, _speed * Time.fixedDeltaTime);
            isInTrigger = true;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }
    private void Update()
    {
        if(isInTrigger == false)
        {
            _door.transform.position = Vector3.MoveTowards(_door.transform.position, _doorStartPos, _speed * Time.deltaTime);
        }
    }


}

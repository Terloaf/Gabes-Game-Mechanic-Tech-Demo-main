using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    private static CheckPointSystem _currentCheckPoint;
    public static Vector3 _position;



    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        ActivateCheckPoint();
    }


    private void ActivateCheckPoint()
    {
        if (_currentCheckPoint == this) return;


        
        _currentCheckPoint = this;
        _position = transform.position;
    }
}

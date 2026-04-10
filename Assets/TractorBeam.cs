using UnityEngine;
using URC.Core;

public class TractorBeam : MonoBehaviour
{
    Rigidbody _playerRb;
    Motor _playerMotor;
    private bool _isInBeam;
    public GameObject _endPoint;
    private float _speed = 3;

    private void Update()
    {
        if (_isInBeam && _playerRb != null)
        {
            
            _playerRb.MovePosition(Vector3.MoveTowards(_playerRb.position, _endPoint.transform.position, _speed * Time.deltaTime));
        }
            

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerMotor = other.GetComponent<Motor>();
            _playerRb = other.GetComponent<Rigidbody>();
            _isInBeam = true;
            _playerMotor.DisableGravity();

        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRb = null;
            _isInBeam = false;
            _playerMotor.EnableGravity();
            

        }
    }


}

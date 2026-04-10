using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Unity.VisualScripting;


[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    //private Vector3 _startPos;

    //public Vector3 _targetPos;
    [SerializeField]
    List<Vector3> _points;

    public float _speed;
    Rigidbody _rb;

    Rigidbody _playerRb;

    private bool _isPlayerOnPlatform;

    Vector3 _lastPosition;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        if (_points.Count == 0) return;

        transform.position = _points[0];

        if(_points.Count > 1)
        {
            StartCoroutine(MovePlatform());
        }


    }

    private void Update()
    {
        if(_isPlayerOnPlatform && _playerRb != null)
        {
            Vector3 delta = transform.position - _lastPosition;
            _playerRb.MovePosition(_playerRb.position + delta);
        }
        
        _lastPosition = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRb = other.GetComponent<Rigidbody>();
           _isPlayerOnPlatform = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRb = null;
            _isPlayerOnPlatform = false;

        }
    }

    private void FixedUpdate()
    {

    }


    IEnumerator MovePlatform()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            while (Vector3.Distance(_rb.position, _points[i]) > 0.1)
            {
                _rb.MovePosition(Vector3.MoveTowards(_rb.position, _points[i], _speed * Time.fixedDeltaTime));

                yield return null;
            }

            yield return new WaitForSeconds(1);

            if(i == _points.Count - 1)
            {
                i = 0;

            }
        }
    }


}

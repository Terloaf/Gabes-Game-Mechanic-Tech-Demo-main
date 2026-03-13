using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;


[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    //private Vector3 _startPos;

    //public Vector3 _targetPos;
    [SerializeField]
    List<Vector3> _points;

    public float _speed;

    public Rigidbody _playerRb;
    Rigidbody _rb;
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

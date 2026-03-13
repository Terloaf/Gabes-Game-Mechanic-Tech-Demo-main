using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    //private Vector3 _startPos;

    //public Vector3 _targetPos;

    [SerializeField]
    List<Vector3> _points;

    public int _speed;

    private Rigidbody _rb;
    private void Start()
    {
        
    }


    private void Update()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            while (Vector3.Distance(_rb.position, _points[i]) > 0.1)
            {
                _rb.MovePosition(Vector3.MoveTowards(_rb.position, _points[i], _speed * Time.deltaTime));
                yield return null;
            }

            yield return new WaitForSeconds(1);
            {
                i = 0;

            }
        }
    }
}

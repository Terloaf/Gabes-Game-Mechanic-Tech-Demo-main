using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject _cubePrefab;


    private void Start()
    {
        Instantiate<GameObject>(_cubePrefab);
        _cubePrefab.transform.position = transform.position;
    }
}

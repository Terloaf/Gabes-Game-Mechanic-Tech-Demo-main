using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject _cubePrefab;
    public GameObject _spawner;

    private void OnTriggerEnter(Collider other)
    {
        _cubePrefab.transform.position = _spawner.transform.position;
        Instantiate<GameObject>(_cubePrefab);
        
    }

    
    
}

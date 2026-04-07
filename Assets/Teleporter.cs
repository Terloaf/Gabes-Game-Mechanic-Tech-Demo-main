using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject _Desination;
    public Material _default;
    private Teleporter _lastStepped;
    private Vector3 _position;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            _lastStepped = this;

            _Desination.GetComponent<Collider>().enabled = false;
            other.gameObject.transform.position = _Desination.transform.position;
            StartCoroutine(Cooldown());


        }
    }

    IEnumerator Cooldown()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);
        _Desination.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Renderer>().material.color = _default.color;
        _Desination.gameObject.GetComponent<Renderer>().material.color = _default.color;
        _Desination.GetComponent<Collider>().enabled = true;
    }


}


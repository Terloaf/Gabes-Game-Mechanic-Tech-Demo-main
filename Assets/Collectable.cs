using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int _score = 0;
    public TMP_Text _text;


    private void Update()
    {
        if (_text == null)
        {
            return;
        }
        _text.text = "Score: " + _score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            _score += 1;
            Destroy(other.gameObject);
            
        }
        
    }

}

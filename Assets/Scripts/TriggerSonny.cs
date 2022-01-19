using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerSonny : MonoBehaviour {

    public GameObject dialogPrefab;
    public GameObject botoesSonny;
    public bool libera = false;

    void Update()
    {

        if (libera == true && Input.GetKeyDown(KeyCode.Return))
        {
            dialogPrefab.SetActive(false);
            botoesSonny.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D enter)
    {
        if(enter.tag == "Player")
        {
            dialogPrefab.SetActive(true);
            libera = true;

        }
        
    }

    void OnTriggerExit2D(Collider2D back)
    {
        if (back.tag == "Player")
        {
            dialogPrefab.SetActive(false);
            botoesSonny.SetActive(false);
            libera = false;

        }
    }

}

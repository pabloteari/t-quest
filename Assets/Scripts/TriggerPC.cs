using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerPC : MonoBehaviour {

    public GameObject dialogTerminal;
    public bool liberaTerminal = false;

    void Update()
    {
        if (liberaTerminal == true && Input.GetKeyDown(KeyCode.Return))
        {
            MoveToUMLTarefa ();
        }
           
    }

    void OnTriggerEnter2D(Collider2D entrar)
    {
        if (entrar.tag == "Player")
        {
            dialogTerminal.SetActive(true);
            liberaTerminal = true;
        }
    }

    void OnTriggerExit2D(Collider2D sair)
    {
        if (sair.tag == "Player")
        {
            dialogTerminal.SetActive(false);
            liberaTerminal = false;
        }
    }

    public void MoveToUMLTarefa()
    {
        SceneManager.LoadScene ("Desktop");
    }

}

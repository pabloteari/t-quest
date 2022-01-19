using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MoveScena : MonoBehaviour {

   

    public void MoveToHistoria()
	{
        var xmlLib = new XMLLib ();
        xmlLib.CriarXML (0, 0, 0);
        SceneManager.LoadScene ("Historia");
	}

    public void MoveToUMLTarefa()
    {
        var xmlLib = new XMLLib ();        
        var processo = xmlLib.isXmlExist();

        int TarefaAtual = processo.tarefaAtual;

        if (TarefaAtual == 7) 
        {
            SceneManager.LoadScene ("UltimaFase");
        }
        else
        {
            SceneManager.LoadScene ("UMLTarefa");
        }
    }

    public void MoveToEscritorioSonny()
    {
        var xmlLib = new XMLLib ();        
        var processo = xmlLib.isXmlExist();

        int TarefaAtual = processo.tarefaAtual;

        if (TarefaAtual == 9) 
        {
            SceneManager.LoadScene ("Wins");
        } 
        else if (TarefaAtual == 8) 
        {
            SceneManager.LoadScene ("GameOver");
        } 
        else 
        {           
            SceneManager.LoadScene ("EscritorioSonny");
        }
    }

    public void MoveToEscritorioDuck()
    {
        SceneManager.LoadScene ("EscritorioDuck");
    }

    public void MoveToMenu()
    {
        var xmlLib = new XMLLib ();
        xmlLib.CriarXML (3, 8, 1);
        SceneManager.LoadScene ("Menu");
    }

    public void MoveToCreditos()
    {
        SceneManager.LoadScene ("Creditos");
    }

    public void MoveToMaterial()
    {
        SceneManager.LoadScene ("Material");
    }
}
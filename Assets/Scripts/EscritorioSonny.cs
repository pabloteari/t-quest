using UnityEngine;
using System.Collections;

public class EscritorioSonny : MonoBehaviour {

    public int TarefaAtual;
    public int Bloqueios;
    public int MaquinaBloqueada;

	// Use this for initialization
	void Start () {
        var xmlLib = new XMLLib ();        
        var processo = xmlLib.isXmlExist();

        TarefaAtual = processo.tarefaAtual;
        Bloqueios = processo.bloqueios;
        MaquinaBloqueada = processo.maquinaBloqueada;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DesbloquearMaquina()
    {
        var xmlLib = new XMLLib ();
        xmlLib.CriarXML (Bloqueios, TarefaAtual, 0);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class CenaFinal : MonoBehaviour {

    public int TarefaAtual = 0;
    public int Bloqueios = 0;
    public int MaquinaBloqueada = 0;
    public Dropdown ClasseEscolhida;
    public Text BotaoEnviarText;
    public Text LabelDicaTarefa;
    public Button BotaoEnvia;
    public Text TentativasLabel;
    int TentativasRestantes = 5;

	// Use this for initialization
	void Start () {
        var xmlLib = new XMLLib ();        
        var processo = xmlLib.isXmlExist();

        TarefaAtual = processo.tarefaAtual;
        Bloqueios = processo.bloqueios;
        MaquinaBloqueada = processo.maquinaBloqueada;

        if (Bloqueios >= 3) {
            Despedito ();
        } 
        else if (MaquinaBloqueada == 1) 
        {
            BotaoEnviarText.text = "FALAR COM SONNY!";
            ClasseEscolhida.enabled = false;
            BotaoEnviarText.text = "FALAR COM SONNY!";
            TentativasLabel.text = "MAQUINA BLOQUEADA, PEÇA AJUDA AO SONNY";
            TentativasLabel.color = Color.red;
        } 

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void VerificarMetrica()
    {
        if (BotaoEnviarText.text == "Enviar resposta") {
            if (TentativasRestantes > 1 && MaquinaBloqueada == 0 && Bloqueios < 3) {
                if (ClasseEscolhida.value == 4)
                {
                    MensagemAcerto ();
                } 
                else 
                {
                    TentativasRestantes--;
                    AtualizaTentativas (); 
                }
            } 
            else 
            {
                MensagemErro ();
            }
        } 
        else if (BotaoEnviarText.text == "FALAR COM SONNY!")
        {
            chamaEscritorioSonny ();
        } 
        else if (BotaoEnviarText.text == "FALAR COM DUCK!") 
        {
            chamaEscritorioDuck ();
        }
        else if (BotaoEnviarText.text == "PRÓXIMA TAREFA") 
        {
            chamaEscritorioDuck ();
        }
    }

    public void chamaEscritorioDuck()
    {
        SceneManager.LoadScene ("EscritorioDuck");
    }

    public void chamaEscritorioSonny()
    {
        SceneManager.LoadScene ("EscritorioSonny");
    }

    public void MensagemAcerto()
    {
        var xmlLib = new XMLLib ();
        TentativasLabel.color = Color.grey;
        TentativasLabel.text = "MÉTRICAS CORRETAS, NÚMERO DE MÉTODOS ENVIADO PARA ANALISE DE DUCK";
        ClasseEscolhida.enabled = false;
        BotaoEnviarText.text = "PRÓXIMA TAREFA"; 

        xmlLib.CriarXML (Bloqueios, 9, 0);
    }

    public void MensagemErro()
    {
        //panelEnviar.SetActive (false);
        //panelCenas.SetActive (true);
        var xmlLib = new XMLLib ();
        ClasseEscolhida.enabled = false;
        BotaoEnviarText.text = "FALAR COM SONNY!";
        TentativasLabel.text = "MÁQUINA BLOQUEADA, PEÇA AJUDA AO SONNY";
        TentativasLabel.color = Color.red;
        var blo = Bloqueios+ 1;
        xmlLib.CriarXML (blo, TarefaAtual, 1);
        MaquinaBloqueada = 1;

        //TextBotaoEnviar.text = "FALAR COM SONNY";
    }

    public void Despedito()
    {        
        ClasseEscolhida.enabled = false;
        BotaoEnviarText.text = "FALAR COM DUCK!";
        TentativasLabel.text = "DUCK QUER FALAR COM VOCÊ!";
        var xmlLib = new XMLLib ();
        xmlLib.CriarXML (3, 8, 1);
        TentativasLabel.color = Color.red;
    }

    public void AtualizaTentativas()
    {
        TentativasLabel.text = "Restam " + TentativasRestantes + " tentativas";
    }
}

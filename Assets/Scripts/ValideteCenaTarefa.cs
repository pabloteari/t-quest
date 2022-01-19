using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class ValideteCenaTarefa : MonoBehaviour
{
    
    public Dropdown MetricaNome;
    public Dropdown mManutencao;
    public Dropdown mMotorista;
    public Dropdown mMovimentacao;
    public Dropdown mRevendedor;
    public Dropdown mVeiculo;
    public Dropdown mVeiculoCarga;
    public Dropdown mVeiculoPasseio;

    public Text TentativasLabel;
    public Text BotaoEnviarText;
    public Text LabelDicaTarefa;
    public Button BotaoEnviar;

    int TentativasRestantes = 5;
    int IndexNomeMetrica;
    public int TarefaAtual = 0;
    public int Bloqueios = 0;
    public int MaquinaBloqueada = 0;
    public GameObject panelEnviar;
    public GameObject panelCenas;
    int rManu;
    int rMoto;
    int rRevend;
    int rMovimen;
    int rVeiculo;
    int rVeiculoCarga;
    int rVeiculoPasseio;
   
    enum RepostaNome
    {
        WMC = 0,
        DIT = 1,
        NOC = 2,
        CBO = 3,
        CS  = 4,
        NOO = 5,
        NOA = 6        
    };
            
    enum Manutencao
    {
        WMC = 0,
        DIT = 0,
        NOC = 0,
        CBO = 0,
        CS  = 2,
        NOO = 0,
        NOA = 0  
    }

    enum Motorista
    {
        WMC = 2,
        DIT = 0,
        NOC = 0,
        CBO = 0,
        CS  = 7,
        NOO = 0,
        NOA = 0  
    }

    enum Revendedor
    {
        WMC = 0,
        DIT = 0,
        NOC = 0,
        CBO = 0,
        CS  = 3,
        NOO = 0,
        NOA = 0  
    }

    enum Veiculo
    {
        WMC = 0,
        DIT = 0,
        NOC = 2,
        CBO = 3,
        CS  = 3,
        NOO = 0,
        NOA = 0  
    }

    enum VeiculoCarga
    {
        WMC = 0,
        DIT = 1,
        NOC = 0,
        CBO = 0,
        CS  = 4,
        NOO = 0,
        NOA = 1  
    }

    enum VeiculoPasseio
    {
        WMC = 0,
        DIT = 1,
        NOC = 0,
        CBO = 0,
        CS  = 4,
        NOO = 0,
        NOA = 1  
    }


    enum Movimentacao
    {
        WMC = 0,
        DIT = 0,
        NOC = 0,
        CBO = 1,
        CS  = 3,
        NOO = 0,
        NOA = 0  
    }
            
	// Use this for initialization
	void Start () 
    {
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
            mManutencao.enabled = false;
            MetricaNome.enabled = false;
            BotaoEnviarText.text = "FALAR COM SONNY!";
            TentativasLabel.text = "MÁQUINA BLOQUEADA, PEÇA AJUDA AO SONNY!";
            TentativasLabel.color = Color.red;
        } 
        else {
            
            switch (TarefaAtual) {
            case 0:                
                IndexNomeMetrica = (int)RepostaNome.WMC;                
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o número de métodos que as classes em nosso sistema estão recebendo...\"";
                rManu = (int)Manutencao.WMC;
                rMoto = (int)Motorista.WMC;
                rRevend = (int)Revendedor.WMC;
                rMovimen = (int)Movimentacao.WMC;
                rVeiculo = (int)Veiculo.WMC;
                rVeiculoCarga = (int)VeiculoCarga.WMC;
                rVeiculoPasseio = (int)VeiculoPasseio.WMC;
                break;
            case 1:
                IndexNomeMetrica = (int)RepostaNome.DIT;     
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o mau uso de herança em nosso código...\"";
                rManu = (int)Manutencao.DIT;
                rMoto = (int)Motorista.DIT;
                rRevend = (int)Revendedor.DIT;
                rMovimen = (int)Movimentacao.DIT;
                rVeiculo = (int)Veiculo.DIT;
                rVeiculoCarga = (int)VeiculoCarga.DIT;
                rVeiculoPasseio = (int)VeiculoPasseio.DIT;
                break;           
            case 2:
                IndexNomeMetrica = (int)RepostaNome.NOC;                
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o número de filhos que nossas classes estão recebendo...\"";
                rManu = (int)Manutencao.NOC;
                rMoto = (int)Motorista.NOC;
                rRevend = (int)Revendedor.NOC;
                rMovimen = (int)Movimentacao.NOC;
                rVeiculo = (int)Veiculo.NOC;  
                rVeiculoCarga = (int)VeiculoCarga.NOC;
                rVeiculoPasseio = (int)VeiculoPasseio.NOC;
                break;
            case 3:
                IndexNomeMetrica = (int)RepostaNome.CBO;
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o número de acoplamentos que nossas classes estão recebendo...";
                rManu = (int)Manutencao.CBO;
                rMoto = (int)Motorista.CBO;
                rRevend = (int)Revendedor.CBO;
                rMovimen = (int)Movimentacao.CBO;
                rVeiculo = (int)Veiculo.CBO;  
                rVeiculoCarga = (int)VeiculoCarga.CBO;
                rVeiculoPasseio = (int)VeiculoPasseio.CBO;
                break;
            case 4:
                IndexNomeMetrica = (int)RepostaNome.CS;
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o número de atributos e métodos que nossas classes estão recebendo...";
                rManu = (int)Manutencao.CS;
                rMoto = (int)Motorista.CS;
                rRevend = (int)Revendedor.CS;
                rMovimen = (int)Movimentacao.CS;
                rVeiculo = (int)Veiculo.CS;  
                rVeiculoCarga = (int)VeiculoCarga.CS;
                rVeiculoPasseio = (int)VeiculoPasseio.CS;
                break;
            case 5:
                IndexNomeMetrica = (int)RepostaNome.NOO;                
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com redefinições de métodos nas classes filhas...";
                rManu = (int)Manutencao.NOO;
                rMoto = (int)Motorista.NOO;
                rRevend = (int)Revendedor.NOO;
                rMovimen = (int)Movimentacao.NOO;
                rVeiculo = (int)Veiculo.NOO;    
                rVeiculoCarga = (int)VeiculoCarga.NOO;
                rVeiculoPasseio = (int)VeiculoPasseio.NOO;
                break;           
            case 6:
                IndexNomeMetrica = (int)RepostaNome.NOA;                
                LabelDicaTarefa.text = "\"Duck : Estamos tendo problemas com o número de serviços/métodos e atributos adicionados nas subclasses..";
                rManu = (int)Manutencao.NOA;
                rMoto = (int)Motorista.NOA;
                rRevend = (int)Revendedor.NOA;
                rMovimen = (int)Movimentacao.NOA;
                rVeiculo = (int)Veiculo.NOA;
                rVeiculoCarga = (int)VeiculoCarga.NOA;
                rVeiculoPasseio = (int)VeiculoPasseio.NOA;
                break; 
            case 7:
                IndexNomeMetrica = (int)RepostaNome.NOA;                
                LabelDicaTarefa.text = "\"Duck : Diagnostique qual de nossas classes está sobrecarregando nosso sistema...";
                rManu = (int)Manutencao.NOA;
                rMoto = (int)Motorista.NOA;
                rRevend = (int)Revendedor.NOA;
                rMovimen = (int)Movimentacao.NOA;
                rVeiculo = (int)Veiculo.NOA;
                rVeiculoCarga = (int)VeiculoCarga.NOA;
                rVeiculoPasseio = (int)VeiculoPasseio.NOA;
                break; 
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
        
    public void VerificarMetrica()
    {
        if (BotaoEnviarText.text == "Enviar resposta") {
            if (TentativasRestantes > 1 && MaquinaBloqueada == 0 && Bloqueios < 3) {
                if (mManutencao.value == rManu
                    &&
                    mMotorista.value == rMoto
                    &&
                    mMovimentacao.value == rMovimen
                    &&
                    mRevendedor.value == rRevend
                    &&
                    mVeiculo.value == rVeiculo
                    &&
                    mVeiculoCarga.value == rVeiculoCarga
                    &&
                    mVeiculoPasseio.value == rVeiculoPasseio
                    &&
                    MetricaNome.value == IndexNomeMetrica) {
                    MensagemAcerto ();
                } else {
                    TentativasRestantes--;
                    AtualizaTentativas (); 
                }
            } else {
                MensagemErro ();
            }
        } 
        else if (BotaoEnviarText.text == "FALAR COM SONNY!") {
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
        TentativasLabel.color = Color.green;
        TentativasLabel.text = "MÉTRICAS CORRETAS, NÚMERO DE MÉTODOS ENVIADO PARA ANALISE DE DUCK";
        mManutencao.enabled = false;
        MetricaNome.enabled = false;
        BotaoEnviarText.text = "PRÓXIMA TAREFA"; 
        var tentativas = TarefaAtual+ 1;
        xmlLib.CriarXML (Bloqueios, tentativas, 0);
    }

    public void MensagemErro()
    {
        //panelEnviar.SetActive (false);
        //panelCenas.SetActive (true);
        var xmlLib = new XMLLib ();
        mManutencao.enabled = false;
        MetricaNome.enabled = false;
        BotaoEnviarText.text = "FALAR COM SONNY!";
        TentativasLabel.text = "MÁQUINA BLOQUEADA, PEÇA AJUDA AO SONNY";
        TentativasLabel.color = Color.red;
        var blo = Bloqueios+ 1;
        xmlLib.CriarXML (blo, TarefaAtual, 1);
        MaquinaBloqueada = 1;
        panelCenas.SetActive (false);
        //TextBotaoEnviar.text = "FALAR COM SONNY";
    }
     
    public void Despedito()
    {        
        mManutencao.enabled = false;
        MetricaNome.enabled = false;
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

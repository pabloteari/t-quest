using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Collections.Generic;

public class CenaDuck : MonoBehaviour {
	
	public string Dialogo;

	public Text[] Baloes;
	public Text BalaoAtual;
    float LPS = 18;
    float tempo = 1;
    int i;
    public int tarefaAtual = 0;
    public int bloqueios = 0;
    public int maquinaBloqueada = 0;
    bool trocaCena = false;    
    public GameObject irParaCenaSoony;


    // Use this for initialization
	void Start ()
	{
        var xmlLib = new XMLLib ();        
        var processo = xmlLib.isXmlExist();

        tarefaAtual = processo.tarefaAtual;
        bloqueios = processo.bloqueios;
        maquinaBloqueada = processo.maquinaBloqueada;

//        XmlTextReader reader = new XmlTextReader("123ada7123.xml");
//
//        while (reader.Read())
//        {
//            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Bloqueios")
//            {
//                bloqueios = int.Parse(reader.ReadString());
//            }
//            if (reader.NodeType == XmlNodeType.Element && reader.Name == "TarefaAtual")
//            {
//                tarefaAtual = int.Parse(reader.ReadString());
//            }
//            if (reader.NodeType == XmlNodeType.Element && reader.Name == "MaquinaBloqueada")
//            {
//                maquinaBloqueada = int.Parse(reader.ReadString());
//            }
//        }
//        reader.Close();


        irParaCenaSoony.SetActive(false);
        switch (tarefaAtual) 
        {
        case 0:
            Dialogo = 
            "-0 Olá Estágiario, seja bem vindo a Recycle Factory. Meu nome é Duck, e sou o gerente da área de qualidade de software desta fábrica. Nós estamos com problemas no desempenho de nosso sistema, e precisamos de seu conhecimento em Métricas de Software para que possamos melhorar está questão" +
            "-1" +
            "Obrigado, farei o possível para colaborar com a empresa." +
            "-2" +
            "Serão entregue algumas tarefas a você, com prazo determinado para entrega, espero que cumpra todos os prazos, pois com o atrasado perderemos clientes/contratos." +
            "-3 Primeira Tarefa: Estamos tendo PROBLEMAS COM NÚMERO DE MÉTODOS que as classes contidas em nosso sistema estão recebendo, preciso que você faça uma ANÁLISE UML EM SUA MÁQUINA, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 0, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 1:
            Dialogo = 
             "-0 Obrigado pela métrica WMC enviada , estamos analisando esses métodos, mas ainda preciso de você!" +
            "-1" +
            "Sr.Duck! Posso ajudar mais em que ?" +
            "-2" +
            "Segunda Tarefa: Estamos tendo problemas com o MAU USO DE HERANÇA que nosso código está recebendo, nossas classes estão apresentando um grau de complexidade fora do normal, isso pode estar sendo causado pelo MAU USO DE HERENÇA herdando muitos serviços, preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 1, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 2:
            Dialogo = 
                "-0 Obrigado pela métrica DIT enviada , estamos anaisando as heranças desencessarias em nosso código, mas ainda preciso de você!" +
                "-1" +
                "Sr.Duck! Posso ajudar mais em que ?" +
                "-2" +
                "Terceira Tarefa: Estamos tendo PROBLEMAS COM NÚMEROS DE FILHOS que nossas classes estão recebendo, um alto número de filhos diretos pode indicar diretamente em problemas estrutuais, preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            irParaCenaSoony.SetActive (true);
            xmlLib.CriarXML(bloqueios, 2, maquinaBloqueada);
            break;
        case 3:
            Dialogo = 
                "-0 Obrigado pela métrica NOC enviada , estamos analisando o númeero de filhos em nossos classes, mas ainda preciso de você!" +
                "-1" +
                "Sr.Duck! Posso ajudar mais em que ?" +
                "-2" +
                "Quarta Tarefa: Estamos tendo problemas com o NÚMERO DE ACOPLAMENTOS que nossas classes estão recebendo, Quanto maior a ligação entre elas, menor a possibilidade de reutilização, pois a classe torna-se dependente de outras classes para cumprir suas obrigações. Preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 3, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 4:
            Dialogo = 
                "-0 Obrigado pela métrica CBO enviada , estamos analisando o numero de acoplamentos em nossas classes, mas ainda preciso de você!" +
                "-1" +
                "Sr.Duck! Posso ajudar mais em que ?" +
                "-2" +
                "Quinta Tarefa: Estamos tendo problemas com REDEFINIÇÕES DE MÉTODOS NAS CLASSES FILHA, você terá que analisar o NÚMERO DE REDEFINIÇÕES QUE OS MÉTODOS DAS CLASSES FILHAS ESTÃO RECEBENDO. Indicando um problema estrutural, se muitas subclasses tem seus serviços redefinidos, elas provavelmente estão sendo mal projetadas. Preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 4, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 5:
            Dialogo = 
                "-0 Obrigado pela métrica CS enviada , estamos analisando os métodos redefinidos nas classes filhas, mas ainda preciso de você!" +
                "-1" +
                "Sr.Duck! Posso ajudar mais em que ?" +
                "-2" +
                "Sexta Tarefa:Estamos tendo problemas com o NÚMERO DE SERVIÇOS/MÉTODOS E ATRIBUTOS ADICIONADO NAS SUBCLASSES, você terá que analisar o NÚMERO DE SERVIÇOS/MÉTODOS E ATRIBUTOS NOVOS QUE UMA CLASSE FILHA POSSOU E SEU PAI NÃO. Esta ocorrência demonstra que a classe não está bem posicionada na hierarquia, já que suas características principais deveriam estar implícitas em seus ancestrai. Preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 5, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 6:
            Dialogo = 
                "-0 Obrigado pela métrica NOO enviada , estamos analisando o número de métodos e atributos desnecessarios, mas ainda preciso de você!" +
                "-1" +
                "Sr.Duck! Posso ajudar mais em que ?" +
                "-2" +
                "Sexta Tarefa:Estamos tendo problemas com o NÚMERO DE ATRIBUTO E MÉTODO QUE NOSSAS CLASSES ESTÃO RECEBENDO, você terá que analisar o NÚMERO DE SERVIÇOS/MÉTODOS E ATRIBUTOS LOCAIS E HERDADOS DE UMA SUPERCLASS. Quanto maior a ligação entre elas, menor a possibilidade de reutilização, pois a classe torna-se dependente de outras classes para cumprir suas obrigações. Preciso que você faça uma análise, caso tenha alguma dúvida solicite à ajuda de Sonny ou estude os materiais disponibilizados pela empresa";
            xmlLib.CriarXML(bloqueios, 6, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 7:
            Dialogo = 
                "-0 Bit, como o ultimo desafio, preciso que nalise qual classe esta pesando em nosso sistema" +
                "-1" +
                "Sr.Duck! Apenas fiz meu trabalho, bom que gostaram" +
                "-2" +
                "Com tudo isso, asdasdasdê. Parabéns pela conquista!";
            xmlLib.CriarXML(bloqueios, 7, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 8:
            Dialogo = 
                "-0 Bit, todos da nossa equipe vimos seus resultados, e infelizmente não poderemos te efetivar agora!" +
                "-1" +
                "Sr.Duck! Sim, reconheço, preciso estudar mais! :(" +
                "-2" +
                "Com tudo isso, peço que se retire da minha sala, seu estrume\t imundo";
            xmlLib.CriarXML(bloqueios, 8, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        case 9:
            Dialogo = 
                "-0 Bit, todos da nossa equipe vimos resultados fantásticos com as Métricas enviadas por você, e hoje conseguimos grandes melhoras em nossos sistema, com as metricas conseguimos ter uma visão melhor do problema." +
                "-1" +
                "Sr.Duck! Apenas fiz meu trabalho, bom que gostaram" +
                "-2" +
                "Com tudo isso, queremos você trabalhando efetivamente conosco, precisamos de você. Parabéns pela conquista!";
            xmlLib.CriarXML(bloqueios, 9, maquinaBloqueada);
            irParaCenaSoony.SetActive (true);
            break;
        }
            
        Baloes[0].text = "";
        Baloes[1].text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
        //if (trocaCena == true)
        //{
        //	MoveToScena2();
        //}
		ConversaBitDuck();
    }

    void ConversaBitDuck()
    {
        tempo += Time.deltaTime;
		if(tempo > (1f / LPS) && i < Dialogo.Length)
        {
			// if que controla a troca dos indices dos Baloes
			if(Dialogo[i] == '-')
            {
				// Após o char ter se deparado com o sinal de '-' ele faz um i++ jogando para o número que fica ao seu lado.
                i++;
				// faz a conversão do char para int
				int novoBalao = Dialogo[i];
				// artifício para conversao do número que está como char se tornar um int
                novoBalao -= 48; 

                if(novoBalao == 4)
                {
                    
                    //trocaCena = true;
                }

				//definição de qual balão está sendo o atual.
                BalaoAtual = Baloes[novoBalao];
                if (novoBalao == 2 || novoBalao == 3)
                {
                    Baloes[2].text = "";
                }   
            }
            else
            {
                if(trocaCena == false)
                {
					// Faz o input do texto lido no txt e joga ele no Balão de fala do jogo
					BalaoAtual.text += Dialogo[i]; 
                }
            }
            tempo = 0;
            i++;
        }
    }

    public void MoveToScena2()
    {
        SceneManager.LoadScene("Scena2");
    }

    private void CriarXML()
    {
        XmlTextWriter writer = new XmlTextWriter("123ada7123.xml", System.Text.Encoding.UTF8);
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;
        writer.WriteStartElement("Table");
        createNode("0", "0", "0", writer);
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
    }

    private void createNode(string bloqueio, string tarefaAtual, string maquinaBloqueada, XmlTextWriter writer)
    {
        writer.WriteStartElement("GamaSave");
        writer.WriteStartElement("Bloqueios");
        writer.WriteString(bloqueio);
        writer.WriteEndElement();
        writer.WriteStartElement("TarefaAtual");
        writer.WriteString(tarefaAtual);
        writer.WriteEndElement();
        writer.WriteStartElement("MaquinaBloqueada");
        writer.WriteString(maquinaBloqueada);
        writer.WriteEndElement();
    }
}

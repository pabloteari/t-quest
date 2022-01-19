using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeTxtDescricao : MonoBehaviour {

    public string TextoArquivo;
    float LPS = 40;
    float tempo = 0;
    int i;
    public bool ativa;
    public GameObject panelBotoes;
    
    
    public Text[] Baloes;
    public Text BalaoAtual;




    // Use this for initialization
    void Start()
    {
        
        panelBotoes.SetActive (false);
        TextoArquivo = "-0      O jogo se baseia no início de carreira de um jovem chamado \"Bit\", " +
                       "que está finalizando sua graduação em Sistemas de Informação, com sua " +
                       "dedicação e esforço ele consegue uma vaga de estágio em uma fábrica de " +
                       "software de grande porte, Recycle Factory, referência em muitas " +
                       "localidades do mundo. O setor no qual o protagonista ingressará é a de " +
                       "Quality Assurance (QA), na qual ele terá a oportunidade de aplicar seu " +
                       "conhecimento em Teste de software, habilidades em métricas de Teste de " +
                       "Software criadas por Lorenz & Kidd, Chidamber & Kemerer." +
                       "O objetivo de Bit é ser contratado, " +
                       "porém para que isso se concretize ele terá que mostrar suas habilidades " +
                       "e conhecimentos em vários desafios que lhe são propostos durante o jogo, " +
                       "aplicando corretamente cada técnica em seu momento apropriado.";



        Baloes[0].text = "";

    }

    // Update is called once per frame
    void Update()
    {

        

        leTextoArquivo();

        if (i == TextoArquivo.Length)
        {

            panelBotoes.SetActive (true);
            
        }
        


    }

    void leTextoArquivo()
    {
       
        tempo += Time.deltaTime;
        if (tempo > (1f / LPS) && i < TextoArquivo.Length)
        {
            if (TextoArquivo[i] == '-') // if que controla a troca dos indices dos Baloes
            {
                i++; // Após o char ter se deparado com o sinal de '-' ele faz um i++ jogando para o número que fica ao seu lado.
                int novoBalao = TextoArquivo[i]; // faz a conversão do char para int
                novoBalao -= 48; // artifício para conversao do número que está como char se tornar um int

                BalaoAtual = Baloes[novoBalao]; //definição de qual balão está sendo o atual.


            }
            else
            {
                BalaoAtual.text += TextoArquivo[i]; // Faz o input do texto lido no txt e joga ele no Balão de fala do jogo
            }


            tempo = 0;
            i++;

            

        }
    }
}

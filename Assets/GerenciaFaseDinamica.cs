using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

/*
 
Fases: Anotação do Mrs Siedler
    Fase 1 - contar até 10
    Fase  2 - até 10 aleatório (5 telas)
    Fase  3 - de 11 a 20 - (sequencial)
    Fase 4 - de 1 a 20 (5 telas)
 */

public class GerenciaFaseDinamica : MonoBehaviour
{
    //Dicionários



    string[] ambientesDisponiveis = 
    {
        "Fazenda",
        "Artico",
        "Mar",
        "Egito",
        "Espaco"

    };


    string[] fazendaClicaveis =
    {
        "Galinha",
        "Galo",
        "Pinto",
        "Vaca",
        "Ovelha",
        "Abelha"
    };

    string[] articoClicaveis =
    {
        "Leao_marinho",
        "Pinguim"
    };

    string[] marClicaveis =
    {
        "Peixe_espada",
        "Peixe_espada_2",
        "Polvo"
    };

    string[] egitoClicaveis =
    {
        "Mumia"
    };

    string[] espacoClicaveis =
    {
        "et_amarelo",
        "et_verde",
        "et_vermelho"
    };


    int cenarioLmtFazenda = 6;
    int cenarioLmtArtico = 1;
    int cenarioLmtEgito = 3;
    int cenarioLmtEspaco = 1;
    int cenarioLmtFlorestaFadas = 3;
    int cenarioLmtMar = 6;


    // Constantes!
    const string mensagemTutorialTexto = "Selecione a quantidade correta indicada!";
    const string tagInstanciar = "instanciar";
    const string tagNroHud = "nroHud";
    const string tagLogoAnimal = "logoAnimal";
    const string tagTutorialTexto = "tutorialTexto";
    const string tagBackground = "background";

    //Cosntante default Path's

    const string PATHCENARIOS = "All/Sprites/Cenarios" ;


    // Configuração do HUD
    private GameObject nroHud;
    private GameObject tutorialTexto;
    private GameObject logoAnimal;
    private GameObject background;

    //Parâmetros fase:
    [SerializeField] private string cenaAtualNome;
    [SerializeField] private string cenaProxNome;


    private int itens_clicarMax = 0;
    //Parâmetros controle fase
    private static int itens_clique;
    private static int itens_clicarMax_static;

    //GameObjects Load
    List<GameObject> itens = new List<GameObject>();

    //Variáveis de acesso externo:
    private static string cenaProxNome_static;
    private static GameObject gameObject_static;
    //public static Text textoHud_static;


    void Start()
    {
        // Reconhecendo os itens sozinho! Algumas fn foram modificadas do script anterior.
        this.loadItensFase();
        //Inicializando qtd e parâmetros
        itens_clicarMax = sortearQtdMax();
        itens_clique = 0;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        gameObject_static = this.gameObject;
        itens_clicarMax_static = itens_clicarMax;
        // textoHud_static = this.nroHud;
    }


    public static async void passarFase()
    {
        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral", gameObject_static);
        Debug.Log("ItensCLique:" + itens_clique);

        if (itens_clique == itens_clicarMax_static)
        {
            await Task.Delay(200);
            reprodutor.reproduzirArquivo("muito_bem");
            await Task.Delay(2000);
            SceneManager.LoadScene(cenaProxNome_static);
            itens_clique = 0;
            return;
        }
        reprodutor.reproduzirArquivo("tentar_novamente");

    }

    public static void acrescentarClique()
    {
        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral", gameObject_static);

        reprodutor.reproduzirArquivo("sound_acerto");
        itens_clique++;
    }

    public static void removerClique()
    {
        itens_clique--;
        ;
    }

    private void configurarSprites()
    {

        string ambienteSorteado = sortearAmbiente();
        string spriteSorteada = sortearSprites(ambienteSorteado);
        string cenarioSorteado = sortearCenario(ambienteSorteado);
       


        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("All/Sprites/" + ambienteSorteado + '/' + spriteSorteada.ToLower());
        }

        background.GetComponent<Image>().sprite = Resources.Load<Sprite>("All/Sprites/" + ambienteSorteado + '/' + cenarioSorteado.ToLower());
        logoAnimal.GetComponent<Image>().sprite = itens[0].GetComponent<Image>().sprite;
    }


    private void adicionandoComponentes()
    {
        GameObject[] todosFilhos = GameObject.FindGameObjectsWithTag(tagInstanciar);
        foreach (GameObject item in todosFilhos)
        {
            itens.Add(item);
        }
    }


    private void loadItensFase()
    {
        nroHud = GameObject.FindGameObjectWithTag(tagNroHud);
        tutorialTexto = GameObject.FindGameObjectWithTag(tagTutorialTexto);
        logoAnimal = GameObject.FindGameObjectWithTag(tagLogoAnimal);   
        background = GameObject.FindGameObjectWithTag(tagBackground);

        //Configurando os gameObjects
        nroHud.GetComponent<Text>().text = itens_clicarMax.ToString();
        tutorialTexto.GetComponent<Text>().text = "Selecione a quantidade correta!";


        adicionandoComponentes();
        configurarSprites();
    }

    private string sortearAmbiente()
    {
        System.Random genRand = new System.Random();
        return ambientesDisponiveis[genRand.Next(0,ambientesDisponiveis.Length - 1)];
    }
    private string sortearSprites(string ambiente)
    {

        System.Random genRand = new System.Random();
        /*
         "Fazenda",
        "Artico",
        "Mar",
        "Egito",
        "Espaco"
         */


        switch (ambiente)
        {
            case "Fazenda":
                return fazendaClicaveis[genRand.Next(0,fazendaClicaveis.Length - 1)];
            case "Artico":
                return articoClicaveis[genRand.Next(0, articoClicaveis.Length - 1)];
            case "Mar":
                return marClicaveis[genRand.Next(0, marClicaveis.Length - 1)];
            case "Egito":
                return egitoClicaveis[genRand.Next(0, egitoClicaveis.Length - 1)];
            case "Espaco":
                return espacoClicaveis[genRand.Next(0, espacoClicaveis.Length - 1)];
        }

        return "null";
    }

    private int sortearQtdMax()
    {
        System.Random genRand = new System.Random();
        return genRand.Next(1,itens.Count);
    }

    private string sortearCenario(string ambiente)
    {
        System.Random genRand = new System.Random();
        switch (ambiente)
        {
            case "Fazenda":
                return( PATHCENARIOS + '/' + ambiente + '/' + "cenario" + genRand.Next(1,cenarioLmtFazenda)) ;
            case "Artico":
                return (PATHCENARIOS + '/' + ambiente + '/' + "cenario" + genRand.Next(1, cenarioLmtArtico));
            case "Mar":
                return (PATHCENARIOS + '/' + ambiente + '/' + "cenario" + genRand.Next(1, cenarioLmtMar));
            case "Egito":
                return (PATHCENARIOS + '/' + ambiente + '/' + "cenario" + genRand.Next(1, cenarioLmtEgito));
            case "Espaco":
                return (PATHCENARIOS + '/' + ambiente + '/' + "cenario" + genRand.Next(1, cenarioLmtEspaco));
        }

        return "null";
    }
}

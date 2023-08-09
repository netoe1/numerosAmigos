using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEditor.Tilemaps;

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


    // Constantes!
    const string mensagemTutorialTexto = "Selecione a quantidade correta indicada!";
    const string tagInstanciar = "instanciar";
    const string tagNroHud = "nroHud";
    const string tagLogoAnimal = "logoAnimal";
    const string tagTutorialTexto = "tutorialTexto";

    //Constante default Path's


    // Configuração do HUD
    private GameObject nroHud;
    private GameObject tutorialTexto;
    private GameObject logoAnimal;

    //Parâmetros fase:
    [SerializeField] private string cenaAtualNome;
    [SerializeField] private string cenaProxNome;
    [SerializeField] private string tipoFase;


    private int itens_clicarMax = 0;
    //Parâmetros controle fase
    private static int itens_clique;
    private static int itens_clicarMax_static;

    //GameObjects Load
    List<GameObject> itens = new List<GameObject>();

    //Variáveis de acesso externo

    public static string cenaProxNome_static { get; set; } 

    private static GameObject gameObject_static;
    //public static Text textoHud_static;


    void Start()
    {
        // Reconhecendo os itens sozinho! Algumas fn foram modificadas do script anterior.
        this.loadItensFase();
        //Inicializando qtd e parâmetros
        itens_clicarMax = sortearQtdMax() ;
        itens_clique = 0;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        gameObject_static = this.gameObject;
        itens_clicarMax_static = itens_clicarMax;

        // textoHud_static = this.nroHud;
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
        string spriteSorteada = sortearSprites(this.tipoFase);
 
        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("All/Sprites/Animais/" + this.tipoFase + '/' + spriteSorteada.ToLower());
           //Debug.LogError("All/Sprites/Animais/" + ambienteSorteado + '/' + spriteSorteada.ToLower());
        }
        logoAnimal.GetComponent<Image>().sprite = itens[0].GetComponent<Image>().sprite;
    }


    private void loadItensFase()
    {
        nroHud = GameObject.FindGameObjectWithTag(tagNroHud);
        tutorialTexto = GameObject.FindGameObjectWithTag(tagTutorialTexto);
        logoAnimal = GameObject.FindGameObjectWithTag(tagLogoAnimal);   

        //Configurando os gameObjects
        nroHud.GetComponent<Text>().text = itens_clicarMax.ToString();
        tutorialTexto.GetComponent<Text>().text = "Selecione a quantidade correta!";

        GameObject[] todosFilhos = GameObject.FindGameObjectsWithTag(tagInstanciar);
        foreach (GameObject item in todosFilhos)
        {
            itens.Add(item);
        }

        configurarSprites();
    }
    private string sortearSprites(string ambiente)
    {

        System.Random genRand = new System.Random();

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

        Debug.LogError("A string de ambiente que você colocou não é valida!");
        return "Erro!";
    }
    private int sortearQtdMax()
    {
        System.Random genRand = new System.Random();
        return genRand.Next(1,itens.Count);
    }
}

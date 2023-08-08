using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

/*  Tipos de fase válidos:
 *  Ceu;
 *  Agua;
 *  Egito;
 *  Fazenda;
 *  FlorestaFadas;
 *  Mar;
 *  Paisagem;
 */

/*
 
Fases
    Fase 1 - contar até 10
    Fase  2 - até 10 aleatório (5 telas)
    Fase  3 - de 11 a 20 - (sequencial)
    Fase 4 - de 1 a 20 (5 telas)
 */


public class GerenciaJogo : MonoBehaviour
{
    // Constantes!
    const string mensagemTutorialTexto = "Selecione a quantidade correta indicada!";


    // Configuração do HUD

    [SerializeField] private Text nroHud;
    [SerializeField] private Text tutorialTexto;
    [SerializeField] private Image logoAnimal;


    //Parâmetros fase:
    [SerializeField] private string cenaAtualNome;
    [SerializeField] private string cenaProxNome;
    [SerializeField] private int itens_clicarMax;
    //Parâmetros controle fase
    private static int itens_clique;
    private static int itens_clicarMax_static;

    //GameObjects Load
    [SerializeField] List<GameObject> itens;

    //Variáveis de acesso externo:
    private static string cenaProxNome_static;
    private static GameObject gameObject_static;
    //public static Text textoHud_static;

    // Pré Configurações sprites.

    [SerializeField] private string spriteParaCarregar_Animal;


    void Start()
    {
      
        System.Random genRand = new System.Random();
        //Inicializando parâmetros.
        itens_clique = 0;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        gameObject_static = this.gameObject;
        itens_clicarMax_static = itens_clicarMax;
        // textoHud_static = this.nroHud;

        nroHud.text = itens_clicarMax.ToString();


        tutorialTexto.text = mensagemTutorialTexto;
        this.configurarSprites();
    }

  
    public static async void passarFase()
    {
        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral",gameObject_static);
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
        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral",gameObject_static);
      
        reprodutor.reproduzirArquivo("sound_acerto");
        itens_clique++;
    }

    public static void removerClique()
    {
        itens_clique--;
;    }

    private void configurarSprites()
    {

        for (int i = 0;i < itens.Count;i++)
        {
            itens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(spriteParaCarregar_Animal);
        }
        logoAnimal.sprite = itens[0].GetComponent<Image>().sprite;
    }
}

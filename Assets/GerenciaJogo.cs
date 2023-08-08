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


public class GerenciaJogo : MonoBehaviour
{
    // Configuração do HUD

    [SerializeField] private Text textoHud;
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



    //Itens especiais


    void Start()
    {
      
        System.Random genRand = new System.Random();
        //Inicializando parâmetros.
        itens_clique = 0;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        gameObject_static = this.gameObject;
        itens_clicarMax_static = itens_clicarMax;
        // textoHud_static = this.textoHud;

        if(itens_clicarMax_static != 1)
        {
            textoHud.text = "Selecione "
            + itens_clicarMax_static
            + " animais!";
        }
        else
        {
            textoHud.text = "Selecione "
            + itens_clicarMax_static
            +  " animal!";
        }


        tutorialTexto.text = "Toque nos animais para selecioná-los!";
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

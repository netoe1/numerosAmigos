using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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


    private static string[] numerosPorExtenso = {
                    "Um", "Dois", "Três", "Quatro", "Cinco",
                    "Seis", "Sete", "Oito", "Nove", "Dez", "Onze",
                    "Doze","Treze","Quatorze","Quinze","Dezesseis",
                    "Dezessete","Dezoito","Dezenove","Vinte"
                    };
    


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
            + numerosPorExtenso[itens_clicarMax_static - 1]
            + " animais!";
        }
        else
        {
            textoHud.text = "Selecione "
            + numerosPorExtenso[itens_clicarMax_static - 1]
            +  " animal!";
        }
        
        this.configurarSprites();
    }

  
    public static void passarFase()
    {

        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral", gameObject_static);
        if (itens_clique == itens_clicarMax_static)
        {
            reprodutor.reproduzirArquivo("muito_bem");
            reprodutor.reproduzirArquivo("sound_acerto");
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
    }

}

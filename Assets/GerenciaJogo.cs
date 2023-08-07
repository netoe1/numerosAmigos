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
    //Parâmetros fase:
    [SerializeField] private string cenaAtualNome;
    [SerializeField] private string cenaProxNome;
    //Parâmetros controle fase
    private static int itens_clique;
    private static int itens_clicarMax;

    //GameObjects Load
    [SerializeField] List<GameObject> itens;

    //Variáveis de acesso externo:
    private static string cenaProxNome_static;
    private static GameObject gameObject_static;

    // Pré Configurações sprites.

    [SerializeField] private string spriteParaCarregar_Animal;

    void Start()
    {

        //Inicializando parâmetros.
        itens_clique = 0;
        itens_clicarMax = itens.Count;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        gameObject_static = this.gameObject;

        this.configurarSprites();
    }

  
    public static void passarFase()
    {

        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral", gameObject_static);
        if (itens_clique == itens_clicarMax)
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
      
        if(itens_clique + 1 <= itens_clicarMax)
        {
            reprodutor.reproduzirArquivo("sound_acerto");
            itens_clique++;
            return;
        }
       
    }

    public static void removerClique()
    {
        if (itens_clique - 1 >= 0)
        {
            itens_clique--;
        }
    }

    private void configurarSprites()
    {

        for (int i = 0;i < itens.Count;i++)
        {
            itens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(spriteParaCarregar_Animal);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;


/*
 
Fases: Anotação do Mrs Siedler
    Fase 1 - contar até 10
    Fase  2 - até 10 aleatório (5 telas)
    Fase  3 - de 11 a 20 - (sequencial)
    Fase 4 - de 1 a 20 (5 telas)
 */


public class GerenciaJogo : MonoBehaviour
{
    // Constantes!
    const string mensagemTutorialTexto = "Selecione a quantidade correta indicada!";
    const string tagInstanciar = "instanciar";
    private static bool permitirPassarCena = true;

    // Configuração do HUD
    [SerializeField] private Text nroHud;
    [SerializeField] private Text tutorialTexto;
    [SerializeField] private Image logoAnimal;
    [SerializeField] private Button passarDeFase_btn;
    [SerializeField] private Button voltarMenu_btn;

    //Parâmetros fase:
    [SerializeField] private string cenaAtualNome;
    [SerializeField] private string cenaProxNome;
    [SerializeField] private int itens_clicarMax;
    [SerializeField] private int codFase;
    
    //Parâmetros controle fase
    private static int itens_clique;
    private static int itens_clicarMax_static;

    //GameObjects Load
    List<GameObject> itens = new List<GameObject>();

    //Variáveis de acesso externo:
    private static GameObject gameObject_static; 
    private static string cenaProxNome_static;
    private static string cenaAtualNome_static;
    private static int codFase_static;
    // Pré Configurações sprites.

    [SerializeField] private string spriteParaCarregar_Animal;


    void Start()
    {
        //Configurando botões:
        this.passarDeFase_btn.onClick.AddListener(delegate ()
        {
            passarFase();
        });

        this.voltarMenu_btn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("menu2");
        });

        permitirPassarCena = true;

        // Reconhecendo os itens sozinho!
        adicionandoComponentes();
        System.Random genRand = new System.Random();
        //Inicializando parâmetros.
        itens_clique = 0;

        //Inicializando Objetos para acesso externo.
        cenaProxNome_static = cenaProxNome;
        cenaAtualNome_static = cenaAtualNome;
        codFase_static = codFase;
        gameObject_static = this.gameObject;
        itens_clicarMax_static = itens_clicarMax;
        // textoHud_static = this.nroHud;

        nroHud.text = itens_clicarMax.ToString();


        tutorialTexto.text = mensagemTutorialTexto;
        this.configurarSprites();
    }

  
    public static void passarFase()
    {
        ReprodutorSom reprodutor = new ReprodutorSom("Sounds/Geral",gameObject_static);
        Debug.Log("ItensCLique:" + itens_clique);
        GerenciaJogo instance = FindObjectOfType<GerenciaJogo>();



        if (permitirPassarCena)
        {
            if (itens_clique == itens_clicarMax_static)
            {
                if (cenaProxNome_static == "TelaMuitoBem")
                {
                    switch (codFase_static)
                    {
                        case 1:
                            Pontuacao.fase1_concluida = true;
                            break;
                        case 2:
                            Pontuacao.fase2_concluida = true;
                            break;
                        case 3:
                            Pontuacao.fase3_concluida = true;
                            break;
                        case 4:
                            Pontuacao.fase4_concluida = true;
                            break;
                        default:
                            throw new UnityException("Fase inválida nos parâmentros da fase.");
                    }

                }
                   
                permitirPassarCena = false;
                reprodutor.reproduzirArquivo("muito_bem");
                instance.StartCoroutine(waitForSound(reprodutor.audioSource));
                itens_clique = 0;
                return;
            }
            else
            {
                reprodutor.reproduzirArquivo("tentar_novamente");
            }
        }
        else
        {
            Debug.Log("Você já clicou para passar de fase!");
        }

        
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


    private void adicionandoComponentes()
    {
        GameObject[] todosFilhos = GameObject.FindGameObjectsWithTag(tagInstanciar);
        foreach(GameObject item in todosFilhos)
        {
            itens.Add(item);
        }
    }

    private static IEnumerator waitForSound(AudioSource audio)
    {
        //Wait Until Sound has finished playing
        while (audio.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(cenaProxNome_static);
    }

}

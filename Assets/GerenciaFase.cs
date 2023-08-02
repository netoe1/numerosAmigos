using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciaFase : MonoBehaviour
{


    [SerializeField] private string nomeCenaAtual;
    [SerializeField] private string proxCena;
    [SerializeField] private int qtdPassar;
    [SerializeField] private Text hud_text;
    [SerializeField] private Button btnPassarFase;
    [SerializeField] private Button btnSairFase;
    [SerializeField] private Button btnJogarNovamente;
    private static int qtdClicados;

    // Objetos de acesso externo
    private static int qtdPassar_static;
    private static string proxCena_static;
    private static Button btnPassarFase_static;
    private static Button btnJogarNovamente_static;
    private static string nomeCenaAtual_static;

    void Start()
    {

        nomeCenaAtual_static = nomeCenaAtual;
        btnPassarFase.onClick.AddListener(delegate ()
        {
            passarFase();
        });

        btnSairFase.onClick.AddListener(delegate ()
        {
            Debug.Log("Sair fase");
            // SceneManager.LoadScene("menu");
        });

        qtdClicados = 0;
        qtdPassar_static = qtdPassar;
        proxCena_static = proxCena;
        hud_text.text = qtdPassar.ToString();
        btnPassarFase_static = btnPassarFase;
    }

    public static void adicionarClique()
    {

        qtdClicados++;
        mostrarDados();
    }

    public static void removerClique()
    {
        qtdClicados--;
        mostrarDados();
    }

    public static async void passarFase()
    {
        if (btnPassarFase_static.GetComponent<AudioSource>() == null)
        {
            btnPassarFase_static.AddComponent<AudioSource>();
        }


        if (qtdClicados == qtdPassar_static)
        {
            await Task.Delay(250);
            btnPassarFase_static.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Geral/acerto_complemento");
            btnPassarFase_static.GetComponent<AudioSource>().playOnAwake = false;
            btnPassarFase_static.GetComponent<AudioSource>().Play();
            //while (btnPassarFase_static.GetComponent<AudioSource>().isPlaying);
            await Task.Delay(4000);
            SceneManager.LoadScene(proxCena_static);
            qtdClicados = 0;
            return;
        }

        await Task.Delay(250);
        btnPassarFase_static.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Geral/erro_complemento");
        btnPassarFase_static.GetComponent<AudioSource>().playOnAwake = false;
        btnPassarFase_static.GetComponent<AudioSource>().Play();
        await Task.Delay(4000);

    }

    private static void mostrarDados()
    {
        Debug.Log("Itens Clicados:" + qtdClicados);
    }

    public static void jogarNovamente()
    {
        if(btnJogarNovamente_static != null && nomeCenaAtual_static != null)
        {
            btnJogarNovamente_static.onClick.AddListener(delegate ()
            {
                SceneManager.LoadScene(nomeCenaAtual_static.ToString());
            });   
        }
    }
}
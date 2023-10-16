using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEditor;

public class ControllerItensClicados
{
    private static bool passarDeFase;
    public int itens_clicados { get; set; }
    public int itens_limite_fase { get; set; }
    public int LIMITE_CLICAR { get; set; }
    public ControllerItensClicados(int itens_limite_fase, int LIMITE_CLICAR)
    {
        passarDeFase = false;
        itens_clicados = 0;
        this.itens_limite_fase = itens_limite_fase;
        this.LIMITE_CLICAR = LIMITE_CLICAR;
    }

    public void removerItensClicados()
    {
        itens_clicados--;
    }

    public void acrescentarItensClicados()
    {
        itens_clicados++;
    }

    public void verItensClicados()
    {
        Debug.Log(this.itens_clicados);
    }

    public void resetarTudo()
    {
        itens_clicados = 0;
    }

    public void setLimiteClicar(int limiteClicar)
    {
        if (limiteClicar < 0)
        {
            limiteClicar = 1;
            return;
        }

        this.LIMITE_CLICAR = limiteClicar;

    }

    public void updateHud(Text text)
    {
        text.text = (LIMITE_CLICAR).ToString();
    }

    public static void setPassarDeFase()
    {
        passarDeFase = true;
    }

    public static bool getPassarDeFase()
    {
        return passarDeFase;
    }

}
public class CenaDinamica : MonoBehaviour
{

    private static bool permitirPassarFase;

    /* Controlador de inicializa��o*/

    [SerializeField] private string nomeCena;
    [SerializeField] private string tipoFase;
    [SerializeField] private string proximaCena;

    /*Vari�veis auxiliares*/
    private static GameObject gameobject_ext;

    /*Constantes auxiliares*/

    /* Vari�veis inspector*/
    [SerializeField] private Text GetHud;
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private static Text hud_text;
    [SerializeField] private Button botao_sair;
    [SerializeField] private Button botao_verificar;
    [SerializeField] private Button botao_qtdNumeros;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject textoTutorial;


    /*Objetos auxili�res*/

    private static ControllerItensClicados itensClicados;
    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase;
    private SpritePath path_sprites;

    //  Objetos Privados!

    ReprodutorSom rs_cliqueBotao;

    void Start()
    {
        //  Configurando clicar do bot�o!
        rs_cliqueBotao = new ReprodutorSom("Sounds/Contagem",this.gameObject);
        permitirPassarFase = true;
        textoTutorial.GetComponent<Text>().text = "Selecione a quantidade correta!";
        
        // Criando os controladores auxiliares

        ctrlFase = new ConfigurarFase(1, nomeCena);
        path_sprites = new SpritePath("All/Sprites/Animais/" + tipoFase, null, "Selecionar Animais");

        // Configurando bot�es

        botao_verificar.onClick.AddListener(delegate (){verificarFase();});
        botao_qtdNumeros.onClick.AddListener(delegate (){rs_cliqueBotao.reproduzirArquivo(itensClicados.LIMITE_CLICAR.ToString());});
 
        gameobject_ext = this.gameObject;
        hud_text = GetHud;


        sortearAnimalInstanciar.addAnimaisPadrao(tipoFase);
        sortearAnimalInstanciar.sortearAnimal(tipoFase);

        //path_sprites.spriteLog();
        this.hudConfig();
        itensClicados.updateHud(hud_text);

        for (int i = 0; i < obj.Count; i++)
        {
            path_sprites.loadIntoGameObject(obj[i], sortearAnimalInstanciar.ultimoAnimalSorteado());
        }
        path_sprites.loadIntoGameObject(logo,sortearAnimalInstanciar.ultimoAnimalSorteado());
        path_sprites.spriteLog();
        controllerLog();

        hud_text.text = itensClicados.LIMITE_CLICAR.ToString();

    }
    /*
        API para outras classes.
     */

    public static void external_adicionarClicado()
    {
        itensClicados.acrescentarItensClicados();
        itensClicados.verItensClicados();
        //Debug.LogWarning(itensClicados.itens_clicados.ToString());
    }
    public static void external_removerClicado()
    {
        itensClicados.removerItensClicados();
        itensClicados.verItensClicados();
    }
    public static string external_getTextHud()
    {
        return hud_text.text;
    }

    /* M�todos para componentes .*/

    void hudConfig()
    {
        hud_text = GetHud;
        itensClicados = new ControllerItensClicados(obj.Count,sortearNroDeItensParaClicar());
    }

    void controllerLog()
    {
        Debug.Log("CONTROLLER:Fase Atual ->" + ctrlFase.fase_atual);
        Debug.Log("CONTROLLER:OBJ Instanciados ->" + obj.Count);
    }

    int sortearNroDeItensParaClicar()
    {
        int retorno;
        System.Random rnd = new System.Random();
        retorno = rnd.Next(1, obj.Count);
        return retorno;
    }

    async void verificarFase()
    {
        const int tempoDelay = 2000;
        ReprodutorSom aux = new ReprodutorSom("Sounds/Geral", this.gameObject);
        Debug.Log("Clicados:" +itensClicados.itens_clicados);
        Debug.Log("Limite:" + itensClicados.itens_limite_fase);

        if (permitirPassarFase)
        {
            if (itensClicados.itens_clicados == itensClicados.LIMITE_CLICAR)
            {
                permitirPassarFase = false;
                ctrlFase.acrescentarFase();
                aux.reproduzirArquivo("muito_bem");
                await Task.Delay(tempoDelay);
                SceneManager.LoadScene(proximaCena);
                return;

            }
            else
            {
             aux.reproduzirArquivo("tentar_novamente");
             await Task.Delay(tempoDelay);
            }
        }
        else
        {
            Debug.Log("Voc� j� clicou pra passar de fase!");
        }
       
        return;
    }
}

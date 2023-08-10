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
        if (itens_clicados - 1 >= 0)
        {
            itens_clicados--;
        }
    }

    public void acrescentarItensClicados()
    {
        if (itens_clicados + 1 <= LIMITE_CLICAR)
        {
            itens_clicados++;
        }
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

    /* Controlador de inicialização*/

    int indice_repete_fase = 0;
    [SerializeField] private string nomeCena;
    [SerializeField] private string tipoFase;
    [SerializeField] private string proximaCena;

    /*Variáveis auxiliares*/
    private static GameObject gameobject_ext;

    /*Constantes auxiliares*/

    /* Variáveis inspector*/
    [SerializeField] private Text GetHud;
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private static Text hud_text;
    [SerializeField] private GameObject popup;
    [SerializeField] private Button botao_sair;
    [SerializeField] private Button botao_verificar;
    [SerializeField] private GameObject logo;

    /*Objetos auxiliáres*/

    private static ControllerItensClicados itensClicados;
    private SortearAnimal sortearAnimalInstanciar = new SortearAnimal();
    private ConfigurarFase ctrlFase;
    private SpritePath path_sprites;

    void Start()
    {


        
        // Criando os controladores auxiliares

        ctrlFase = new ConfigurarFase(1, nomeCena);
        path_sprites = new SpritePath("All/Sprites/Animais/" + tipoFase, null, "Selecionar Animais");

        // Adicionar escuta ao botão

        botao_verificar.onClick.AddListener(delegate ()
        {
            verificarFase();
        });


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

        hud_text.text =itensClicados.LIMITE_CLICAR.ToString();

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

    /* Métodos para componentes .*/

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
        retorno = rnd.Next(obj.Count / 2, obj.Count);
        return retorno;
    }

    async void verificarFase()
    {
        const int tempoDelay = 1000;
        ReprodutorSom aux = new ReprodutorSom("Sounds/Geral", this.gameObject);
        Debug.Log("Clicados:" +itensClicados.itens_clicados);
        Debug.Log("Limite:" + itensClicados.itens_limite_fase);
        if (itensClicados.itens_clicados == itensClicados.LIMITE_CLICAR)
        {
            if (indice_repete_fase != 2)
            {
                ctrlFase.acrescentarFase();
                indice_repete_fase++;
                await Task.Delay(tempoDelay / 2);
                aux.reproduzirArquivo("muito_bem");
                await Task.Delay(tempoDelay);
                return;
            }

            indice_repete_fase = 0;

            if (proximaCena != null)
            {


                SceneManager.LoadScene(proximaCena);
                return;
            }

            Debug.Log("Passar de fase!");
            return;

        }
        await Task.Delay(tempoDelay / 2);
        aux.reproduzirArquivo("tentar_novamente");
        await Task.Delay(tempoDelay);
        return;
    }
}

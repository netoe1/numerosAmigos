using Unity.Loading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    enum FASE_NRO
    {
        FASE1 = 1,
        FASE2,
        FASE3,
        FASE4,
    }

    public static bool fase1_concluida = false;
    public static bool fase2_concluida = false;
    public static bool fase3_concluida = false;
    public static bool fase4_concluida = false;

    public Image fase1_button;
    public Image fase2_button;
    public Image fase3_button;
    public Image fase4_button;

    const string DEFAULT_PATH_ALL_BLACK_WHITE = "All/Sprites/Cenarios/PretoEbranco";
    const string DEFAULT_PATH_ALL_NORMAL = "All/Sprites/Cenarios";

    private void Start()
    {
        bool[] fases = { fase1_concluida, fase2_concluida, fase3_concluida, fase4_concluida };

        int i = 0;
        for(i = 0;i < fases.Length; i++)
        {
            if (fases[i])
            {
                this.returnToNormal(i + 1);
            }
            else
            {   
                this.fadeToBlackAndWhite(i + 1);
            }
        }
    }

    private void fadeToBlackAndWhite(int fase)
    {
        try
        {
            switch (fase)
            {
                case (int) FASE_NRO.FASE1:
                    fase1_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_BLACK_WHITE + "/fazenda_aberto");
                break;
                case (int)FASE_NRO.FASE2:
                    fase2_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_BLACK_WHITE + "/deserto");
                    break;
                case (int)FASE_NRO.FASE3:
                    fase3_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_BLACK_WHITE + "/fazenda_fechado");
                    break;
                case (int)FASE_NRO.FASE4:
                    fase4_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_BLACK_WHITE + "/oceano");
                    break;
                default:
                    throw new UnityException("Você inseriu um tipo inválido de fase.");
            }
        }
        catch(UnityException e)
        {
            throw e;
        }
    }

    private void returnToNormal(int fase)
    {
        try
        {
            switch (fase)
            {
                case (int)FASE_NRO.FASE1:
                    fase1_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_NORMAL + "/Fazenda/cenario5");
                    break;
                case (int)FASE_NRO.FASE2:
                    fase2_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_NORMAL + "/Egito/cenario1") ;
                    break;
                case (int)FASE_NRO.FASE3:
                    fase3_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_NORMAL + "/Fazenda/cenario2");
                    break;
                case (int)FASE_NRO.FASE4:
                    fase4_button.GetComponent<Image>().sprite = Resources.Load<Sprite>(DEFAULT_PATH_ALL_NORMAL + "/Mar/cenario6");
                    break;
                default:
                    throw new UnityException("Você inseriu um tipo inválido de fase.");
            }
        }
        catch (UnityException e)
        {
            throw e;
        }
    }

}

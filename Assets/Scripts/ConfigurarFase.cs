using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigurarFase
{
    private string NOME_CENA { get; set; }
    public int LIMITE_FASE { get; set; }
    public int fase_atual { get; set; } = 1;

    public ConfigurarFase(int __limite_fase, string nome_cena)
    {
        this.LIMITE_FASE = __limite_fase;
        this.NOME_CENA = nome_cena;
    }
    
    public void passarFase()
    {
        if (fase_atual + 1 > LIMITE_FASE)
        {
            SceneManager.LoadScene(NOME_CENA);
        }
        else if (fase_atual < LIMITE_FASE)
        {
            Debug.LogError("Não é possivel avançar de fase!");
        }
    }

    public bool acrescentarFase()
    {
        if (fase_atual + 1 <= LIMITE_FASE)
        {
            fase_atual++;
            return true;
        }
        return false;

    }

    public bool voltarFase()
    {
        if (fase_atual - 1 >= 0)
        {
            fase_atual--;
            return true;
        }
        return false;
    }

    public void resetarFase()
    {
        fase_atual = 1;
    }
}
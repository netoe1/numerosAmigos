using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redirectBtn : MonoBehaviour
{

    private bool reproduzirSom_resUi = false;
    public void fecharJogo()
    {
        Application.Quit();
        return;
    }

    public void selecionarCena(string nome_da_cena)
    {
        SceneManager.LoadScene(nome_da_cena);   
        return;
    }

    public void passarDeFase()
    {
        GerenciaJogo.passarFase();
    }

    public void tocarAudio(string qtd)
    {
        ReprodutorSom rp = new ReprodutorSom("Sounds/Contagem",this.gameObject);
        rp.reproduzirArquivo(qtd);
        
    }

    public void tocarAudio_resUI()
    {
        ReprodutorSom rp = new ReprodutorSom("Sounds/Geral", this.gameObject);
        rp.reproduzirArquivo("sound_acerto");
    }
}

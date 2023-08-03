using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redirectBtn : MonoBehaviour
{
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
}

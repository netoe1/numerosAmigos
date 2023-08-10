
using System.Collections.Generic;
using UnityEngine;

public class SortearAnimal
{

    private string ultimoSorteado;

    private List<string> animaisFazenda = new List<string>();
    private List<string> animaisAquatico = new List<string>();
    private List<string> animaisAntartica = new List<string>();

    private List<string> animaisSorteadosFazenda = new List<string>();
    private List<string> animaisSorteadosAquatico = new List<string>();
    private List<string> animaisSorteadosAntartica = new List<string>();

    public string sortearAnimal(string tipoAmbiente)
    {

        System.Random rnd = new System.Random();
        string aux = "undefined";


        switch (tipoAmbiente.ToLower())
        {
            case "fazenda":
                do
                {
                    aux = animaisFazenda[rnd.Next(0, animaisFazenda.Count - 1)].ToLower();
                }
                while (animaisSorteadosFazenda.Count < animaisFazenda.Count && animaisSorteadosFazenda.Contains(aux));

                if (animaisSorteadosFazenda.Count == animaisFazenda.Count)
                {
                    animaisSorteadosFazenda.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosFazenda.Add(aux);
                Debug.Log(aux);

                break;
            case "antartica":

                do
                {
                    aux = animaisAntartica[rnd.Next(0, animaisAntartica.Count - 1)].ToLower();
                }
                while (animaisSorteadosAntartica.Count < animaisAntartica.Count && animaisSorteadosAntartica.Contains(aux));

                if (animaisSorteadosAntartica.Count == animaisAntartica.Count)
                {
                    animaisSorteadosAntartica.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosAntartica.Add(aux);
                Debug.Log(aux);

                break;
            case "aquatico":

                do
                {
                    aux = animaisAquatico[rnd.Next(0, animaisAquatico.Count - 1)].ToLower();
                }
                while (animaisSorteadosAquatico.Count < animaisAquatico.Count && animaisSorteadosAquatico.Contains(aux));

                if (animaisSorteadosAquatico.Count == animaisAquatico.Count)
                {
                    animaisSorteadosAquatico.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosAquatico.Add(aux);
                Debug.Log(aux);

                break;
            default:
                Debug.LogError("Erro no switch do algoritmo sortear animal!");
                break;

        }

        return aux;
    }

    public void addAnimal(string tipoAmbiente, string str_animal)
    {
        bool cb = false;
        // Verificar se a string é valida!

        switch (tipoAmbiente.ToLower())
        {
            case "aquatico":
                if (!this.animaisAquatico.Contains(str_animal.ToLower()))
                {
                    this.animaisAquatico.Add(str_animal.ToLower());
                    return;
                }
                cb = true;
                break;
            case "antartica":
                if (!this.animaisAntartica.Contains(str_animal.ToLower()))
                {
                    this.animaisAntartica.Add(str_animal.ToLower());
                    return;
                }
                cb = true;
                break;
            case "fazenda":
                if (!this.animaisFazenda.Contains(str_animal.ToLower()))
                {
                    this.animaisFazenda.Add(str_animal.ToLower());
                    return;
                }
                cb = true;
                break;
            default:
                Debug.LogError("Digite um tipo de ambiente válido!");
                break;
        }

        if (cb)
        {
            Debug.LogError("O animal que você tentou inserir já existe!");
        }
    }

    public void addAnimaisPadrao(string tipoAmbiente)
    {


        string[] padraoFazenda = { "Abelha", "Galinha", "Galo", "Pinto" };
        string[] padraoAntartica = { "Pinguim", "Leao_marinho" };
        string[] padraoAquatico = { "Polvo", "Peixe_espada" };

        switch (tipoAmbiente.ToLower())
        {
            case "aquatico":
                for (int i = 0; i < padraoAquatico.Length; i++)
                {
                    if (!animaisAquatico.Contains(padraoAquatico[i].ToLower()))
                    {
                        animaisAquatico.Add(padraoAquatico[i]);
                    }
                }
                break;
            case "antartica":
                for (int i = 0; i < padraoAntartica.Length; i++)
                {
                    if (!animaisAntartica.Contains(padraoAntartica[i].ToLower()))
                    {
                        animaisAntartica.Add(padraoAntartica[i]);
                    }
                }
                break;
            case "fazenda":
                for (int i = 0; i < padraoAntartica.Length; i++)
                {
                    if (!animaisFazenda.Contains(padraoFazenda[i].ToLower()))
                    {
                        animaisFazenda.Add(padraoFazenda[i]);
                    }
                }
                break;
            default:
                Debug.LogError("Digite um tipo de ambiente válido!");
                break;

        }
    }

    public void clearAlL()
    {
        animaisFazenda.Clear();
        animaisAntartica.Clear();
        animaisAquatico.Clear();
    }


    public string ultimoAnimalSorteado()
    {
        return this.ultimoSorteado;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SortearAnimal
{

    private string ultimoSorteado;

    private List<string> animaisFazenda = new List<string>();
    private List<string> animaisAquatico = new List<string>();
    private List<string> animaisArtico = new List<string>();
    private List<string> animaisEspaco = new List<string>();
    private List<string> animaisEgito = new List<string>();
    private List<string> animaisMar = new List<string>();

    private List<string> animaisSorteadosFazenda = new List<string>();
    private List<string> animaisSorteadosAquatico = new List<string>();
    private List<string> animaisSorteadosartico = new List<string>();
    private List<string> animaisSorteadosEspaco = new List<string>();
    private List<string> animaisSorteadosEgito = new List<string>();
    private List<string> animaisSorteadosMar = new List<string>();


    public string sortearAnimal(string tipoAmbiente)
    {

        animaisSorteadosFazenda.Clear();
        animaisSorteadosAquatico.Clear();
        animaisSorteadosartico.Clear();
        animaisSorteadosEspaco.Clear();
        animaisSorteadosEgito.Clear();
        animaisSorteadosMar.Clear();
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
            case "artico":

                do
                {
                    aux = animaisArtico[rnd.Next(0, animaisArtico.Count - 1)].ToLower();
                }
                while (animaisSorteadosartico.Count < animaisArtico.Count && animaisSorteadosartico.Contains(aux));

                if (animaisSorteadosartico.Count == animaisArtico.Count)
                {
                    animaisSorteadosartico.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosartico.Add(aux);
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

            case "egito":

                do
                {
                    aux = animaisEgito[rnd.Next(0, animaisEgito.Count - 1)].ToLower();
                }
                while (animaisSorteadosEgito.Count < animaisEgito.Count && animaisSorteadosEgito.Contains(aux));

                if (animaisSorteadosEgito.Count == animaisEgito.Count)
                {
                    animaisSorteadosEgito.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosEgito.Add(aux);
                Debug.Log(aux);

                break;

            case "mar":

                do
                {
                    aux = animaisMar[rnd.Next(0, animaisMar.Count - 1)].ToLower();
                }
                while (animaisSorteadosMar.Count < animaisMar.Count && animaisSorteadosMar.Contains(aux));

                if (animaisSorteadosMar.Count == animaisMar.Count)
                {
                    animaisSorteadosMar.Clear();
                }

                ultimoSorteado = aux;
                animaisSorteadosMar.Add(aux);
                Debug.Log(aux);

                break;

            case "espaco":

                do
                {
                    aux = animaisEspaco[rnd.Next(0, animaisEspaco.Count - 1)].ToLower();
                }
                while (animaisSorteadosEspaco.Count < animaisEspaco.Count && animaisSorteadosEspaco.Contains(aux));

                if (animaisSorteadosEspaco.Count == animaisEspaco.Count)
                {
                    animaisSorteadosEspaco.Clear();
                }
                ultimoSorteado = aux;
                animaisSorteadosEspaco.Add(aux);
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
            case "artico":
                if (!this.animaisArtico.Contains(str_animal.ToLower()))
                {
                    this.animaisArtico.Add(str_animal.ToLower());
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

            case "egito":
                if (!this.animaisEgito.Contains(str_animal.ToLower()))
                {
                    this.animaisEgito.Add(str_animal.ToLower());
                    return;
                }
                cb = true;
                break;

            case "mar":
                if (!this.animaisMar.Contains(str_animal.ToLower()))
                {
                    this.animaisMar.Add(str_animal.ToLower());
                    return;
                }
                cb = true;
                break;
            case "espaco":
                if (!this.animaisEspaco.Contains(str_animal.ToLower()))
                {
                    this.animaisEspaco.Add(str_animal.ToLower());
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


        string[] padraoFazenda = { "Abelha", "Galinha", "Galo", "Pinto","Vaca","Ovelha"};
        string[] padraoArtico = { "Pinguim", "Leao_marinho" };
        string[] padraoAquatico = { "Polvo", "Peixe_espada","peixe_espada_2" };
        string[] padraoEgito = { "Mumia" };
        string[] padraoEspaco = { "et_amarelo", "et_verde", "et_vermelho" };
        string[] padraoMar = { "peixe_espada","peixe_espada_2","polvo" };

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
            case "artico":
                for (int i = 0; i < padraoArtico.Length; i++)
                {
                    if (!animaisArtico.Contains(padraoArtico[i].ToLower()))
                    {
                        animaisArtico.Add(padraoArtico[i]);
                    }
                }
                break;
            case "fazenda":
                for (int i = 0; i < padraoFazenda.Length; i++)
                {
                    if (!animaisFazenda.Contains(padraoFazenda[i].ToLower()))
                    {
                        animaisFazenda.Add(padraoFazenda[i]);
                    }
                }
                break;

            case "espaco":
                for (int i = 0; i < padraoEspaco.Length; i++)
                {
                    if (!animaisEspaco.Contains(padraoEspaco[i].ToLower()))
                    {
                        animaisEspaco.Add(padraoEspaco[i]);
                    }
                }
                break;

            case "mar":
                for (int i = 0; i < padraoMar.Length; i++)
                {
                    if (!animaisMar.Contains(padraoMar[i].ToLower()))
                    {
                        animaisMar.Add(padraoMar[i]);
                    }
                }
                break;

            case "egito":
                for (int i = 0; i < padraoEgito.Length; i++)
                {
                    if (!animaisEgito.Contains(padraoEgito[i].ToLower()))
                    {
                        animaisEgito.Add(padraoEgito[i]);
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
        animaisArtico.Clear();
        animaisAquatico.Clear();
    }


    public string ultimoAnimalSorteado()
    {
        return this.ultimoSorteado;
    }
}
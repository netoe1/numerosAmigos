using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarFaseDiferente : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Button frente;
    [SerializeField] private Button tras;
    [SerializeField] private Image imageToload;
    int ponteiro;

    private enum TIPO_FASES
    {
        SEQ_1_10 = 1,
        SEQ_10_20 = 2,
        DIM_1_10 = 3,
        DIM_10_20 = 4
    }
    private void Start()
    {
        ponteiro = 1;
        frente.onClick.AddListener(delegate ()
        {
            configurarIr();
            Debug.Log("Ponteiro:" + ponteiro);
        });

        tras.onClick.AddListener(delegate ()
        {
            configurarVoltar();
            Debug.Log("Ponteiro:" + ponteiro);
        });

        identificarFasePeloPonteiro();
            
    }

    void configurarIr()
    {
        if(ponteiro == 4)
        {
            ponteiro = 1;
        }
        else
        {
            ponteiro++;
        }
    }

    void configurarVoltar()
    {
        if(ponteiro == 1)
        {
            ponteiro = 4;

        }
        else
        {
            ponteiro--;
        }
    }

    void identificarFasePeloPonteiro()
    {
        switch (ponteiro)
        {
            case (int) TIPO_FASES.SEQ_1_10 :
                imageToload.GetComponent<Image>().color = Color.white;  
                break;
            case (int)TIPO_FASES.SEQ_10_20:
                imageToload.GetComponent<Image>().color = Color.black;
                break;
            case (int)TIPO_FASES.DIM_1_10:
                imageToload.GetComponent<Image>().color = Color.green;
                break;
            case (int)TIPO_FASES.DIM_10_20:
                imageToload.GetComponent<Image>().color = Color.blue;
                break;
        }

    }


}

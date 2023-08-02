using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

/*
 * Este script é resposável por configurar os itens clicáveis das fases, 
 *  podendo ser utilizado de forma genérica, de preferência, usar o prefab item_clicavel,
 *  para evitar bugs!
 */

public class ConfigurarItensClicaveis :
    MonoBehaviour
{
    // Controlador de som 

    ReprodutorSom reprodutorSom;


    [SerializeField] private Vector2 initial_size;
    private float amount_of_scale = 1.2f;
    private float default_scale = 1f;
    private Outline item_outline;
    private bool item_clicado;
    void Start()
    {
        //Configurando controlador de som

        reprodutorSom = new ReprodutorSom("Sounds/Contagem", this.gameObject);
        this.gameObject.GetComponent<RectTransform>().sizeDelta = this.initial_size;
        item_outline = this.GetComponent<Outline>();
        item_outline.effectColor = UnityEngine.Color.black;
        item_clicado = false;
        this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
        gui_item_unclick();
    }

    private void gui_item_click()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale * amount_of_scale, default_scale * amount_of_scale, default_scale * amount_of_scale);
    }

    private void gui_item_unclick()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale, default_scale, default_scale);
    }
    void config_outline(bool enter)
    {
        if (enter)
        {
            item_outline.effectDistance = new Vector2(item_outline.effectDistance.x * amount_of_scale, item_outline.effectDistance.y * amount_of_scale);
            return;
        }
        item_outline.effectDistance = new Vector2(default_scale, default_scale);
    }


    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            item_clicado = !item_clicado;
            if (item_clicado)
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.white;
                gui_item_click();
                //ControllerSelecionarAnimais.external_adicionarClicado();
                //ConfigBoxCollider2D.update_collider(this.gameObject, amount_of_scale, true);
                //Meta_ManterAnimais.adicionar_clicados();
            }
            else
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
                gui_item_unclick();
                //ControllerSelecionarAnimais.external_removerClicado();
                //ConfigBoxCollider2D.reset_size(this.gameObject);
                //Meta_ManterAnimais.remover_clicados();   
            }
            //status();

            /*
            if (int.Parse(ControllerSelecionarAnimais.external_getTextHud()) >= 0)
            {
                //reprodutorSom.reproduzirArquivo(ControllerSelecionarAnimais.external_getTextHud());
            }
            */

        }
    }
    void OnMouseEnter()
    {
        this.config_outline(true);
    }

    void OnMouseExit()
    {
        this.config_outline(false);
    }

    public void status()
    {
        Debug.Log("Clicado:" + item_clicado + "\nTag:" + this.gameObject.tag);
    }
}
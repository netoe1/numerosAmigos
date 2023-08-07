using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Este script é resposável por configurar os itens clicáveis das fases, 
 *  podendo ser utilizado de forma genérica, de preferência, usar o prefab item_clicavel,
 *  para evitar bugs!
 */

public class ItensClique :
    MonoBehaviour
{
    // Controlador de som 


    //[SerializeField] private Vector2 initial_size;
    [SerializeField] private BoxCollider2D boxCollider;
    private float amount_of_scale = 1.2f;
    private float default_scale = 1f;
    private Outline item_outline;
    private bool item_clicado;
    void Start()
    {
        //Configurando controlador de som

        //reprodutorSom = new ReprodutorSom("Sounds/Contagem", this.gameObject);
        //this.gameObject.GetComponent<RectTransform>().sizeDelta = this.initial_size;
        item_outline = this.GetComponent<Outline>();
        item_outline.effectColor = UnityEngine.Color.black;
        item_clicado = false;
        this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale, default_scale, default_scale);
        // Configurando BoxCollider

        boxCollider.size = this.gameObject.GetComponent<RectTransform>().rect.size;
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
            Debug.Log("Item cliado!");
            item_clicado = !item_clicado;
            if (item_clicado)
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.white;
                this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale * amount_of_scale, default_scale * amount_of_scale, default_scale * amount_of_scale);
                GerenciaJogo.acrescentarClique();
            }
            else
            {
                this.gameObject.GetComponent<Image>().color = UnityEngine.Color.black;
                this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(default_scale, default_scale, default_scale);
                GerenciaJogo.removerClique();  
            }
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
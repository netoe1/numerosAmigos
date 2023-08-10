using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;
using UnityEngine.UI;
public class SpritePath
{
    public string path_sprite { get; set; }
    public string descricao { get; set; }
    public string tagname { get; set; }


    public SpritePath(string __path_sprite, string __descricao, string tagname)
    {
        this.path_sprite = __path_sprite;
        this.descricao = __descricao;
        this.tagname = tagname;
    }

    public void spriteLog()
    {
        Debug.Log("SpritePath:" + this.path_sprite + "\nTagName:" + this.tagname + "\nDescrição:" + this.descricao);
    }

    public void loadIntoGameObject(GameObject gameObject, string filename)
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.path_sprite + "/" + filename);

    }

};
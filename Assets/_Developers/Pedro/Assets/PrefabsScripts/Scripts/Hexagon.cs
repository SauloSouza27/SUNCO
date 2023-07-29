using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private bool brilhando = false, ocupado = false;
    Outline outline;
    public bool Ocupado
    {
        get { return ocupado; }
        set { ocupado = value; }
    }
    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = Color.white;
    }
    public void StartOutline()
    {
        if (!ocupado)
        {
            brilhando = true;
            outline.OutlineColor = Color.red;
        }       
    }

    public void StopOutline()
    {
        brilhando = false;
        outline.OutlineColor = Color.white;
    }

    public bool IsOutlined()
    {        
        return brilhando;
    }
}

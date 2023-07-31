using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private bool Highlighted = false, ocuppied = false;
    [SerializeField] GameObject selectionShield, ocuppiedSpace;
    public bool Ocuppied
    {
        get { return ocuppied; }
        set { ocuppied = value; }
    }
    public void StartOutline()
    {
        if (!ocuppied)
        {
            Highlighted = true;
            selectionShield.SetActive(true);
        }
        else
        {
            ocuppiedSpace.SetActive(true);
        }
    }

    public void StopOutline()
    {
        Highlighted = false;
        if (ocuppiedSpace != null )
        {
            ocuppiedSpace.SetActive(false);
        }
        if (selectionShield != null)
        {
            selectionShield.SetActive(false);
        }

    }

    public bool IsOutlined()
    {        
        return Highlighted;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 waterPosition= new Vector3(0.5f,0,-3.77f);
    public float waterLife = 10;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
        instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DamageWater(float damage)
    {
        waterLife -= damage;
        if(waterLife <= 0)
        {
            //GameOver();
        }
        else
        {
            //Coloca aqui a função de mostrar a vida
        }
    }
}

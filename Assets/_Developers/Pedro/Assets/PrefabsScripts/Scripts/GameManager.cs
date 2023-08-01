using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 waterPosition= new Vector3(0.5f,0,-3.77f);
    public float waterLife = 10;
    [SerializeField] private TextMeshProUGUI textWater;
    // Start is called before the first frame update

    private void Start()
    {
        textWater.text = waterLife.ToString();
    }
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
            textWater.text = waterLife.ToString();
        }
    }
}

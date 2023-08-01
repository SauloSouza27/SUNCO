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


    [SerializeField] private GameObject hudCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    [SerializeField] private GameObject WinGameCanvas;

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

    public void WinGame()
    {
        hudCanvas.SetActive(false);
        EndGameCanvas.SetActive(false);
        WinGameCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void DamageWater(float damage)
    {
        waterLife -= damage;
        if(waterLife <= 0)
        {
            hudCanvas.SetActive(false);
            WinGameCanvas.SetActive(false);
            EndGameCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            textWater.text = waterLife.ToString();
        }
    }
}

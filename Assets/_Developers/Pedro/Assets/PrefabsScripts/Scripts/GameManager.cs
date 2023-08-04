using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int money = 150;
    public Vector3 waterPosition= new Vector3(0.5f,0,-3.77f);
    public float waterLife = 10;
    // References
    public ShopController shopController;
    public UiController uiController;
    public MouseController mouseController;


    [SerializeField] private GameObject hudCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    [SerializeField] private GameObject WinGameCanvas;

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
    public void RefreshUi()
    {
        uiController.ChangeMoney(money);
        uiController.ChangeWater(waterLife);
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
            uiController.ChangeWater(waterLife);
        }
    }
    public void SpendMoney(int cost)
    {
        money -= cost;
        uiController.ChangeMoney(money);
    }
}
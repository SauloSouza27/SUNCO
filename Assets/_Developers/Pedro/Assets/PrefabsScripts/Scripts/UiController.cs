using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCapacity,textWave,textMoney,textWater, textPriceWarden, textPriceTarget, TextPriceSentinel;
    void Start()
    {
        GameManager.instance.uiController = this;
        GameManager.instance.RefreshUi();
    }
    public void ChangePrices(int warden,int target,int sentinel)
    {
        textPriceWarden.text = warden.ToString();
        textPriceTarget.text = target.ToString();
        TextPriceSentinel.text = sentinel.ToString();
    }
    public void ChangeCapacity()
    {
        textCapacity.text = $"{GameManager.instance.mouseController.robotCount + 1} / {GameManager.instance.MaximumRobots}";
    }
    public void ChangeMoney(int money)
    {
        textMoney.text = "$ " + money;
        ChangeCapacity();
    }
    public void ChangeWater(float water)
    {
        textWater.text = water.ToString();
    }
    public void ChangeWave(int wave)
    {
        textWave.text = wave.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textWave,textMoney,textWater, textPriceWarden, textPriceTarget, TextPriceSentinel;
    void Start()
    {
        GameManager.instance.uiController = this;
        GameManager.instance.RefreshUi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePrices(int warden,int target,int sentinel)
    {
        textPriceWarden.text = warden.ToString();
        textPriceTarget.text = target.ToString();
        TextPriceSentinel.text = sentinel.ToString();
    }
    public void ChangeMoney(int money)
    {
        textMoney.text = "$ " + money;
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

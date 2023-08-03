using SunCo.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveControler : Singleton<WaveControler>
{
    public int amountKillsPerWave = 0;
    [SerializeField] private GameObject[] waves;
    private int killsWave;
    private int waveOrder = 0;
    
    private void Start()
    {
        waves[waveOrder].SetActive(true);
    }

    public void ChangeWave()
    {
        if(killsWave < amountKillsPerWave)
        {
            killsWave++;
        }
        if (killsWave >= amountKillsPerWave)
        {
            amountKillsPerWave = 0;
            killsWave = 0;
            waves[waveOrder].SetActive(false);
            waveOrder++;
            if (waves.Length > waveOrder)
            {
                waves[waveOrder].SetActive(true);
                GameManager.instance.uiController.ChangeWave(waveOrder + 1);
            }
            else
            {
                GameManager.instance.WinGame();
            }
        }
    }
}

using SunCo.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControler : Singleton<WaveControler>
{
    [SerializeField] private int amountKillsPerWave = 10;
    [SerializeField] private GameObject[] waves;
    private int killsWave;
    private int waveOrder = 0;

    public void ChangeWave()
    {
        if(killsWave < amountKillsPerWave)
        {
            killsWave++;
        }
        if(killsWave >= amountKillsPerWave)
        {
            waves[waveOrder].SetActive(false);
            waves[++waveOrder].SetActive(true);
            killsWave = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPosition
{
    Center, Left, Right
}
public class Spawn : MonoBehaviour
{
    // Wich enemy
    public Enemy enemyPrefab;
    // Wich position
    [SerializeField] private SpawnPosition spawnPosition;
    private Vector3 position;
    private float maxX, maxZ, minX, minZ;
    // Cooldowns
    [SerializeField] private float delaySpawn;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private int amount = 1;
    private float timeCounter;
    // Status Enemy
    [SerializeField]private float speedMultiplier = 1f;

    private void Start()
    {
        switch (spawnPosition)
        {
            case SpawnPosition.Center:
                minX = -6f;
                maxX = 6;
                minZ = -5.6f;
                maxZ = -5.7f;
                break;
            case SpawnPosition.Left:
                minX = 5.9f;
                maxX = 6;
                minZ = -5.6f;
                maxZ = -2f;
                break;
            case SpawnPosition.Right:
                minX = -5.9f;
                maxX = 6f;
                minZ = -5.6f;
                maxZ = -2f;
                break;
        }

        FindNewPosition();
    }

    private void Update()
    {
        if (delaySpawn > 0)
        {
            delaySpawn -= Time.deltaTime;
            return;
        }

        Timer();

        if (timeCounter == 0 && amount > 0)
        {
            SpawnEnemy();
            FindNewPosition();
            amount -= 1;
            timeCounter = cooldown;
        }
    }

    private void FindNewPosition()
    {
        float posX = Random.Range(minX, maxX);
        float posZ = Random.Range(minZ, maxZ); ;
        position = new Vector3(posX, 0, posZ);
    }

    private void SpawnEnemy()
    {
        Enemy instance;
        instance = Instantiate(enemyPrefab, position, transform.rotation);
        instance.Init(this, speedMultiplier);
    }

    private void Timer()
    {
        if (timeCounter >= 0)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
            {
                timeCounter = 0;
            }
        }
    }
}
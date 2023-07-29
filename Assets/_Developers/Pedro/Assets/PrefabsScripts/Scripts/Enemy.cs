using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifePoints, speed, enemyDamage, atackDelay, atackTimer;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameManager.instance.waterPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -3)
        {
            transform.Translate(0, 0, 1 * speed * Time.deltaTime);
        }
        else
        {
            if (atackTimer < atackDelay)
            {
                atackTimer += Time.deltaTime;
            }
            else
            {
                GameManager.instance.DamageWater(enemyDamage);
                atackTimer = 0;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        lifePoints -= damage;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}

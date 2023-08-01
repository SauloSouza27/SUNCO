using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float lifePoints, speed, enemyDamage, atackDelay, atackTimer;
    private Spawn _owner;
    [SerializeField] private GameObject enemyModel;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameManager.instance.waterPosition);
        material = enemyModel.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < GameManager.instance.waterPosition.z)
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
    IEnumerator RespondToDamage()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        material.color = Color.white;
    }
    public void TakeDamage(float damage)
    {
        lifePoints -= damage;
        StartCoroutine(RespondToDamage());
    }
    public void Die()
    {
        WaveControler.instance.ChangeWave();
        Destroy(gameObject);
    }

    public void Init(Spawn Owner, float speedMultiplier)
    {
        _owner = Owner;
        speed *= speedMultiplier;
    }
}

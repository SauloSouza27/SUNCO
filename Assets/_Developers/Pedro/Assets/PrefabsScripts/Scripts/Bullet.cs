using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Robot robot;
    [SerializeField] bool shouldMove;
    [SerializeField] bool areaDamage;
    [SerializeField] Vector3 direction;
    [SerializeField] float bulletSpeed;
    [SerializeField] float decayTime;
    private float _decayTimer;
    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
        robot = GetComponentInParent<Robot>();
    }
    void Update()
    {
        if (shouldMove)
        {
            Move();
        }
        if (areaDamage)
        {
            if (_decayTimer >= decayTime)
            {
                Die();
            }
            else
            {
                _decayTimer += Time.deltaTime;
            }
        }
    }
    private void Die()
    {
        weapon.DespawnBullet(this);
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * bulletSpeed);
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("jse");
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (areaDamage)
            {
                if (col != null)
                {
                    col.gameObject.GetComponent<Enemy>().TakeDamage(robot.atackDamage);
                }
            }
            else if(col != null && col.gameObject.GetComponent<Enemy>() == robot.AtackTarget)
            {
                robot.AtackTarget.TakeDamage(robot.atackDamage);
                Die();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    private ObjectPool<Bullet> _pool;
    [SerializeField] Bullet _bullet;
    [SerializeField] int maxProjectiles;
    [SerializeField] Robot robot;


    void Start()
    {
        _pool = new ObjectPool<Bullet>(() =>
        {
            return Instantiate(_bullet, transform);
        }, Bullet =>
        {
            if (robot.AtackTarget != null)
            {
                Bullet.gameObject.SetActive(true);
                Bullet.transform.position = transform.position;
            }
        }, Bullet =>
        {
            Debug.Log("despawn");
            Bullet.gameObject.SetActive(false);
        }, Bullet =>
        {
            Destroy(gameObject);
        }, false, maxProjectiles, maxProjectiles * 2);
    }

    public void SpawnBullet()
    {
        _pool.Get();
    }
    public void DespawnBullet(Bullet bulletCalling)
    {
        _pool.Release(bulletCalling);
    }
}

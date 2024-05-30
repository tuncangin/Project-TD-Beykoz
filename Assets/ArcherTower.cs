using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public float AttackRange;
    public float FireRate = 1;
    private float fireCountDown = 0;

    public Transform FirePoint;
    public PoolHandler PoolHandler;

    public Transform targetEnemy;
    public GameObject nearestEnemy;

    public void Init(PoolHandler poolHandler)
    {
        PoolHandler = poolHandler;
    }
    private void Update()
    {
        //Her Frame çalışacak
        FindAndUpdateTarget();

        if (targetEnemy == null)
        {
            return;
        }
        
        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1 / FireRate;
        }
        
        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void FindAndUpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        

        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            targetEnemy = nearestEnemy.transform;
            Debug.Log("Hedef Enemy: " + targetEnemy);
        }
        else
        {
            targetEnemy = null;
            Debug.Log("Hedef Yok");
        }
    }

    private void Shoot()
    {
        GameObject projGo = PoolHandler.GetProjectileFromPool();
        projGo.transform.position = FirePoint.position;
        projGo.transform.rotation = FirePoint.rotation;

        Projectile projectile = projGo.GetComponent<Projectile>();
        
        projectile.Fire(targetEnemy);

    }
}

using System.Collections.Generic;
using UnityEngine;

public class MageTower : MonoBehaviour
{
    public float AttackRange;
    public float coolDown = 2;
    private float coolDownTimer = 0;

    public List<Enemy> enemiesInAttackRange;

    private void Update()
    {
        FindAndAttackTargets();
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        
    }

    private void AreaAttack(List<Enemy> enemiesToAttack)
    {
        foreach (Enemy e in enemiesToAttack)
        {
            e.GetDamage(5);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void FindAndAttackTargets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemiesInAttackRange.Clear();

        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy <= AttackRange)
            {
                enemiesInAttackRange.Add(enemy.GetComponent<Enemy>());
            }
        }
        
        if (enemiesInAttackRange.Count == 0)
        {
            return;
        }
        else if(coolDownTimer<=0)
        {
            AreaAttack(enemiesInAttackRange);
            coolDownTimer = coolDown;
        }
        
        
    }
    
    

}

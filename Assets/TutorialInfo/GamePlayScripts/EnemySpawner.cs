using System;
using System.Collections;
using TutorialInfo.GamePlayScripts.EnemyScripts;
using UnityEngine;

namespace TutorialInfo.GamePlayScripts
{
    public class EnemySpawner: MonoBehaviour
    {
        public GameObject flying, wizard, tank, speedy;

        public void Init(Wave wave, Action callback)
        {
            StartCoroutine(CreateWaveEnemies(wave, callback));
        }
        
        
        IEnumerator CreateWaveEnemies(Wave wave, Action callback)
        {
            for (int i = 0; i < wave.enemyAmounts.Count; i++)
            {
                for (int j = 0; j < wave.enemyAmounts[i]; j++)
                {
                    switch (wave.enemies[i])
                    {
                        case EnemyType.Tank:
                            //Create tank
                            Instantiate(tank, transform.position, Quaternion.identity);
                            break;
                        case EnemyType.Flying:
                            //Create Flying
                            Instantiate(flying, transform.position, Quaternion.identity);
                            break;
                        case EnemyType.Speedy:
                            //Create speedy
                            Instantiate(speedy, transform.position, Quaternion.identity);
                            break;
                        case EnemyType.Wizard:
                            //Create wizard
                            Instantiate(wizard, transform.position, Quaternion.identity);
                            break;
                    }
                    yield return new WaitForSeconds(1.5f);
                }
                
                
            }

            callback();
            //for loop dışı
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TutorialInfo.GamePlayScripts.PlayerScripts;
using UnityEngine;

namespace TutorialInfo.GamePlayScripts
{
    public class GamePlayHandler: MonoBehaviour
    {
        private Player myPlayer;
        private StaticPlayerStatus _staticPlayerStatus = new StaticPlayerStatus();
        private Level currentLevel;
        private int WaveAmount;
        private int WaveIndexNumber;

        //Spawn objesi, sahneye yaratılacak
        [SerializeField]private GameObject enemySpawnerObject;
        //Spawner listesi, sonradan yönetilmek için liste olarak saklanacak
        private List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
        
        
        public List<Level> Levels;

        private void Start()
        {
            currentLevel = Levels[_staticPlayerStatus.GetLevelNumber()];
            WaveAmount = currentLevel.Waves.Count;
            WaveIndexNumber = 0;
            CreateLevel();
        }
        private void CreateLevel()
        {
            myPlayer = new Player(currentLevel);

            //Foreach loop içine verdiğimiz listenin boyutu, listenin elemanları arasında loop atar
            foreach (Vector3 spawnPosition in currentLevel.spawnPositions)
            {
                EnemySpawner spwn = Instantiate(enemySpawnerObject, spawnPosition, Quaternion.identity)
                    .GetComponent<EnemySpawner>();
                
                enemySpawners.Add(spwn);
            }

            enemySpawners[Random.Range(0, 2)].Init(currentLevel.Waves[WaveIndexNumber], StartNextWaveProcess);
            WaveIndexNumber++;


        }

        private void StartNextWaveProcess()
        {
            StartCoroutine(WaitForNextWave());
        }

        IEnumerator WaitForNextWave()
        {
            if (WaveIndexNumber == WaveAmount)
            {
                yield break;
            }
            yield return new WaitForSeconds(30);
            CallNextWave();
        }

        private void CallNextWave()
        {
            enemySpawners[Random.Range(0, 2)].Init(currentLevel.Waves[WaveIndexNumber], StartNextWaveProcess);
        }
   

        private void EndLevel()
        {
            _staticPlayerStatus.EndLevel();
        }
    }
}
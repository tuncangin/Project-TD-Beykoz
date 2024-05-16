using System.Collections.Generic;
using UnityEngine;

namespace TutorialInfo.GamePlayScripts
{
    [CreateAssetMenu(fileName = "new level asset", menuName = "Level Assets/New Level")]
    public class Level: ScriptableObject
    {
        public int playerHealth;
        public int playerCurrency;

        public int enemyHitAmount;

        public int waveCount;
        public float waveFreaquency;

        public List<Vector3> spawnPositions;

        public List<Wave> Waves;

    }

}
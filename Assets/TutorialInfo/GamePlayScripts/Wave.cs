using System.Collections.Generic;
using TutorialInfo.GamePlayScripts.EnemyScripts;
using UnityEngine;

namespace TutorialInfo.GamePlayScripts
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Level Assets/New Wave Object")]
    public class Wave: ScriptableObject
    {
        public List<EnemyType> enemies;
        public List<int> enemyAmounts;
    }
}
using UnityEngine;

namespace TutorialInfo.GamePlayScripts.Tower
{
    [CreateAssetMenu(menuName = "Game Assets/Tower Asset",fileName = "New Tower Object")]
    public class TowerAsset: ScriptableObject
    {
        public int Cost;
        public string name;

        public GameObject towerGameobject;

    }
}
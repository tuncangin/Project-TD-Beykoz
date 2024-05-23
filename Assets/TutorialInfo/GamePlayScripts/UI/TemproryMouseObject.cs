using TutorialInfo.GamePlayScripts.PlayerScripts;
using TutorialInfo.GamePlayScripts.Tower;

namespace TutorialInfo.GamePlayScripts.UI
{
    public class TemproryMouseObject
    {
        public TowerType _towerType;
        public Player _player;
        
        public TemproryMouseObject()
        {
            
        }
        public TemproryMouseObject(TowerType towerType, Player player)
        {
            _towerType = towerType;
            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
namespace TutorialInfo.GamePlayScripts.PlayerScripts
{
    public class StaticPlayerStatus
    {
        private int playerLevel = 1;

        public void EndLevel()
        {
            playerLevel += 1;
        }
        
        public int GetLevelNumber()
        {
            return playerLevel - 1;
        }
    }
}
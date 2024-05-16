using System.Collections.Generic;

namespace TutorialInfo.GamePlayScripts.PlayerScripts
{
    public class Player
    {
        
        private int health;
        private int currency;

        public Player(int _health, int _currency)
        {
            health = _health;
            currency = _currency;
        }

        public Player(Level currentLevel)
        {
            health = currentLevel.playerHealth;
            currency = currentLevel.playerCurrency;
        }

        public int GetPlayerHealth()
        {
            return health;
        }

        public int GetPlayerCurrency()
        {
            return currency;
        }

        public void GetHit()
        {
            health -= 5;
            CheckPlayerStatus();
        }

        
        public bool SpendCurrency(int amount)
        {
            if (currency - amount < 0)
            {
                //You don't have enough currency
                return false;
            }
            
            currency -= amount;
            return true;
        }

        public void GetCurrency(int amount)
        {
            currency += amount;
        }

        
        private void CheckPlayerStatus()
        {
            if (health <= 0)
            {
                //You died
            }
        }
        
    }
}
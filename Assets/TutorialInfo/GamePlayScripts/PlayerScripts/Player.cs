using System;
using System.Collections.Generic;
using UnityEngine;

namespace TutorialInfo.GamePlayScripts.PlayerScripts
{
    public class Player
    {
        private int health;
        private int currency;

        private Action RefreshUI;

        public Player(int _health, int _currency)
        {
            health = _health;
            currency = _currency;
            
        }

        public Player(Level currentLevel, Action refreshUI)
        {
            health = currentLevel.playerHealth;
            currency = currentLevel.playerCurrency;
            RefreshUI = refreshUI;
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

        
        public bool SpendCurrency(int cost)
        {
            if (currency - cost < 0)
            {
                //You don't have enough currency
                Debug.Log("Paran Yok");
                return false;
            }
            
            currency -= cost;
            RefreshUI();
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
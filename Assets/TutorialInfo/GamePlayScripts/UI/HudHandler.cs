using System;
using System.Collections.Generic;
using TMPro;
using TutorialInfo.GamePlayScripts.PlayerScripts;
using TutorialInfo.GamePlayScripts.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialInfo.GamePlayScripts.UI
{
    public class HudHandler : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI _currency, _playerHealth;
        [SerializeField] private Button _archerTowerBut, _mageTowerBut;
        [SerializeField] private Button _mortarTowerBut;

        private Player currentPlayer;

        private TemproryMouseObject _temproryMouseObject;
        
        public void Init(Player player)
        {
            currentPlayer = player;
            
            _temproryMouseObject = new TemproryMouseObject();
            
            _archerTowerBut.onClick.AddListener(()=> SaveTemproryMouseObject(TowerType.Archer));
            _mageTowerBut.onClick.AddListener(()=> SaveTemproryMouseObject(TowerType.Mage));
            _mortarTowerBut.onClick.AddListener(()=> SaveTemproryMouseObject(TowerType.Mortar));

            _currency.text = "Currency: " + currentPlayer.GetPlayerCurrency();
            _playerHealth.text = "HP: " + currentPlayer.GetPlayerHealth();

        }

        public void RefreshUIPlayerStats()
        {
            _currency.text = "Currency: " + currentPlayer.GetPlayerCurrency();
            _playerHealth.text = "HP: " + currentPlayer.GetPlayerHealth();
        }
    
        
        
        private void SaveTemproryMouseObject(TowerType towertype)
        {
            _temproryMouseObject = new TemproryMouseObject(towertype, currentPlayer);
            Debug.Log("Temprory Object is " + towertype);
        }

        public TemproryMouseObject GetTemproryMouseObject()
        {
            return _temproryMouseObject;
        }
    }
}

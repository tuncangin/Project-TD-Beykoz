using System.Collections.Generic;
using TutorialInfo.GamePlayScripts.Tower;
using TutorialInfo.GamePlayScripts.UI;
using UnityEngine;

public class TowerBuilderBase : MonoBehaviour
{
    [SerializeField]private TowerAsset archerTowerAsset,mageTowerAsset,mortarTowerAsset;
    [SerializeField] private PoolHandler _poolHandler;

    private Dictionary<TowerType, TowerAsset> _towerDictionary = new Dictionary<TowerType, TowerAsset>();
    private HudHandler _hudHandler;
    
    public void Init(HudHandler hudHandler)
    {
        _hudHandler = hudHandler;
        
        _towerDictionary.Add(TowerType.Archer,archerTowerAsset);
        _towerDictionary.Add(TowerType.Mage,mageTowerAsset);
        _towerDictionary.Add(TowerType.Mortar,mortarTowerAsset);
    }
    
    private void OnMouseDown()
    {
        if (_hudHandler.GetTemproryMouseObject() == null)
        {
            return;
        }
        
        CreateTower(_poolHandler);
        
    }

    private void CreateTower(PoolHandler poolHandler)
    {
        TowerType towerType= _hudHandler.GetTemproryMouseObject()._towerType;
        int towerCost = _towerDictionary[towerType].Cost;


        if (_hudHandler.GetTemproryMouseObject().GetPlayer().SpendCurrency(towerCost))
        {
            GameObject towerObject = Instantiate(_towerDictionary[towerType].towerGameobject, transform.position,
                Quaternion.identity);

            if (towerType == TowerType.Archer)
            {
                towerObject.GetComponent<ArcherTower>().Init(_poolHandler);
            }
            
        }
    }

    
}

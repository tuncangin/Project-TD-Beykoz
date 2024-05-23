using System.Collections.Generic;
using TutorialInfo.GamePlayScripts.Tower;
using TutorialInfo.GamePlayScripts.UI;
using UnityEngine;

public class TowerBuilderBase : MonoBehaviour
{
    [SerializeField]private TowerAsset archerTowerAsset,mageTowerAsset,mortarTowerAsset;

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
        TowerType towerType= _hudHandler.GetTemproryMouseObject()._towerType;
        int towerCost = _towerDictionary[towerType].Cost;


        if (_hudHandler.GetTemproryMouseObject().GetPlayer().SpendCurrency(towerCost))
        {
            GameObject towerObject = Instantiate(_towerDictionary[towerType].towerGameobject, transform.position,
                Quaternion.identity);
        }
    }

    private void CreateTower()
    {
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get 
        {
            if (instance==null) 
            {
                throw new UnityException();
            }
            return instance;
        }
        
    }
    #region
    [Header("Components")]
    public Text GemsCount;
    public Transform _ImageSlection;
    public Transform[] _ButtonsItems;
    #endregion
    public void CountGems(int gemsCount)
    {
        GemsCount.text = $"{gemsCount}";
    }

    private void Awake()
    {
        instance = this;

    }

    public void MoveSelectionImage(int i)
    {
        BeahaviourMarketShop _getParameters= new BeahaviourMarketShop();
        switch (i)
        {
            case 0:
                _ImageSlection.transform.position = _ButtonsItems[0].transform.position;
                _getParameters.currentItemselected = 0;
                _getParameters.gemsCost = 200;                
                break;
            case 1:
                _ImageSlection.transform.position = _ButtonsItems[1].transform.position;
                _getParameters.currentItemselected = 1;
                _getParameters.gemsCost = 400;
                break;
            case 2:
                _ImageSlection.transform.position = _ButtonsItems[2].transform.position;
                _getParameters.currentItemselected = 2;
                _getParameters.gemsCost = 100;
                break;
            default:
                _ImageSlection.transform.position = _ButtonsItems[0].transform.position; 
                _getParameters.currentItemselected = 0;
                _getParameters.gemsCost = 200;
                break;
        }
    }
}

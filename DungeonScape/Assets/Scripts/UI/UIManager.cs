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
    public Image[] LifeBar;
    public Text GemsCount;
    public Transform _ImageSlection;
    public Transform[] _ButtonsItems;
    #endregion
    public void CountGems(int gemsCount)
    {
        GemsCount.text = $"{gemsCount}";
    }

    public void UpdateLives(int countLifes)
    {
        for(int i=0; i<= countLifes; i++)
        {
            if(i== countLifes)
             LifeBar[i].enabled = false;
        }
    }

    private void Awake()
    {
        instance = this;

    }
}

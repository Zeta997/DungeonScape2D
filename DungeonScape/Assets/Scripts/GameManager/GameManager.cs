using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
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

    public bool AccessToGetKey { get; set; }

    public Text GemsCountPlayerHUB;

    public void GemsCOunt(int getGemsCount)
    {
        GemsCountPlayerHUB.text= getGemsCount.ToString();
    }
    private void Awake()
    {
        instance = this;
    }
}

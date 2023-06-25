using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{
    public GameObject MarketShop;
    public void ClosePanelShop()
    {
        MarketShop.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BeahaviourMarketShop : MonoBehaviour
{
    public GameObject MarketShop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.tag=="Player")
            {
                MarketShop.SetActive(true);
                Time.timeScale = 0;
            }
        }
        catch (UnityException e)
        {
            Debug.LogWarning(e);
        }
    }

}

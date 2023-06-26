using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeahaviourMarketShop : MonoBehaviour
{

    public GameObject MarketShop;
    public int gemsCost, currentItemselected;
    Player _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            _player= other.GetComponent<Player>();
            if (other.tag=="Player")
            {
                UIManager.Instance.CountGems(_player.Diamondcount);
                MarketShop.SetActive(true);
                Time.timeScale = 0;
            }
        }
        catch (UnityException e)
        {
            Debug.LogWarning(e);
        }
    }

    public void SelectedItem(int item)
    {
      UIManager.Instance.MoveSelectionImage(item);
    }

    public void BuyItem()
    {
        if (_player.Diamondcount>= gemsCost)
        {
            _player.Diamondcount-= gemsCost;
            Debug.Log(_player.Diamondcount);
        }      
    }

    private void Start()
    {
        gemsCost = 0;
        currentItemselected=0;
    }
}

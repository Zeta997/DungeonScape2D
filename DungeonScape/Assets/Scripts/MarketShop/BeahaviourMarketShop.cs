using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeahaviourMarketShop : MonoBehaviour
{

    public GameObject MarketShop;
    public int gemsCost;
    public int currentItemselected;
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
        switch (item)
        {
            case 0:
                UIManager.Instance._ImageSlection.transform.position = UIManager.Instance._ButtonsItems[0].transform.position;
                currentItemselected = item;
                gemsCost = 200;
                break;
            case 1:
                UIManager.Instance._ImageSlection.transform.position = UIManager.Instance._ButtonsItems[1].transform.position;
                currentItemselected = item;
                gemsCost = 400;
                break;
            case 2:
                UIManager.Instance._ImageSlection.transform.position = UIManager.Instance._ButtonsItems[2].transform.position;
                currentItemselected = item;
                gemsCost = 100;
                break;
            default:
                UIManager.Instance._ImageSlection.transform.position = UIManager.Instance._ButtonsItems[0].transform.position;
                currentItemselected = item;
                gemsCost = 200;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.Diamondcount>= gemsCost)
        {
            if(currentItemselected==2) GameManager.Instance.AccessToGetKey = true;
            _player.Diamondcount-= gemsCost;
            UIManager.Instance.CountGems(_player.Diamondcount);
            Debug.Log(_player.Diamondcount);
        }      
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int currentCoin;
    [SerializeField] private CoinSystem coinUI;
    public void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        currentCoin = 500;
    }

    public bool UseCoin(int coin)
    {
        if(coin <= currentCoin)
        {
            currentCoin -= coin;
            coinUI.SetCoin(currentCoin);
            return true;
        }
        else
        {
            return false;
        }
    }
}
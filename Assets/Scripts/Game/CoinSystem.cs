using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCount;

    public void SetCoin(int coin)
    {
        string neleci = string.Format("{0:00}", coin);
        coinCount.text = neleci;
    }
}
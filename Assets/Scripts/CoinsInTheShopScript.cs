using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsInTheShopScript : MonoBehaviour
{
    public static int coins;
    public Text coinsText;

    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", coins);
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins", coins).ToString();
    }

    private void Update()
    {
        //coins = PlayerPrefs.GetInt("Coins", coins);
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();
    }

}

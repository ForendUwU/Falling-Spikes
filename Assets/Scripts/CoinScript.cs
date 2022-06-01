using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Rigidbody2D coinrb;
    public GameObject coin;
    public Text coinsText;

    public SpriteRenderer spriteRenderer;
    public Sprite GoldSprite;
    public Sprite SilverSprite;
    public Sprite BronzeSprite;
    public Sprite RainbowSprite;

    public AudioSource coinsound;
    




    float randoX;
    float randoY;

    int coins;

    int coinType;

    private Vector2 whereToSpawn;

    public void Start()
    {
        //randoX = Random.Range(-15.5f, 15.5f);
        //randoY = Random.Range(21f, 50f);
        //coin.transform.position = new Vector2(randoX, randoY);
        CoinsAppear();
        coins = PlayerPrefs.GetInt("Coins", coins);
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins", coins).ToString();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UnderFloor")
        {
            CoinsAppear();
        }
        if (collision.gameObject.tag == "Player")
        {
            if (this.GetComponent<SpriteRenderer>().sprite == BronzeSprite)
            {
                coins += 1;
            }
            else if (this.GetComponent<SpriteRenderer>().sprite == SilverSprite)
            {
                coins += 5;
            }
            else if (this.GetComponent<SpriteRenderer>().sprite == GoldSprite)
            {
                coins += 7;
            }
            else {
                coins += 10;
            }
            coinsound.mute = false;
            coinsound.Play();
            UpdateCoins();
            CoinsAppear();
        }
    }

    public void UpdateCoins()
    {
        coinsText.text = "Coins: " + coins.ToString();
        PlayerPrefs.SetInt("Coins", coins); 
    }

    public void CoinsAppear()
    {
        randoX = Random.Range(-15.5f, 15.5f);
        randoY = Random.Range(21f, 50f);
        whereToSpawn = new Vector2(randoX, randoY);
        coinType = Random.Range(1, 11);

        if (coinType >= 1 && coinType <= 5)
        {
            ChangeSprite(BronzeSprite);
        }
        else if (coinType > 5 && coinType <= 7)
        {
            ChangeSprite(SilverSprite);
        }
        else if (coinType > 7 && coinType <= 9)
        {
            ChangeSprite(GoldSprite);
        }
        else {
            ChangeSprite(RainbowSprite);
        }
        
        coinrb.velocity = new Vector2(0, 0);
        this.transform.position = whereToSpawn;
    }

    void ChangeSprite(Sprite a)
    {
        this.GetComponent<SpriteRenderer>().sprite = a;
    }
}

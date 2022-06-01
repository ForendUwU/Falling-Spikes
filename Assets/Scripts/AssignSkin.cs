using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignSkin : MonoBehaviour
{
    public Sprite First;
    public Sprite Second;
    public Sprite Third;
    public Sprite Forth;
    public Sprite Fifth;
    public Sprite Sixth;
    public Sprite Seventh;
    public Sprite Eighths;
    public GameObject Player;
    public GameObject dashEffect;

    private void Start()
    {
        if (PlayerPrefs.GetInt("skinNum") == 1)
        {
            Player.GetComponent<SpriteRenderer>().sprite = First;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.white;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 2)
        {
            
            Player.GetComponent<SpriteRenderer>().sprite = Second;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.blue;

        }
        else if (PlayerPrefs.GetInt("skinNum") == 3)
        {
            
            Player.GetComponent<SpriteRenderer>().sprite = Third;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(Color.red, Color.white, (float)0.4);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 4)
        {
            Player.GetComponent<SpriteRenderer>().sprite = Forth;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(Color.blue, Color.white, (float)0.6);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 5)
        {
            Player.GetComponent<SpriteRenderer>().sprite = Fifth;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(Color.blue, Color.white, (float)0.6);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 6)
        {
            Color clr = new Color();
            clr = Color.Lerp(Color.yellow, Color.red, (float)0.5);
            Player.GetComponent<SpriteRenderer>().sprite = Sixth;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(clr, Color.blue, (float)0.5);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 7)
        {
            Color clr = new Color();
            clr = Color.Lerp(Color.yellow, Color.red, (float)0.5);
            Player.GetComponent<SpriteRenderer>().sprite = Seventh;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(clr, Color.blue, (float)0.8);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 8)
        {
            Color clr = new Color();
            clr = Color.Lerp(Color.yellow, Color.red, (float)0.5);
            Player.GetComponent<SpriteRenderer>().sprite = Eighths;
            dashEffect.GetComponent<ParticleSystem>().startColor = Color.Lerp(clr, Color.blue, (float)0.7);
        }

    }

    //public Shop scriptShop;
    //public string nameItem;
    //public int priceItem;

    //public Text TextItem;

    //public bool isBuy;

    //public void BuyItem() {
    //    if (isBuy == false)
    //    {
    //        scriptShop.nameItem = nameItem;
    //        scriptShop.priceItem = priceItem;

    //        scriptShop.buyItem();
    //    }

    //}
}

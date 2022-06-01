using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public int skinNum;
    public Button BuyButton;
    public int price;

    public Text statetext;

    public Image[] skins;

    public AudioSource buysound;
    public AudioSource equipsound;

    private void Start()
    {
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                Debug.Log(img.name);
                if ("skin1" == img.name)
                {
                    PlayerPrefs.SetInt("skin1" + "buy", 1);
                }
                else
                {
                    //PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);

                }

            }
        }


    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            statetext.text = price.ToString();
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                
                statetext.text = "Equipped";
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                statetext.text = "Equip";
            }
        }
    }

    public void buy() {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= price)
            {
                buysound.mute = false;
                buysound.Play();
                statetext.text = "Equipped";
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (Image img in skins) {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                        

                    }
                    else {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                
                    }     
                }
             
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy")== 1)
        {
            equipsound.mute = false;
            equipsound.Play();
            statetext.text = "Equipped";
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins) {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                }
                else {
                    PlayerPrefs.SetInt(img.name + "equip", 0);
                }
            }

        }
    }



    //private Shop.DataPlayer dataPlayer = new Shop.DataPlayer();
    //[HideInInspector]
    //public string nameItem;
    //[HideInInspector]
    //public int priceItem;

    //public GameObject[] allItem;

    //public Text coinsText;




    //public class DataPlayer{
    //    public int money;

    //    public List<string> buyItem = new List<string>();
    //}

    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("SaveGame"))
    //    {
    //        LoadGame();
    //    }
    //    else {
    //        dataPlayer.money = PlayerPrefs.GetInt("Coins");
    //        SaveGame();
    //        LoadGame();
    //    }

    //}

    //private void SaveGame() {
    //    PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(dataPlayer));
    //}

    //private void LoadGame() {
    //    dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("SaveGame"));

    //    for (int i = 0; i < dataPlayer.buyItem.Count; i++)
    //    {
    //        for (int j = 0; j < allItem.Length; j++)
    //        {

    //            if (allItem[j].GetComponent<Item>().nameItem == dataPlayer.buyItem[i])
    //            {


    //                allItem[j].GetComponent<Item>().TextItem.text = "Purchased";
    //                allItem[j].GetComponent<Item>().isBuy = true;

    //            }
    //        }
    //    }
    //}

    //public void buyItem() {

    //    if (dataPlayer.money >= priceItem)
    //    {

    //        dataPlayer.buyItem.Add(nameItem);
    //        dataPlayer.money = dataPlayer.money - priceItem;

    //        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins", dataPlayer.money).ToString();

    //        SaveGame();
    //        LoadGame();
    //    }
    //}
}



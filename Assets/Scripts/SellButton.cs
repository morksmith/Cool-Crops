using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public PlayerInventory Inventory;
    public GameObject FruitType;
    public GameObject ApplePrefab;
    public GameObject BananaPrefab;
    public GameObject CarrotPrefab;
    public bool SellAllButton = false;
    public Button MyButton;

    private Fruit fruitInfo;
    private Fruit appleInfo;
    private Fruit bananaInfo;
    private Fruit carrotInfo;
    // Start is called before the first frame update
    void Start()
    {
        if (!SellAllButton)
        {
            fruitInfo = FruitType.GetComponent<Fruit>();
        }
        appleInfo = ApplePrefab.GetComponent<Fruit>();
        bananaInfo = BananaPrefab.GetComponent<Fruit>();
        carrotInfo = CarrotPrefab.GetComponent<Fruit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SellAllButton)
        {
            if (PlayerPrefs.GetInt("Apples") + PlayerPrefs.GetInt("Bananas") + PlayerPrefs.GetInt("Carrots") > 0)
            {
                MyButton.interactable = true;
            }
            else
            {
                MyButton.interactable = false;
            }
            return;
        }
        if(PlayerPrefs.GetInt(fruitInfo.Type.ToString())> 0)
        {
            MyButton.interactable = true;
        }
        else
        {
            MyButton.interactable = false;
        }
    }
    public void SellFruit()
    {
        Inventory.SetFruit(fruitInfo.Type.ToString(), -1);
        Inventory.SetMoney(fruitInfo.Price);
        Debug.Log(PlayerPrefs.GetInt(fruitInfo.Type.ToString()));

    }
    public void SellAll()
    {
        var totalMoney = (PlayerPrefs.GetInt("Apples") * appleInfo.Price) + (PlayerPrefs.GetInt("Bananas") * bananaInfo.Price) + (PlayerPrefs.GetInt("Carrots") * carrotInfo.Price);
        Inventory.SetMoney(totalMoney);
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.SetInt("Bananas", 0);
        PlayerPrefs.SetInt("Carrots", 0);
        Debug.Log(PlayerPrefs.GetInt("Money"));
    }
}

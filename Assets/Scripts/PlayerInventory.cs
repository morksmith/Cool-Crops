using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int Money;
    public int ASeeds;
    public int BSeeds;
    public int CSeeds;
    public int Apples;
    public int Bananas;
    public int Carrots;

    // Start is called before the first frame update
    void Start()
    {
        SetIntValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoney(int amount)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + amount);
        SetIntValues();
    }
    public void SetSeed(string seedType, int amount)
    {
        PlayerPrefs.SetInt(seedType, PlayerPrefs.GetInt(seedType) + amount);
        SetIntValues();
    }
    public void SetFruit(string fruitType, int amount)
    {
        PlayerPrefs.SetInt(fruitType, PlayerPrefs.GetInt(fruitType) + amount);
        Debug.Log(fruitType + " + " + amount);
        SetIntValues();
    }
    public void SetIntValues()
    {
        Money = PlayerPrefs.GetInt("Money");
        ASeeds = PlayerPrefs.GetInt("ASeeds");
        BSeeds = PlayerPrefs.GetInt("BSeeds");
        CSeeds = PlayerPrefs.GetInt("CSeeds");
        Apples = PlayerPrefs.GetInt("Apples");
        Bananas = PlayerPrefs.GetInt("Bananas");
        Carrots = PlayerPrefs.GetInt("Carrots");
        Debug.Log("Inventory Updated");
    }
}

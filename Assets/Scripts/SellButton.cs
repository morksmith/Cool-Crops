using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public PlayerInventory Inventory;
    public GameObject FruitType;
    public Button MyButton;

    private Fruit fruitInfo;
    // Start is called before the first frame update
    void Start()
    {
        fruitInfo = FruitType.GetComponent<Fruit>();

    }

    // Update is called once per frame
    void Update()
    {
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
}

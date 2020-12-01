using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool Paused = false;
    public Menu InventoryMenu;
    public TextMeshProUGUI EquippedText;
    public PlayerInteraction Interaction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryMenu.Active)
            {
                InventoryMenu.Active = false;
                Paused = false;
            }
            else
            {
                InventoryMenu.Active = true;
                Paused = true;
            }
        }
        
    }
   
    
}

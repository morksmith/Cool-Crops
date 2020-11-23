using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Paused = false;
    public Menu MainMenu;
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
            if (MainMenu.Active)
            {
                MainMenu.Active = false;
                Paused = false;
            }
            else
            {
                MainMenu.Active = true;
                Paused = true;
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public bool Active;
    public Vector2 ActivePosition;
    public Vector2 InactivePosition;
    public float ScrollSpeed;
    public RectTransform MenuBackground;
    public EventSystem CanvasEvents;
    private GameObject lastSelected;
    // Start is called before the first frame update
    void Start()
    {
        lastSelected = CanvasEvents.firstSelectedGameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        if (Active)
        {
            MenuBackground.anchoredPosition = Vector2.Lerp(MenuBackground.anchoredPosition, ActivePosition, ScrollSpeed * Time.deltaTime);
            CanvasEvents.sendNavigationEvents = true;
            if(CanvasEvents.currentSelectedGameObject!= null)
            {
                lastSelected = CanvasEvents.currentSelectedGameObject;
            }

        }
        else
        {
            MenuBackground.anchoredPosition = Vector2.Lerp(MenuBackground.anchoredPosition, InactivePosition, ScrollSpeed * Time.deltaTime);
            CanvasEvents.sendNavigationEvents = false;

        }
    }

    public void ToggleMenu()
    {
        if (Active)
        {
            Active = false;
            GameManager.Paused = false;
        }
        else
        {
            Active = true;
            GameManager.Paused = true;
            CanvasEvents.SetSelectedGameObject(lastSelected);
        }
    }
}

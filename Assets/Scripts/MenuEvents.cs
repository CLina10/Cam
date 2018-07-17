using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuEvents : MonoBehaviour
{
    public UnityEvent StartPlaying = new UnityEvent();
    //public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();

    private static MenuEvents instance;
    public static MenuEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MenuEvents>();
            }
            return instance;
        }
        private set { instance = value; }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ToPlayButton()
    {
        StartPlaying.Invoke();
    }
}

//public enum ActiveMenu
//{
//    Main = 0,
//    Options = 1
//}

//[System.Serializable]
//public class ActiveMenuEvent : UnityEvent<ActiveMenu>
//{

//}

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{

}

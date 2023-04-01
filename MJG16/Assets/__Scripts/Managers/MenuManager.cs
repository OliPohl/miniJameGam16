using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private GameObject _book;


    void Start() 
    {
        _book = GameObject.FindGameObjectWithTag("Book");
    }


    public bool ToggleBook()
    {
        if(_book.activeSelf = false) 
        {
            _book.setActive(true);
        }
        else
        {
            _book.setActive(false);
        }
    }

    private void OnEnable() {
        Time.timeScale = 0f;
        playerInput.SwitchCurrentActionMap("UI");
    }


    private void OnDisable() {
        Time.timeScale = 1f;
        playerInput.SwitchCurrentActionMap("Player");
    }
}

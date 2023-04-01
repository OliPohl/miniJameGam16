using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject _book;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleBook()
    {
        Debug.Log(_book);
        if(_book.activeSelf == false) 
        {
            _book.SetActive(true);
            Time.timeScale = 0f;
            // playerInput.SwitchCurrentActionMap("UI");
        }
        else
        {
            _book.SetActive(false);
            Time.timeScale = 1f;
            // playerInput.SwitchCurrentActionMap("Player");
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}

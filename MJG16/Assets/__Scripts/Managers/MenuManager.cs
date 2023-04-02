using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject _book;
    public GameObject _achieve;
    private float achiStartPos;
    private float achiEndPos = -40f;

    public GameObject achievement1Obj;
    public GameObject achievement2Obj;
    public GameObject achievement3Obj;
    public GameObject achievement5Obj;

    public bool achievement1 = false;
    public bool achievement2 = false;
    public bool achievement3 = false;
    public bool achievement5 = false;

    private bool achievement1Save = false;
    private bool achievement2Save = false;
    private bool achievement3Save = false;
    private bool achievement5Save = false;

    private bool stage1 = false;
    private float timer = 0;
    private bool trigger = false;


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

    void Start() {
        achiStartPos = _achieve.transform.position.y;
        _achieve.transform.position = new Vector3(_achieve.transform.position.x, achiEndPos, _achieve.transform.position.z);
    }

    void FixedUpdate() 
    {
        if(achievement1 != achievement1Save 
            || achievement2 != achievement2Save 
            || achievement3 != achievement3Save 
            || achievement5 != achievement5Save)
        {
            trigger = true;
            timer = 0;
            stage1 = false;
        }


        if(trigger)
        {
            Achieving();
        }
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


    private void Achieving()
    {
        timer += Time.deltaTime;

        achievement1Obj.SetActive(achievement1);
        achievement2Obj.SetActive(achievement2);
        achievement3Obj.SetActive(achievement3);
        achievement5Obj.SetActive(achievement5);

        achievement1Save = achievement1;
        achievement2Save = achievement2;
        achievement3Save = achievement3;
        achievement5Save = achievement5;

        if(timer < 3f)
        {
            _achieve.transform.position = Vector3.MoveTowards(_achieve.transform.position, new Vector3(_achieve.transform.position.x, achiStartPos, _achieve.transform.position.z), Time.deltaTime * 50f);
        }

        if(timer > 3f)
        {
            if(timer > 6f && timer < 9f)
            {
                _achieve.transform.position = Vector3.MoveTowards(_achieve.transform.position, new Vector3(_achieve.transform.position.x, achiEndPos, _achieve.transform.position.z), Time.deltaTime * 50);
            }
            if(timer > 10f)
                trigger = false;
        }     
    }




    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}

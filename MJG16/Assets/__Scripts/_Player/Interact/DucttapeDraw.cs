using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class DucttapeDraw : MonoBehaviour
{
    // DRAW WITH MOUSE INPUT DUCT TAPE 
    // SOUND
    
    private AudioClips _audioClips => SoundManager.AudioClips;
    public static DucttapeDraw Instance;
    [SerializeField] GameObject ductTapeSpawnObject;
    [SerializeField] GameObject EpicBoxColliderObject;
    private GameObject currentDuctTape;
    private LineRenderer lineRenderer;
    private bool isButtonPressed;
    // VARS FOR DUCT TAPE 
    public int currentTapes { get; set; } = 0;
    
    [SerializeField] private int maxTapes = 5;
    [SerializeField] private float maxTapeLength = 3; // how many steps
    private int currentTapeLength = 0;
    private Camera cam;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        isButtonPressed = false;
        currentDuctTape = null;
        cam = Camera.main;
        
    }
    public void ButtonChange(bool value)
    {
        isButtonPressed = value;
        
    }
    public void OnTaping()
    {
        if (isButtonPressed)
        {
            
            if(currentTapes <= maxTapes)
            {
                if (currentDuctTape == null  || currentTapeLength > maxTapeLength)
                {
                    // CREATE NEW TAPE ///
                    currentDuctTape = Instantiate(ductTapeSpawnObject, Vector3.zero, Quaternion.identity);
                    GameObject temp = Instantiate(EpicBoxColliderObject, Vector3.zero, Quaternion.identity);
                    // PLAY Sound
                    SoundManager.Instance.PlayAudio(_audioClips.ducttape);
                    Vector3 tempPos = GetMousePosition();
                    tempPos.z  = PlayerController.Instance.ZPosition();
                    temp.transform.position = tempPos;
                    lineRenderer = currentDuctTape.GetComponent<LineRenderer>();
                    currentTapeLength = 0;
                    currentTapes++;
                    // POSITION ZERO
                    
                    lineRenderer.positionCount = 1;
                    lineRenderer.SetPosition(0,GetMousePosition());
                    currentTapeLength++;
                    
                }
            if (currentDuctTape != null && currentTapeLength < maxTapeLength)
            {
                // ON UPDATING CURRENT TAPE///
                
                if (Vector2.Distance(GetMousePosition(), lineRenderer.GetPosition(currentTapeLength-1)) > 0.25f &&
                (Vector2.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(currentTapeLength-1)) < maxTapeLength))
                    {
                        lineRenderer.positionCount = currentTapeLength+1;
                        lineRenderer.SetPosition(currentTapeLength, GetMousePosition());
                        GameObject temp = Instantiate(EpicBoxColliderObject, Vector3.zero, Quaternion.identity);
                        Vector3 tempPos = GetMousePosition();
                        tempPos.z  = PlayerController.Instance.ZPosition();
                        temp.transform.position = tempPos;
                        currentTapeLength++;
                        
                        
                    }
            }
            }
        }else{
        currentDuctTape = null;}
    }
    
    private Vector3 GetMousePosition()
    {
        
        Vector3 position = Input.mousePosition;
        position.z = 6.9f;
        return cam.ScreenToWorldPoint(position);
    }

    private void FixedUpdate()
    {
        OnTaping();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucttapeDraw : MonoBehaviour
{
   // DRAW WITH MOUSE INPUT DUCT TAPE 
   public static DucttapeDraw Instance;
   [SerializeField] GameObject ductTapeObject;
   [SerializeField] private List<Vector2> mousePositions  = new List<Vector2>();
   private GameObject currentDuctTape;
   private LineRenderer lineRenderer;
   private EdgeCollider2D edgeCollider2D;
   private int currentDuctTapePoint;
   private bool isButtonPressed;
   // VARS FOR DUCT TAPE 
   private float tapeLength=0.0f;
   [SerializeField] private float maxTapeLength=100;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        isButtonPressed = false;
    }
    public void OnTaping() {
        isButtonPressed = !isButtonPressed;
        if(currentDuctTape == null && isButtonPressed)
        {
            //CreateTape();
        }else{
            Vector2 tempPos =  GetMousePosition();
            if(Vector2.Distance(tempPos,mousePositions[mousePositions.Count -1])>0.25f)
            {
                //UpdateTape(tempPos);
            }
        }
    }
    // private void FixedUpdate() {
    
    //     if(tapeLength < maxTapeLength  && isButtonPressed)
    //     {
    //         Vector2 tempPos =  GetMousePosition();
    //         if(Vector2.Distance(tempPos,mousePositions[mousePositions.Count -1])>0.25f)
    //         {
    //             UpdateTape(tempPos);
    //         }
    //     }
    // }
    private void CreateTape()
    {
        Debug.Log ("Create New Tape");
        currentDuctTape = Instantiate(ductTapeObject, Vector3.zero, Quaternion.identity);
        lineRenderer = currentDuctTape.GetComponent<LineRenderer>();
        edgeCollider2D = currentDuctTape.GetComponent<EdgeCollider2D>();
        
        mousePositions.Add( GetMousePosition());
        mousePositions.Add( GetMousePosition(1.0f));
        lineRenderer.SetPosition(0, mousePositions[0]);
        lineRenderer.SetPosition(1, mousePositions[1]);

        edgeCollider2D.points = mousePositions.ToArray();
        currentDuctTapePoint =2;
        
    }
    private void UpdateTape(Vector2 newTapePos)
    {
        mousePositions.Add(newTapePos);
        lineRenderer.positionCount ++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newTapePos);
        edgeCollider2D.points = mousePositions.ToArray();
        currentDuctTapePoint ++;
        tapeLength += Vector2.Distance(mousePositions[currentDuctTapePoint], mousePositions[currentDuctTapePoint -1]);

    }
     private Vector3 GetMousePosition() {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
    private Vector3 GetMousePosition(float offset) {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;
        worldMousePosition.x += offset;
        return worldMousePosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    [SerializeField] private Texture2D[] faceAnim;
    [SerializeField] private Texture2D faceDeathAnim;
    private float timestep  = 0.2f;
    private float temp = 0.0f;
    private int county=0;
    private Renderer _renderPlayer;
    void Start()
    {
        _renderPlayer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(temp > timestep)
        {
            temp = 0.0f;
            _renderPlayer.materials[4].SetTexture("_MainTex", faceAnim[county]);
            county++;
            if(county == faceAnim.Length){
                county=0;
                temp = -20.0f;
            }
        }
        temp += Time.fixedDeltaTime;
    }
    public void OnDeathAnimation()
    {
        _renderPlayer.materials[4].SetTexture("_MainTex", faceDeathAnim);
        temp =-100;
    }
}

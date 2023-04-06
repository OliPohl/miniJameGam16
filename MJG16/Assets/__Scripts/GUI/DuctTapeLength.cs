using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DuctTapeLength : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    
    private string templateText = "Use Duct-Tape\n";
    // Start is called before the first frame update
    void Start()
    {
        textComponent =  GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        textComponent.text = templateText + PlayerController.Instance.PlayerDuctTapelength + "m";
    }
}

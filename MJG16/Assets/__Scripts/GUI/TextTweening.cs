using TMPro;
using UnityEngine;
public class TextTweening : MonoBehaviour
{
    private string Text;
    private TextMeshProUGUI _textMesh;
    private float _characterTimer = 0f;
    private bool _isDeleting = true;
    private bool _isTweening = false;
    public float tweenTime = 0.05f;
    private IInteractable currentInteractableObject;


    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }


    private void FixedUpdate()
    {
        if (_isTweening)
            Tween(Time.fixedDeltaTime);
        
        if(PlayerInteract.interactableObject != null && (PlayerInteract.interactableObject != currentInteractableObject || PlayerInteract.interactableObject.Data() != Text))
        {
            SetText(PlayerInteract.interactableObject.Data());
            currentInteractableObject = PlayerInteract.interactableObject;
        }
        if(PlayerInteract.interactableObject == null && PlayerInteract.interactableObject != currentInteractableObject)
            SetText("---");
            currentInteractableObject = PlayerInteract.interactableObject;
    }


    public void SetText(string text)
    {
        if (text == null || _textMesh.text == text)
            return;
        Text = text;
        _isDeleting = _textMesh.text.Length > 0;
        _isTweening = true;
        _characterTimer = tweenTime;
    }


    private void Tween(float timeDelta)
    {
        _characterTimer -= timeDelta;
        if (_characterTimer < 0)
        {
            _characterTimer = tweenTime;
            if (_isDeleting)
            {
                _textMesh.text = _textMesh.text.Remove(_textMesh.text.Length - 1);
                _isDeleting = _textMesh.text.Length > 0;
            }
            else
            {
                if (Text.Length == 0)
                {
                    _isTweening = false;
                    return;
                }
                _textMesh.text += Text[_textMesh.text.Length];
                _isTweening = _textMesh.text.Length != Text.Length;
            }
        }
    }
}
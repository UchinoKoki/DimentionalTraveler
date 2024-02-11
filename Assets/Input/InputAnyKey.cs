using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//何かのKeyを押されたらUnityEventを発行する
public class InputAnyKey : MonoBehaviour
{
    [SerializeField] private UnityEvent onInputAnyKey;
    private InputAction _pressAnyKeyAction = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>",interactions: "press");
    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();
    
    void Update(){
        if (_pressAnyKeyAction.triggered) onInputAnyKey.Invoke();
    }
    public void DebugLog(){
        Debug.Log("InputAnyKey");
    }
}

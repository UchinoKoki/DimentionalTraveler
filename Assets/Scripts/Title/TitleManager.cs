using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;
    [SerializeField] private UnityEvent onCompleteIndication;
    
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void OnCompleteIndication()
    {
        onCompleteIndication.Invoke();
    }
}

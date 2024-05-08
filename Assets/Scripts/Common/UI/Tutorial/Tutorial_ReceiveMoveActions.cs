using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial_ReceiveMoveActions : MonoBehaviour
{
    [SerializeField] private TutorialGameSceneTab tutorialGameSceneTab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMoveObserve(InputAction.CallbackContext context)
    {
        if(tutorialGameSceneTab.gameObject.activeSelf == false) return;
        if(context.ReadValue<Vector2>().y > 0)
        {
            tutorialGameSceneTab.SetMark(0);
        }
        if(context.ReadValue<Vector2>().y < 0)
        {
            tutorialGameSceneTab.SetMark(2);
        }
        if(context.ReadValue<Vector2>().x < 0)
        {
            tutorialGameSceneTab.SetMark(1);
        }
        if(context.ReadValue<Vector2>().x > 0)
        {
            tutorialGameSceneTab.SetMark(3);
        }

    }
}

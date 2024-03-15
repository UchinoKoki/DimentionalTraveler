using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_AbilityEditorExit : MonoBehaviour
{
    [SerializeField] private PlayerAbility playerAbility;
    [SerializeField] private TutorialSelectCharacter tutorialSelectCharacter;
    [SerializeField] int sentNum = 0;
    public void OnCilick()
    {
        if(playerAbility.AbilityCost == 0)
        {
            tutorialSelectCharacter.DeActiveMenu(sentNum);
        }
    }
}

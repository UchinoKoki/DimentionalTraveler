using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_AbilityObserver : MonoBehaviour
{
    [SerializeField]private PlayerAbility playerAbility;
    [SerializeField]private TutorialSelectCharacter tutorialSelectCharacter;
    [SerializeField] private int sentNum;
    void Update()
    {
        if(playerAbility.AbilityCost == 0)
        {
            tutorialSelectCharacter.DeActiveMenu(sentNum);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingCostText : MonoBehaviour
{
    [SerializeField]PlayerAbility playerAbility;
    int previouseCost = 0;

    [SerializeField] private TextMeshProUGUI costText;

    void Start()
    {
        costText = GetComponent<TextMeshProUGUI>();
        costText.text = "Cost:" + playerAbility.AbilityCost.ToString();
    }

    void Update()
    {
        if(previouseCost != playerAbility.AbilityCost)
        {
            previouseCost = playerAbility.AbilityCost;
            costText.text = "RemainingCost:" + playerAbility.AbilityCost.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAsset", menuName = "ScriptableObject/PlayerAbilityAsset", order = 0)]
public class PlayerAbilityAsset : ScriptableObject {
    public string abilityName;
    public int useSlotResource;
    public int useCost;
    public float coolTime;
}

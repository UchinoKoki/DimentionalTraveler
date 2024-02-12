using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAsset", menuName = "ScriptableObject/AbilityAsset", order = 0)]
public class AbilityAsset : ScriptableObject {
    public string abilityName;
    public int useSlotResource;
    public int useCost;
    public float coolTime;
}

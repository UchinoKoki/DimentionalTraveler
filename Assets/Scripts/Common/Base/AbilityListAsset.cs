using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAsset", menuName = "ScriptableObject/AbilityAsset", order = 0)]
public class AbilityListAsset : ScriptableObject {
    public List<AbilityAsset> abilityList;
}

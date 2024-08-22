using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Creature/CreatureStatsScriptableObject")]
public class CreatureStatsSO : ScriptableObject
{
    public string creatureName;
    public string habitat;
    public string timeAwake;
    public string passiveBuffs;

    public string creatureNickName;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Scriptble Object/ChallengeData")]
public class ChallengeData : ScriptableObject
{
    [Header("Main Info")]
    public int challengeId;
    public string challengeName;

    [Header("Desc")]
    [TextArea]
    public string challengeDesc;
    [TextArea]
    public string unlockRequirement;
    
    public int unlockValue;
}

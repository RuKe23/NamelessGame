using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScriptA : ITarget
{
    public override void TargetFunction()
    {
        Debug.Log("TargetScriptA");
    }
}
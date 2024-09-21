using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITarget : MonoBehaviour
{
    public abstract void TargetFunction();
}


public class TargetScriptB : ITarget
{
    public override void TargetFunction()
    {
        Debug.Log("TargetScriptB");
    }
}



public class InterfaceTestCode : MonoBehaviour
{
    [SerializeReference]
    public ITarget targetScript;

    // Start is called before the first frame update
    void Start()
    {
        targetScript.TargetFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

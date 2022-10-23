using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomiting : AgentBehavior
{

    //move towards a target
    public override steering GetSteering()
    {
        steering steer = new steering();
        steer.linear = Vector3.zero;

        return steer;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : AgentBehavior
{
    public Vector3 targetPosition;

    //move towards a target
    public override steering GetSteering()
    {
        steering steer = new steering();
        steer.linear = target.transform.position - transform.position;
        steer.linear.Normalize();
        steer.linear = steer.linear * agent.maxAccel;
        float AngleDeg = Mathf.Atan2(target.transform.position.z - steer.linear.z, target.transform.position.x - steer.linear.x);
        steer.angular = (180 / Mathf.PI) * AngleDeg;

        if (steer.angular > 0)
        {
            steer.angular = 1;
        }
        else
        {
            steer.angular = -1;
        }


        return steer;
    }
}

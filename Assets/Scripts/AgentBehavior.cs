using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : MonoBehaviour
{
    public float weight = 1.0f;

    public GameObject target;
    protected Agent agent;
    public Vector3 dest;

    public virtual void Start()
    {
        agent = gameObject.GetComponent<Agent>();

    }

    public virtual void Update()
    {

        agent.SetSteering(GetSteering(), weight);

    }



    public virtual steering GetSteering()
    {
        return new steering();
    }
}
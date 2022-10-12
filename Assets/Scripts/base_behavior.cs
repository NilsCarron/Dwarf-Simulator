using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_behavior : MonoBehaviour
{

    public int team;

    //links to the different behavior components
    public seek_script seek;

    //gps is our general pathfinding script
    //public general_pathfinding gps;

    //intelligent movement scripts
    public Agent agentScript;

    public Seek seekScript;
    public Flee fleeScript;

    public float maxSpeed;

    public GameObject target;
    public UnitFSM state;

    public enum UnitFSM //states
    {
        Attack,
        Seek,
        Idle
    }

    // Start is called before the first frame update
    void Start()
    {
        agentScript = gameObject.AddComponent<Agent>(); //add agent
        agentScript.maxSpeed = maxSpeed;

        changeState(UnitFSM.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(state == UnitFSM.Idle)
            {
                changeState(UnitFSM.Seek);
            }
            else
            {
                changeState(UnitFSM.Idle);
            }
        }
    }

    public void changeState(UnitFSM new_state)
    {

        state = new_state;

        switch (new_state)
        {
            case UnitFSM.Idle:

                DestroyImmediate(seek);

                break;

            case UnitFSM.Seek:

                if (gameObject.GetComponent<seek_script>() == null)
                {
                    seek = gameObject.AddComponent<seek_script>();
                }

                break;

            case UnitFSM.Attack:


                DestroyImmediate(seek);

                break;



        }
    }
}

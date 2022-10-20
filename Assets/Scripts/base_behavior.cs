using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_behavior : MonoBehaviour
{

    public int team;

    //links to the different behavior components
    public seek_script seek;
    public wandering_script wandering;


    //gps is our general pathfinding script
    //public general_pathfinding gps;

    //intelligent movement scripts
    public Agent agentScript;
    public BoidCohesion boidcoh;
    public BoidSeparation boidsep;
    public Seek seekScript;
    public Wandering wanderingScript;
    
    
    public float maxSpeed;

    public GameObject target;
    public UnitFSM state;

    public enum UnitFSM //states
    {
       // Attack,
        Seek,
        Idle
    }

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = gameObject;
        }
        agentScript = gameObject.AddComponent<Agent>(); //add agent
        agentScript.maxSpeed = maxSpeed;

        changeState(UnitFSM.Seek);
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

                
                if (gameObject.GetComponent<wandering_script>() == null)
                {
                    wandering = gameObject.AddComponent<wandering_script>();
                }
                DestroyImmediate(seek);

                break;

            case UnitFSM.Seek:
                if (gameObject.GetComponent<seek_script>() == null)
                {
                    seek = gameObject.AddComponent<seek_script>();
                }
                DestroyImmediate(wandering);

                break;

          //  case UnitFSM.Attack:


            //    DestroyImmediate(seek);

              //  break;



        }
    }
}

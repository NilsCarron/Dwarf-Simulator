using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public  enum UnitFSM //states
{
    // Attack,
    Seek,
    Idle,
    GotoMine,
    Vomiting,
    Flee
}
public class BaseBehavior : MonoBehaviour
{

    public int team;

    //links to the different behavior components
    public SeekScript seek;        
    public Animator animator;

    public WanderingScript wandering;
    public GoToMineScript goToMine;
    public VomitingScript vomiting;
    public FleeScript fleeing;


    //gps is our general pathfinding script
    //public general_pathfinding gps;

    //intelligent movement scripts
    public Agent agentScript;
    public BoidCohesion boidcoh;
    public BoidSeparation boidsep;
    public Seek seekScript;
    public Wandering wanderingScript;
    public GoingToMine goingToMineScript;
    public Vomiting vomitingScript;
    public Flee fleeingScript;

    public bool isDrunk;
    
    public float maxSpeed;

    public GameObject target;
    public UnitFSM state;



    // Start is called before the first frame update
    void Start()
    {
        isDrunk = false;
        if (target == null)
        {
            target = gameObject;
        }
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

                
                if (gameObject.GetComponent<WanderingScript>() == null)
                {
                    wandering = gameObject.AddComponent<WanderingScript>();
                }
                Destroy(seek);
                Destroy(goToMine);
                Destroy(vomiting);


                break;
            case UnitFSM.GotoMine:

                
                if (gameObject.GetComponent<GoToMineScript>() == null)
                {
                    goToMine = gameObject.AddComponent<GoToMineScript>();
                }
                Destroy(seek);
                Destroy(wandering);
                Destroy(vomiting);
                Destroy(fleeing);


                break;

            case UnitFSM.Seek:
                if (gameObject.GetComponent<SeekScript>() == null)
                {
                    seek = gameObject.AddComponent<SeekScript>();
                }
                Destroy(wandering);
                Destroy(goToMine);
                Destroy(vomiting);
                Destroy(fleeing);


                break;
            case UnitFSM.Vomiting:

                
                if (gameObject.GetComponent<VomitingScript>() == null)
                {
                    vomiting = gameObject.AddComponent<VomitingScript>();
                }
                Destroy(seek);
                Destroy(goToMine);
                Destroy(wandering);
                Destroy(fleeing);


                break;
            case UnitFSM.Flee:

                
                if (gameObject.GetComponent<FleeScript>() == null)
                {
                    fleeing = gameObject.AddComponent<FleeScript>();
                }
                Destroy(seek);
                Destroy(goToMine);
                Destroy(wandering);
                Destroy(vomiting);

                break;



        }
    }
}



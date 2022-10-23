using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeScript : MonoBehaviour
{
    BaseBehavior bb;
    GameObject target;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<BaseBehavior>();
        target = bb.target;


        if(bb.fleeingScript == null)
        {

            
            
            bb.fleeingScript = gameObject.AddComponent<Flee>();
            bb.fleeingScript.target = bb.target;
            bb.fleeingScript.weight = 0.7f;
            bb.fleeingScript.enabled = true;

            
            if (bb.boidcoh == null)
            {
                bb.boidcoh = gameObject.AddComponent<BoidCohesion>();
                bb.boidcoh.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidcoh.weight = 0.0f;
                bb.boidcoh.enabled = false;
            }

            if (bb.boidsep == null)
            {
                bb.boidsep = gameObject.AddComponent<BoidSeparation>();
                bb.boidsep.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidsep.weight = 15f;
                bb.boidsep.enabled = false;
            }
            
        }
        
    }

    /*IEnumerator WaitRandomAmountOfSeconds()
    {
        while (true)
        {
            //Print the time of when the function is first called.

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds((int)UnityEngine.Random.Range(1, 60));

            //After we have waited 5 seconds print the time again.
            Debug.Log("I drank enough! Let's take some fresh air!");
            bb.isDrunk = true;
            bb.changeState(UnitFSM.Idle);
        }
    }*/





    private void OnDestroy()
    {
        Destroy(bb.fleeingScript);
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Fleeing");
    }

}
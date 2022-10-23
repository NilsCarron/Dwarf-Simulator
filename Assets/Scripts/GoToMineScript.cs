using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GoToMineScript : MonoBehaviour
{
    BaseBehavior bb;
    GameObject target;
    private IEnumerator coroutine;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<BaseBehavior>();
        target = GameManager.Instance.Mine;
        rb = gameObject.GetComponent<Rigidbody>();
        
        
        if(bb.goingToMineScript == null)
        {
            bb.goingToMineScript = gameObject.AddComponent<GoingToMine>();
            bb.goingToMineScript.target = target;
            bb.goingToMineScript.weight = 1.0f;
            bb.goingToMineScript.enabled = true;

            if (bb.boidcoh == null)
            {
                bb.boidcoh = gameObject.AddComponent<BoidCohesion>();
                bb.boidcoh.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidcoh.weight = 0.50f;
                bb.boidcoh.enabled = true;
            }

            if (bb.boidsep == null)
            {
                bb.boidsep = gameObject.AddComponent<BoidSeparation>();
                bb.boidsep.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidsep.weight = 70.0f;
                bb.boidsep.enabled = true;
            }


        }
        
    }

    
    IEnumerator WaitRandomAmountOfSeconds()
    {
        while (true)
        {
            //Print the time of when the function is first called.

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds((int)UnityEngine.Random.Range(1, 60));

            //After we have waited 5 seconds print the time again.
            Debug.Log("Ill Take a Drink");
            bb.changeState(UnitFSM.Seek);
        }
    }




    private void OnTriggerEnter(Collider collision)    {
        if (collision.gameObject.CompareTag($"Mine"))
        {
            Debug.Log("je commence à miner");
            coroutine = WaitRandomAmountOfSeconds();
            StartCoroutine(coroutine);
            
        }
    }


    private void OnDestroy()
    {

        Destroy(bb.goingToMineScript); 
        
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "GoToMine");
    }

}

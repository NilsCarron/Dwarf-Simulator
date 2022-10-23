using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class VomitingScript : MonoBehaviour
{
    BaseBehavior bb;
    private bool isDrunk;
    GameObject target;
    private IEnumerator coroutine;

    private float ampleurMovement;
    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<BaseBehavior>();


        bb.boidcoh.enabled = false;
        bb.boidsep.enabled = false;



        if(bb.vomitingScript == null)
        {
            bb.vomitingScript = gameObject.AddComponent<Vomiting>();
            bb.vomitingScript.target = target;
            bb.vomitingScript.weight = 1.0f;
            bb.vomitingScript.enabled = true;

           

        }
        Debug.Log("I'm beginning to vomit!");
        bb.animator.SetBool("Vomiting", true);
        bb.animator.SetBool("Walking", false);

        gameObject.tag = "SickDwarf";
        coroutine = WaitRandomAmountOfSeconds();
        StartCoroutine(coroutine);
        
    }

    IEnumerator WaitRandomAmountOfSeconds()
    {
        while (true)
        {
            //Print the time of when the function is first called.

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds((int)UnityEngine.Random.Range(1, 60));

            //After we have waited 5 seconds print the time again.
            Debug.Log("I feel much better");
            bb.animator.SetBool("Vomiting", false);
            bb.animator.SetBool("Walking", true);

            bb.isDrunk = false;
            gameObject.tag = "Dwarf";

            bb.changeState(UnitFSM.Idle);
        }
    }





    private void Update()
    {
        
    }


    

    private void OnDestroy()
    {

        Destroy(bb.vomitingScript); 
        
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Vomiting");
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class WanderingScript : MonoBehaviour
{
    BaseBehavior bb;
    private bool isDrunk;
    GameObject target;
    public GameObject temporaryTarget;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<BaseBehavior>();
        bb.animator.SetBool("Walking", true);

        isDrunk = bb.isDrunk;
        temporaryTarget = new GameObject("target");
        target = temporaryTarget;

        UpdateTarget();


        if (isDrunk)
        {
            coroutine = WaitRandomAmountOfSeconds();
            StartCoroutine(coroutine);

        }
        
        
        if(bb.boidcoh != null )
            bb.boidcoh.enabled = true;
        if(bb.boidsep != null )
            bb.boidsep.enabled = true;

        if(bb.wanderingScript == null)
        {
            bb.wanderingScript = gameObject.AddComponent<Wandering>();
            bb.wanderingScript.target = target;
            bb.wanderingScript.weight = 1.0f;
            bb.wanderingScript.enabled = true;

            if (bb.boidcoh == null)
            {
                bb.boidcoh = gameObject.AddComponent<BoidCohesion>();
                bb.boidcoh.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidcoh.weight = 7f;
                bb.boidcoh.enabled = true;
            }

            if (bb.boidsep == null)
            {
                bb.boidsep = gameObject.AddComponent<BoidSeparation>();
                bb.boidsep.targets = bb.target.GetComponent<SquadParentScript>().children;
                bb.boidsep.weight = 15.0f;
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
            Debug.Log("I don't feel so good");
            bb.changeState(UnitFSM.Vomiting);//vomit
        }
    }





    private void Update()
    {

        if (transform.position.x < target.transform.position.x + 1 && transform.position.z < target.transform.position.z +1)
        {
             UpdateTarget();
        }
    }


    private void UpdateTarget()
    {
        Vector3 clampedVector;

        if(!isDrunk){
        clampedVector = new Vector3(UnityEngine.Random.Range(-200, 200) ,transform.transform.position.y, UnityEngine.Random.Range(-200, 200));
        
        if (clampedVector.x > 1500)
            clampedVector.x -= 200;
        else if (clampedVector.x < -1500)
            clampedVector.x += + 200;
        
        if (clampedVector.y > 1500)
            clampedVector.y -= 200;
        else if (clampedVector.y < -1500)
            clampedVector.y += 200;
        
        if (clampedVector.z > 1500)
            clampedVector.z -=  200;
        else if (clampedVector.z < -1500)
            clampedVector.z +=  200;
        }
        else
        {
            Transform transform1;
            clampedVector = new Vector3(transform.position.x + UnityEngine.Random.Range(-5, 5) ,(transform1 = transform).transform.position.y, transform1.position.z + UnityEngine.Random.Range(-5, 5));
        }


        target.transform.position = clampedVector;
        
    }




    private void OnDestroy()
    {
        Destroy(temporaryTarget); 
        if(bb.wanderingScript != null)
        Destroy(bb.wanderingScript); 
        
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Wandering");
    }

}

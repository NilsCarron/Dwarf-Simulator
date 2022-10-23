using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekScript : MonoBehaviour
{
    BaseBehavior bb;
    GameObject target;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<BaseBehavior>();
        target = GameManager.Instance.Tavern;

        bb.boidcoh.enabled = false;

        if(bb.seekScript == null)
        {

            
            
            bb.seekScript = gameObject.AddComponent<Seek>();
            bb.seekScript.target = target;
            bb.seekScript.weight = 0.7f;
            bb.seekScript.enabled = true;

            
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

    IEnumerator WaitRandomAmountOfSeconds()
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
    }




    private void OnTriggerEnter(Collider collision)    {
        if (collision.gameObject.CompareTag($"Tavern"))
        {
            Debug.Log("I'm beginning to drink");
            coroutine = WaitRandomAmountOfSeconds();
            StartCoroutine(coroutine);
            
        }
    }
    private void OnDestroy()
    {
        Destroy(bb.seekScript);
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Seek");
    }

}
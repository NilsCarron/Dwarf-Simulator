using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class wandering_script : MonoBehaviour
{
    base_behavior bb;
    GameObject target;
    public GameObject temporaryTarget;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<base_behavior>();
        temporaryTarget = new GameObject("target");
        target = temporaryTarget;
        UpdateTarget();

        
        if(bb.wanderingScript == null)
        {
            bb.wanderingScript = gameObject.AddComponent<Wandering>();
            bb.wanderingScript.target = target;
            bb.wanderingScript.weight = 1.0f;
            bb.wanderingScript.enabled = true;

            if (bb.boidcoh == null)
            {
                bb.boidcoh = gameObject.AddComponent<BoidCohesion>();
                bb.boidcoh.targets = bb.target.GetComponent<squad_parent_script>().children;
                bb.boidcoh.weight = 0.4f;
                bb.boidcoh.enabled = true;
            }

            if (bb.boidsep == null)
            {
                bb.boidsep = gameObject.AddComponent<BoidSeparation>();
                bb.boidsep.targets = bb.target.GetComponent<squad_parent_script>().children;
                bb.boidsep.weight = 70.0f;
                bb.boidsep.enabled = true;
            }


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

        Random rnd = new Random();

        target.transform.position = new Vector3(transform.position.x + rnd.Next(-50, 50),transform.position.y, transform.position.z + rnd.Next(-50, 50));
    }




    private void OnDestroy()
    {
        DestroyImmediate(temporaryTarget); 

        DestroyImmediate(bb.wanderingScript); 
        
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Wandering");
    }

}

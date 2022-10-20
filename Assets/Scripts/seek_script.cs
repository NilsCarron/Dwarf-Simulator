using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_script : MonoBehaviour
{
    base_behavior bb;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<base_behavior>();
        target = bb.target;

        
        if(bb.seekScript == null)
        {
            Debug.Log("ésdFBIjk");

            bb.seekScript = gameObject.AddComponent<Seek>();
            bb.seekScript.target = target;
            bb.seekScript.weight = 0.7f;
            bb.seekScript.enabled = true;

            
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

    
    private void OnDestroy()
    {
        DestroyImmediate(bb.seekScript);
    }
    

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Seek");
    }

}
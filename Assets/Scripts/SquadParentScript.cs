using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadParentScript : MonoBehaviour
{



    public GameObject target;


    public GameObject child_prefab;
    public List<GameObject> children;

    public int amoundOfChildrens;
    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();

        for(int index = 0; index < amoundOfChildrens; ++index)
        {
            Vector3 relative_spawn = new Vector3(UnityEngine.Random.Range(-150f, 150f), -1.25f, UnityEngine.Random.Range(-150f, 150f));
            GameObject temp = Instantiate(child_prefab, (transform.position + relative_spawn ), transform.rotation);
            temp.GetComponent<BaseBehavior>().target = gameObject;
            children.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized.normalized * (Time.deltaTime * 5.0f);
             
    }
}
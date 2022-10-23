using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;

    public List<GameObject> DwarfList;
    // Start is called before the first frame update
    void Start()
    {
        DwarfList = new List<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SickDwarf"))
        {
            GetComponent<BaseBehavior>().target = other.gameObject;
            GetComponent<BaseBehavior>().changeState(UnitFSM.Flee);
        }
        
        

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dwarf") && !collision.gameObject.GetComponent<BaseBehavior>().isDrunk)
        {
            
      
                DwarfList.Add(collision.gameObject);
                if (DwarfList.Count > 10)
                {
                    foreach (var Dwarf in DwarfList)
                    {
                        if(Dwarf.GetComponent<BaseBehavior>().state == UnitFSM.Idle && !Dwarf.GetComponent<BaseBehavior>().isDrunk){
                            Debug.Log("I'll go to mine today!");
                            Dwarf.GetComponent<BaseBehavior>().changeState(UnitFSM.GotoMine);
                        }
                    }
                }
            
        }
       

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        GetComponent<BaseBehavior>().boidsep.targets.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dwarf"))
        {
            
            DwarfList.Remove(collision.gameObject);
            
        }
        
        
        if (collision.gameObject.CompareTag("SickDwarf") && GetComponent<BaseBehavior>().state == UnitFSM.Flee)
        {
            GetComponent<BaseBehavior>().changeState(UnitFSM.Idle);
        }
    }


}

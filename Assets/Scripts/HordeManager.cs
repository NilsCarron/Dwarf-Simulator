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
        if (other.gameObject.CompareTag("sickDwarf"))
        {
            GetComponent<base_behavior>().target = other.gameObject;
            GetComponent<base_behavior>().changeState(UnitFSM.Flee);
        }
        
        

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("dwarf") && !collision.gameObject.GetComponent<base_behavior>().isDrunk)
        {
            
      
                DwarfList.Add(collision.gameObject);
                if (DwarfList.Count > 15)
                {
                    foreach (var Dwarf in DwarfList)
                    {
                        if(Dwarf.GetComponent<base_behavior>().state == UnitFSM.Idle && !Dwarf.GetComponent<base_behavior>().isDrunk){
                            Debug.Log("I'll go to mine today!");
                            Dwarf.GetComponent<base_behavior>().changeState(UnitFSM.GotoMine);
                        }
                    }
                }
            
        }
        

        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("dwarf"))
        {
            
            DwarfList.Remove(collision.gameObject);
            
        }
        
        
        if (collision.gameObject.CompareTag("sickDwarf") && GetComponent<base_behavior>().state == UnitFSM.Flee)
        {
            GetComponent<base_behavior>().changeState(UnitFSM.Idle);
        }
    }


}

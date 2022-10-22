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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("dwarf"))
        {
            
            DwarfList.Add(collision.gameObject);
            
        }

        if (DwarfList.Count > 15)
        {
            foreach (var Dwarf in DwarfList)
            {
                if(Dwarf.GetComponent<base_behavior>().state == UnitFSM.Idle){
                    Debug.Log("I'll go to mine today!");
                    Dwarf.GetComponent<base_behavior>().changeState(UnitFSM.GotoMine);
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
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject Mine;
    [SerializeField] public GameObject Tavern;


    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is Null!");
            }

            return _instance;
        }


    }

    private void Awake()
    {
        _instance = this;
    }
}

using UnityEngine;
using System.Collections;

public class steering
{
    public float angular; //rotation 0-360
    public Vector3 linear; //velocity
    public steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }
}
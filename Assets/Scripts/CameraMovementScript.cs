using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    float speed = 0.06f;
    float zoomSpeed = 10.0f;
    float roateSpeed = 0.1f;
    float maxHeight = 40;
    float minHeight = -30;
    Vector2 p1;
    Vector2 p2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
            zoomSpeed = 20.0f;
        }
        else
        {
            speed = 5f;
            zoomSpeed = 10.0f;

        }


        float hsp = speed * Input.GetAxis("Horizontal");
        float vsp = speed * Input.GetAxis("Vertical");
        float scrollSp = -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
        
        
        if((transform.position.y + scrollSp) > maxHeight)
        {
            scrollSp = 0;
        }
        else if((transform.position.y + scrollSp) < minHeight)
        {
            scrollSp = minHeight + transform.position.y;
            scrollSp = 0;
             
        }



        Vector3 verticalMove = new Vector3(0, scrollSp, 0);


        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;
        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;


        getCameraRotation();
    }


    void getCameraRotation()
    {
        if (Input.GetMouseButtonDown(2)){
            p1 = Input.mousePosition;

        }

        if (Input.GetMouseButton(2))
        {

            p2 = Input.mousePosition;

            float dx = (p1 - p2).x * roateSpeed;
            float dy = (p2 - p1).y * roateSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, -dx, 0));
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));


            p1 = p2;
        }



    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2000f;
    [SerializeField] private float switchSpeed = 1000f;
    Rigidbody rb;

    private bool isonleft = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {     
        rb.AddForce(new Vector3(0, 0, speed * Time.deltaTime));

        if(Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                transform.position = Vector3.Slerp(transform.position, new Vector3(-5, transform.position.y, transform.position.z), switchSpeed * Time.deltaTime);
                isonleft = true;
            }

            if (Input.mousePosition.x > Screen.width / 2 && isonleft == true)
            {
                transform.position = Vector3.Slerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), switchSpeed * Time.deltaTime);
                isonleft = false;
            }
            
        }

    }
    
}

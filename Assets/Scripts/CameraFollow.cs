using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 offset;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
       offset = new Vector3(0, 5, -8); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = player.transform.position + offset;
        targetPos.x = transform.position.x; // keep camera x constant
        transform.position = targetPos;

    
    }
}

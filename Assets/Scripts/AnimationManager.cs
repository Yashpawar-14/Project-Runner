using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    PlayerMovement playerMovement;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.Isrunning == true)
        {
            animator.SetBool("IsRunning", true);
        }
        else{
            animator.SetBool("IsRunning", false);
        }
    }
}

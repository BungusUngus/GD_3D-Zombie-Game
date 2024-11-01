using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Vector3 moveDirection;
    Vector2 input;

    void Start()
    {
        
    }

    void Update()
    {
        //Get movement inputs for the frame
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        //Apply inputs to the horizontal plane of movement
        moveDirection.x = input.x * speed;
        moveDirection.z = input.y * speed;

        //Move based on moveDirection using time
        GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float rotationSpeed;

    Vector3 moveDirection;
    Vector2 input;

    private Vector3 rotation;

    void Start()
    {
        
    }

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        controller.Move(move * speed);
        this.transform.Rotate(this.rotation);
    }

    /*void Update()
    {
        //Get movement inputs for the frame
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        //Apply inputs to the horizontal plane of movement
        moveDirection.x = input.x * speed;
        moveDirection.z = input.y * speed;

        //Move based on moveDirection using time
        GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime);
    }*/
}

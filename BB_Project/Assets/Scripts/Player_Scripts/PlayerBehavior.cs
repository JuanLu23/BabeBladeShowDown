using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Manages the velocity of the player per coordinate
    private Vector3 playerVelocity = Vector3.zero;
    //Value to easily change the player's speed
    public float speed = 10;
    public GameObject Playermodel;

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        //Player movement controller
        if (Input.GetKey("right"))
        {
            direction = new Vector3(1, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            direction = new Vector3(-1, 0, 0);
        }
        if (Input.GetKey("up"))
        {
            direction = new Vector3(0, 0, 1);
        }
        if (Input.GetKey("down"))
        {
            direction = new Vector3(0, 0, -1);
        }
        if (Input.GetKey("up") && Input.GetKey("right"))
        {
            direction = new Vector3(1, 0, 1);
        }
        if (Input.GetKey("up") && Input.GetKey("left"))
        {
            direction = new Vector3(-1, 0, 1);
        }
        if (Input.GetKey("down") && Input.GetKey("right"))
        {
            direction = new Vector3(1, 0, -1);
        }
        if (Input.GetKey("down") && Input.GetKey("left"))
        {
            direction = new Vector3(-1, 0, -1);
        }
        SmoothMovement(direction);
    }

    //This function manages the player's movement
    private void SmoothMovement(Vector3 direction)
    {
        //This variable sets the speed to the desired direction
        Vector3 desiredVelocity = direction.normalized * speed;
        //This variable pushes the player to the desired direction
        Vector3 steeringForce = desiredVelocity - playerVelocity;
        playerVelocity += steeringForce * Time.deltaTime;
        transform.position += playerVelocity * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        //Si el player sale del arena eliminara el control del player sobre el trompo.
        Playermodel.GetComponent<PlayerBehavior>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool lerpCrouch;
    private float crouchTimer;
    private bool crouching;
    private bool sprinting;
    public float speed = 5.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    void Start()
    {

        controller = GetComponent<CharacterController>();
        
    }

    void Update() {

        isGrounded = controller.isGrounded;

        if(lerpCrouch){

            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if(crouching){

                controller.height = Mathf.Lerp(controller.height, 1, p);

            } else {

                controller.height = Mathf.Lerp(controller.height, 2, p);

            }

            if(p > 1){

                lerpCrouch = false;
                crouchTimer = 0f;

            }

        }
        
    }

    public void ProcessMove(Vector2 input){

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        if(isGrounded && velocity.y < 0){

            velocity.y = -2f;

        }
        controller.Move(velocity * Time.deltaTime);

    }

    public void Jump(){

        if(isGrounded){

            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);

        }

    }

    public void Crouch(){

        crouching = !crouching;
        crouchTimer = 0.0f;
        lerpCrouch = true;

    }

    public void Sprint(){

        sprinting = !sprinting;

        if(sprinting){

            speed = speed + 3.0f;

        } else {

            speed = speed - 3.0f;

        }

    }

}

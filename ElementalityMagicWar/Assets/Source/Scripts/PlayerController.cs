using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] Gravity gravity;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private Vector3 velocityPlayer;
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * directionX + transform.forward * directionZ;
        player.Move(moveDirection*speed*Time.deltaTime);

        player.Move(velocityPlayer * Time.deltaTime);

        if(player.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                velocityPlayer = gravity.Jump(jumpForce);
        }
        else velocityPlayer = gravity.Velocity();
    }
}
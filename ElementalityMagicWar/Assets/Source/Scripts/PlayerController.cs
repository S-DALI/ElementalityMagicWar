using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] Gravity gravity;

    [SerializeField] private float RunSpeed = 10f;
    [SerializeField] private float WalkSpeed = 4f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float squatHeight = 1.5f;
    [SerializeField] private float offsetCentrController = -0.25f;
    [SerializeField] private float cameraOffsetPosition;


    public event Action<bool> OnRun;

    private float standHeight;
    private float speed;
    private Vector3 velocityPlayer;
    private void Start()
    {
        speed = WalkSpeed;
        standHeight = player.height;
    }
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * directionX + transform.forward * directionZ;
        player.Move(moveDirection * speed * Time.deltaTime);
        player.Move(velocityPlayer * Time.deltaTime);

        if (player.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                velocityPlayer = gravity.Jump(jumpForce);
        }
        else velocityPlayer = gravity.Velocity();


        if (Input.GetKey(KeyCode.LeftControl) && player.isGrounded && !Input.GetKey(KeyCode.LeftShift))
        {
            player.height = squatHeight;
            player.center = new Vector3(0, offsetCentrController, 0);
        }
        else
        {
            player.height = standHeight;
            player.center = new Vector3(0, 0, 0);
        }


        if (Input.GetKey(KeyCode.LeftShift) && player.isGrounded && !Input.GetKey(KeyCode.LeftControl))
        {
            speed = RunSpeed;
            OnRun?.Invoke(true);
        }
        else
        {
            speed = WalkSpeed;
            OnRun?.Invoke(false);
        }
    }
}
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    void Start()
    {
        playerController.OnRun += Run;
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
            animator.SetBool("Walking", false);

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    animator.SetBool("Running", true);
        //}
        //else animator.SetBool("Running", false);

        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Crouching", true);
        }
        else
            animator.SetBool("Crouching", false);

        animator.SetFloat("VerticalInput", Input.GetAxis("Vertical"));
        animator.SetFloat("HorizontalInput", Input.GetAxis("Horizontal"));
    }

    void Run(bool isRunning)
    {
        if(isRunning && !Input.GetKey(KeyCode.LeftControl))
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);
    }
}

using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
            animator.SetBool("Walking", false);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);
        }
        else animator.SetBool("Running", false);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouching", true);
        }
        else
            animator.SetBool("Crouching", false);

        animator.SetFloat("VerticalInput", Input.GetAxis("Vertical"));
        animator.SetFloat("HorizontalInput", Input.GetAxis("Horizontal"));
    }
}

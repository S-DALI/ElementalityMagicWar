using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private Health capsule;
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            capsule.TakeDamage(damageAmount);
        }
    }



}


using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ShootProjectile:MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform LeftPointAttack;
    [SerializeField] private Transform RightPointAttack;

    private bool leftHandAttacked;
    private Vector3 destination;
    public void Attack(Camera cameraPlayers, float maxDestination)
    {
        Ray ray = cameraPlayers.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(maxDestination);
        if(leftHandAttacked)
        {
            leftHandAttacked = false;
            CreateProjectile(LeftPointAttack);
        }
        else
        {
            leftHandAttacked = true;
            CreateProjectile(RightPointAttack);
        }
    }

    void CreateProjectile(Transform attackPoint)
    {
        var projectileObject = Instantiate(projectile.gameObject,attackPoint.position,Quaternion.identity)as GameObject;
        projectileObject.GetComponent<Projectile>().Shot(destination, attackPoint);
    }
}
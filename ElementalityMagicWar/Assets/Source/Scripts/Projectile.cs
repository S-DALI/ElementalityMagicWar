using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject impactProjectile; 
    [SerializeField] private float arcRangeX = 3;
    [SerializeField] private float arcRangeY = 3;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float projectileSpeed = 30f;

    public void Shot(Vector3 destination, Transform startPoint)
    {
        GetComponent<Rigidbody>().velocity = (destination - startPoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(gameObject,new Vector3(Random.Range(-arcRangeX,arcRangeX), Random.Range(-arcRangeY, arcRangeY),0), Random.Range(0.5f, 2f));
    }
    private void OnCollisionEnter(Collision collision)
    {
           var impact = Instantiate(impactProjectile, collision.contacts[0].point, Quaternion.identity)as GameObject;
           Destroy(impact, 2f);
           Destroy(gameObject);

        if(collision.gameObject.GetComponent<Health>()!=null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

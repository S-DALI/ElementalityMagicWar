using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject impactProjectile;
    [SerializeField] private float arcRangeX = 1;
    [SerializeField] private float arcRangeY = 1;

    public void Shot(Vector3 destination, Transform startPoint, float projectileSpeed)
    {
        GetComponent<Rigidbody>().velocity = (destination - startPoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(gameObject,new Vector3(Random.Range(-arcRangeX,arcRangeX), Random.Range(-arcRangeY, arcRangeY),0), Random.Range(0.5f, 2f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag!="Player")
        {
           var impact = Instantiate(impactProjectile, collision.contacts[0].point, Quaternion.identity)as GameObject;
            Destroy(impact, 2f);
           Destroy(gameObject);
        }
    }
}

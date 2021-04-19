using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damageAmount = 10.0f;

    public bool damageOnTrigger = true;
    public bool damageOnCollision = false;
    public bool continuousDamage;
    public float continousTimeBetweenHits = 0;

    public bool destroySelfOnImpact = false;
    public float delayBeforeDestroy = 0.0f;
    public GameObject explosionPrefab;

    private float savedTime = 0;

    void OnTriggerEnter (Collider collision)
    {
        if (damageOnTrigger)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            collision.gameObject.GetComponent<Health> ().ApplyDamage(damageAmount);

            if(destroySelfOnImpact)
            {
                Destroy(gameObject, delayBeforeDestroy);
            }
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if (damageOnCollision)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            collision.gameObject.GetComponent<Health> ().ApplyDamage(damageAmount);

            if(destroySelfOnImpact)
            {
                Destroy(gameObject, delayBeforeDestroy);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOFView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obsticalMask;
    private LoadProjectiles lp;

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
        lp = gameObject.GetComponent<LoadProjectiles>();
    }

    IEnumerator FindTargetsWithDelay(float delay){
        while (true){
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius [i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);

                //there are no obsticales and we can see the target
                if (!Physics.Raycast(transform.position,dirToTarget, disToTarget,obsticalMask))
                {
                    Debug.Log("Gaurd sees player");
                   if(GameManager.gm != null)
                        GameManager.gm.playerHealth.isAlive = false;
                }
            }
        }
    }

    //Set the direction of the fow
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        //The fow is not a sphere
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

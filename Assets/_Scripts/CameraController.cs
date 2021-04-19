using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // The target we are following
	[SerializeField]
	private Transform target;

    Vector3 tempVec3 = new Vector3();

    void Start(){

    }

    void LateUpdate(){

        if(!target)
            return;
            
        tempVec3.x = this.transform.position.x;
        tempVec3.y = target.position.y;
        tempVec3.z = target.position.z;
        this.transform.position = tempVec3;
    }
}

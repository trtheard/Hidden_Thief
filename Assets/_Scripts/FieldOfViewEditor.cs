using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (fieldOFView))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI(){
        fieldOFView fow = (fieldOFView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

        //fow is not a sphere
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle/2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle/2, false);

        //Sets the length of the line
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

    }
}

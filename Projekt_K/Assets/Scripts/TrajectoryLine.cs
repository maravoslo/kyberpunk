using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
not working properly
*/
public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lr;

    public void RenderLine(Vector3 startPoint, Vector3 endPoint){
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        // Debug.Log(points[0] +  " " + points[1]);

        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);
    }

    public void EndLIne(){
        lr.positionCount = 0;
    }
}

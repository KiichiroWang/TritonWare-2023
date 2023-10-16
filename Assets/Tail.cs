using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int length;
    public float smoothSpeed;
    public float targetDist;
    public Transform targetDir;

    private Vector3[] segmentPoses;
    private Vector3[] segmentV;
    public LineRenderer lr;


    void Start()
    {
        lr.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lr.SetPositions(segmentPoses);
    }
}

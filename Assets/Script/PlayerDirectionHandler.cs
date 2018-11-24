using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North,South,East,West}

public class PlayerDirectionHandler : MonoBehaviour {

    [SerializeField] private Transform raycastRoot;

    // Update is called once per frame
    void Update () {
        CheckDirection();
    }

    void CheckDirection()
    {
        Vector3 origin = raycastRoot.position;
        origin.y += 2.5f;
        Vector3 fwd = raycastRoot.forward;
        
        Debug.DrawRay(origin, fwd * 50, Color.red);

        Ray ray = new Ray(origin, fwd);
        RaycastHit hits;
    }

    void ReportToCamera( Direction dir)
    {
        CameraMovement.Instance.ChangeDirection();
    }
}

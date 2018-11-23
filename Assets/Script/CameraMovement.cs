using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector3 playerPos;
    Vector3 getOffset;
    Transform player;
    GameObject raycastObject;

	// Use this for initialization
	void Start () {
        GetOffset();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        raycastObject = GameObject.FindGameObjectWithTag("Body");
    }
	
	// Update is called once per frame
	void Update () {
        GetPlayerCurrentPos();
        CamFollow();
        CheckDirection();
    }

    void GetOffset()
    {
        getOffset = this.transform.position - playerPos;
    }

    void GetPlayerCurrentPos()
    {
        playerPos = player.position + getOffset;
    }

    void CamFollow()
    {

        this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, Time.deltaTime * 100);
    }

    void CheckDirection()
    {
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * 50, Color.red);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerManager: MonoBehaviour, IDragHandler, IEndDragHandler
{

    Vector3 initPos;
    public Vector3 dir;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        initPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        dir = this.transform.position - initPos;
        dir.Normalize();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = initPos;
        dir = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 playerMove = Vector3.zero;
        playerMove.x = dir.x;
        playerMove.z = dir.y;
        player.Translate(playerMove.x * Time.deltaTime * 25, 0, playerMove.z * Time.deltaTime * 25, Space.World);
    }
}

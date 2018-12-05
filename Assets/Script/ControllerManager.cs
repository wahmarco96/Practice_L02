using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerManager: MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 initPos;
    public Vector3 dir;
    public Transform player;
    public Vector3 playerMove = Vector3.zero;
    public float smoothness = 0.1f;
    Animator animator;

    public bool wtf = true;

    public Player playerdata;

    public Transform modelRoot;

    // Use this for initialization
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        initPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        dir = this.transform.position - initPos;
        dir.Normalize();
        
        if (wtf == true)
        {
            animator.Play("Walking_Front");

        }
        
        // Control Model Rotation
        Vector3 delta = this.transform.transform.position - initPos;

        float angle = Mathf.Atan2( delta.x, delta.y) * Mathf.Rad2Deg;
        modelRoot.rotation = Quaternion.Lerp(modelRoot.rotation, Quaternion.Euler(0, angle+player.localEulerAngles.y, 0), Time.deltaTime * 30f);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = initPos;
        dir = Vector3.zero;
    }

    void Update()
    {
        //Move();
        WatTheFak();
        CheckTheFak();
    }
    void WatTheFak()
    {
        if (wtf == true)
        {
            Move();

        }
    }

    public void Move()
    {
        Vector3 playerMove = Vector3.zero;
        playerMove.x = dir.x;
        playerMove.z = dir.y;
        player.Translate(playerMove.x * Time.deltaTime * 50, 0, playerMove.z * Time.deltaTime * 50, Space.Self);
        animator.SetFloat("Forward", playerMove.z);
        animator.SetFloat("Left", playerMove.x);
    }

    public void CheckTheFak()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ComboA") == false && animator.GetCurrentAnimatorStateInfo(0).IsName("ComboB") == false
            && animator.GetCurrentAnimatorStateInfo(0).IsName("ComboC") == false && animator.GetCurrentAnimatorStateInfo(0).IsName("Heavy") == false
            && animator.GetCurrentAnimatorStateInfo(0).IsName("Skill01") == false && animator.GetCurrentAnimatorStateInfo(0).IsName("Skill02") == false
            && animator.GetCurrentAnimatorStateInfo(0).IsName("Ultimate") == false)
        {
            wtf = true;
        }
        else
        {
            wtf = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipingRotationManager : MonoBehaviour {

    public Vector3 rotation;
    Vector3 origin;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GetTouchDelta();
	}

    void GetTouchDelta()
    {
       if ( Input.touchCount >0)
        {
           if ( Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).position.x > (float)(Screen.width / 2))
                {
                    this.transform.Rotate(Vector3.up * Input.GetTouch(0).deltaPosition.x * Time.deltaTime * 20);
                }
            }
        }
    }
}

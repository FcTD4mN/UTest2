using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject mFollowMe;

    private Vector3 mOffset;

public
    void
    Start ()
    {
        mOffset = transform.position - mFollowMe.transform.position;
    }

public
    void
    LateUpdate ()
    {
        transform.position = mFollowMe.transform.position + mOffset;
        //mOffset = transform.position - mFollowMe.transform.position;
    }
}

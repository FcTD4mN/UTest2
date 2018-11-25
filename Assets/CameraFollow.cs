using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject   mFollowMe;
    public float        mZCamDistance;

    private Vector3 mOffset;

public
    void
    Start ()
    {
    }

public
    void
    LateUpdate ()
    {
        Vector3 followMePos = mFollowMe.transform.position;
        transform.position = new Vector3( followMePos.x, followMePos.y, mZCamDistance );
    }
}

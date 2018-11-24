using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements :
    MonoBehaviour {

    [Range(0f, 100f)] public float mMovementSpeed;
    [Range(0f, 100f)] public float mJumpPower;
    [SerializeField] private Transform mCeilingChecker;
    [SerializeField] private Transform mFloorChecker;

    private Rigidbody2D mObjectRB;
    private bool        mOnGround   = true;
    private bool        mCrouching  = false;


public
    void
    Awake ()
    {
        mObjectRB = GetComponent< Rigidbody2D >();
    }


public
    void
    FixedUpdate ()
    {
        if( Input.GetAxisRaw("Horizontal") > 0 )
            Move( new Vector2( 1f, 0f ) );
        else if( Input.GetAxisRaw("Horizontal") < 0 )
            Move( new Vector2( -1f, 0f ) );
        else
            Move( new Vector2( 0f, 0f ) );

        if (Input.GetButtonDown("Jump"))
            Jump();

    }

public
    void
    Move( Vector2 iDirection )
    {
        mObjectRB.velocity = iDirection * mMovementSpeed * Time.deltaTime;
    }

public
    void
    Jump()
    {
        if (!mOnGround)
            return;

        mObjectRB.AddForce( new Vector2( 0f, mJumpPower * Time.deltaTime) );
    }

}

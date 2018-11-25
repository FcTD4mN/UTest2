using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements :
    MonoBehaviour {

    [Range(0f, 100f)]   public  float       mMovementSpeed;
    [Range(0f, 1000f)]  public  float       mJumpPower;
    [SerializeField]    private Transform   mCeilingChecker;
    [SerializeField]    private Transform   mFloorChecker;

    private Rigidbody2D mObjectRB;
    private bool        mOnGround   = true;
    private bool        mCrouching  = false;

    private bool        mJump       = false;
    private bool        mCrouch     = false;


public
    void
    Awake ()
    {
        mObjectRB = GetComponent< Rigidbody2D >();
    }


public
    void
    Update()
    {
        if( Input.GetButtonDown( "Jump" ) )
            mJump = true;

    }


public
    void
    FixedUpdate ()
    {
        mOnGround = FloorCheck();


        Move( Input.GetAxisRaw( "Horizontal" ) );

        if( mJump)
        {
            Jump();
            mJump = false;
        }

    }


public
    void
    Move( float iHorizontalAxis )
    {
        mObjectRB.velocity = new Vector2( iHorizontalAxis * mMovementSpeed * Time.fixedDeltaTime * 10f, mObjectRB.velocity.y );
    }


public
    void
    Jump()
    {
        if (!mOnGround)
            return;

        mObjectRB.AddForce( new Vector2( 0f, mJumpPower ) );
    }


private
    bool
    FloorCheck()
    {
        Collider2D[] results = Physics2D.OverlapBoxAll(mFloorChecker.position, new Vector2(1f, 1f), 0f);
        for (int i = 0; i < results.Length; ++i)
        {
            if (results[i].gameObject != gameObject)
                return  true;
        }

        return  false;
    }


private
    bool
    CeilCheck()
    {
        Collider2D[] results = Physics2D.OverlapBoxAll(mCeilingChecker.position, new Vector2(1f, 1f), 0f);
        for (int i = 0; i < results.Length; ++i)
        {
            if (results[i].gameObject != gameObject)
                return  true;
        }

        return  false;
    }

}

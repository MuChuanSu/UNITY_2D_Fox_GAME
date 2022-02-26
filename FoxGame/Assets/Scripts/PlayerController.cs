using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody2D myRigid;
    private float jumpForce = 15f;
    private bool isGrounded;
    private CapsuleCollider2D myCapsule;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myCapsule = GetComponent<CapsuleCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        myRigid.velocity = new Vector2(moveSpeed*Input.GetAxisRaw("Horizontal"), myRigid.velocity.y);

        if (myCapsule.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            canDoubleJump = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (myCapsule.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    myRigid.velocity = new Vector2(myRigid.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
        
        
        
       
    }
}

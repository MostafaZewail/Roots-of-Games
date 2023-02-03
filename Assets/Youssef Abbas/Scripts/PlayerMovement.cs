using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveVertical;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigid;


    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        if (moveVertical > 0.1f || moveVertical < -0.1f)//right and left
        {
            //rigid.AddForce(new Vector3(0f, 0f, moveVertical * speed), ForceMode.Impulse);
            rigid.velocity = new Vector3(0,0,moveVertical * speed );

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RayanBranch
{
    public class Character_Jump : MonoBehaviour
    {

        [SerializeField] Rigidbody myRb;


        [SerializeField] Vector3 jumpDirection;

        [SerializeField] float jumpForce;
        [SerializeField] float jumpDuration;
        [SerializeField] float startTime;
        [SerializeField] bool jumping;


        private void Start()
        {
            myRb= GetComponentInChildren<Rigidbody>();
        }
        private void Update()
        {

            if (jumping)
            {
                float elapsedTime = Time.time - startTime;
                if (elapsedTime > jumpDuration)
                {
                    jumping = false;
                    return;
                }

                float height = jumpForce * elapsedTime / jumpDuration;
                myRb.AddForce(jumpDirection * height, ForceMode.Force);
            }
        }


        public void Jump()
        {
            if (!jumping)
            {
                startTime = Time.time;
                jumping = true;
                jumpDirection = Vector3.up;
            }
        }


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace RayanBranch
{
    public class Character_Dash : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Rigidbody myRb;
        [SerializeField] float dashSpeed = 10f;
        [SerializeField] float dashDuration = 0.5f;

        [SerializeField] float dashStartTime;
        [SerializeField] bool isDashing;
        [SerializeField] Vector3 dashDirection;

        public Vector3 DashDirection { get => dashDirection; set => dashDirection = value; }

        private void Start()
        {
            myRb = GetComponentInChildren<Rigidbody>();
        }

        private void Update()
        {

            if (isDashing)
            {
                float elapsedTime = Time.time - dashStartTime;
                if (elapsedTime >= dashDuration)
                {
                    isDashing = false;
                    myRb.velocity = Vector3.zero;
                }
                else
                {
                    myRb.AddForce(DashDirection * dashSpeed, ForceMode.Impulse);
                }
            }
        }

        public void Dash(Vector3 DashDirection)
        {
            if (!isDashing)
            {
                dashStartTime = Time.time;
                isDashing = true;
                this.dashDirection = DashDirection;
            }
        }

    }
}
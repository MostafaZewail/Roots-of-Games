using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

namespace RayanBranch
{

    public class Character_Movement : MonoBehaviour
    {

        [SerializeField] Rigidbody myRb;
        [SerializeField] Collider myCol;
        [SerializeField] Transform levelDirection;
        [SerializeField] Character_Dash dash;
        [SerializeField] Character_Jump jump;

        [SerializeField] Vector3 axis,direction, RigidbodyVelocity;

        [SerializeField] float maxVelocity, movementForce;
        [SerializeField] float angleRef;
        [SerializeField] float rotationSmoothTime = 0.1f;


        public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
        public float MovementForce { get => movementForce; set => movementForce = value; }

        // Start is called before the first frame update
        void Start()
        {
            myRb = GetComponentInChildren<Rigidbody>();
            myCol = GetComponentInChildren<Collider>();
            dash= GetComponentInChildren<Character_Dash>();
            jump= GetComponentInChildren<Character_Jump>(); 
            //levelDirection = GameObject.Find("Level Direction").transform;
        }

        private void FixedUpdate()
        {
            MoveCharacterWithDirection();
            RotateCharacterTowardsDirection();
            ClampVelocity(MaxVelocity);

        }

        #region Move using Axis from input to make di

        public void MoveCharacterWithDirection()
        {

            // Transform Direction to the Map direction
            direction = levelDirection.TransformDirection(axis);

            // Adds force to the object, it makes the object mobe
            myRb.AddForce(direction * MovementForce * Time.deltaTime, ForceMode.VelocityChange);


            Debug.DrawLine(transform.position, transform.position + direction * 5, Color.red);
            Debug.DrawLine(transform.position, transform.position + transform.forward * 5, Color.blue);


            RigidbodyVelocity = myRb.velocity;
        }


        public void ClampVelocity(float maxVelocity)
        {
            myRb.velocity = new Vector3(
               Mathf.Clamp(myRb.velocity.x, -maxVelocity, maxVelocity)
             , myRb.velocity.y
             , Mathf.Clamp(myRb.velocity.z, -maxVelocity, maxVelocity));
        }

        #endregion



        #region Rotate to diraction

        private void RotateCharacterTowardsDirection()
        {
            //rotation//
            float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            if (axis != Vector3.zero)
            {
                float rotateToDirection = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                directionAngle, ref angleRef, rotationSmoothTime);
                transform.eulerAngles = Vector3.up * rotateToDirection;
            }

        }
        #endregion









        #region Inputs
        public void OnMove(InputValue value)
        {

            axis = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);

        }

        public void OnDash(InputValue value)
        {
            dash.Dash(direction);
        }

        public void OnJump(InputValue value)
        {
            jump.Jump();
        } 
        #endregion

    }




}

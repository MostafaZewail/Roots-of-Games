using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerGoal"))
        {
            Debug.Log("Player Goal");
        }

        if (collision.gameObject.CompareTag("EnemyGoal"))
        {
            Debug.Log("Enemy Goal");
        }
    }
}

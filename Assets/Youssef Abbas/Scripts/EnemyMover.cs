using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float speed ;
    [SerializeField] private Rigidbody rigid;


    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;

    private void Start()
    {
        this.direction = new Vector3(1f,0f, 1f);
    }

    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 noramal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, noramal);
    }
}

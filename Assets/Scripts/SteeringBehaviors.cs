using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Seek
    }

    public Transform target;
    public float moveSpeed = 4.0f;
    public float rotationSpeed = 1.0f;

    public AIState currentState = AIState.Seek;
    private int minDistance = 60;
    private int safeDistance = 150;
    private Animator _animator;
    private bool inContact;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (currentState)
        {
            case AIState.Idle:
                break;
            case AIState.Seek:
                Seek();
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inContact = true;
    }

    void Seek()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance || inContact)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Arrive()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;
        float decelerationFactor = distance / 5;
        float speed = moveSpeed * decelerationFactor;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime);
        Vector3 moveVector = direction.normalized * Time.deltaTime * speed;
        transform.position += moveVector;
    }
}
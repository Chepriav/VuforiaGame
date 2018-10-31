using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    private enum AIState
    {
        Idle,
        Seek,
        Flee,
        Arrive,
        Pursuit,
        Evade
    }

    public Transform target;
    public float moveSpeed = 4.0f;
    public float rotationSpeed = 1.0f;

    private AIState currentState = AIState.Seek;
    private int minDistance = 60;
    private int safeDistance = 150;
    private Animator _animator;

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
            case AIState.Flee:
                Flee();
                break;
            case AIState.Arrive:
                Arrive();
                break;
        }
    }


    private void OnGUI()
    {
        if (GUILayout.Button("Idle"))
            currentState = AIState.Idle;

        if (GUILayout.Button("Seek"))
            currentState = AIState.Seek;
    }

    void Seek()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Flee()
    {
        Vector3 direction = transform.position - target.position;
        direction.y = 0;
        if (direction.magnitude < safeDistance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                rotationSpeed * Time.deltaTime);
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
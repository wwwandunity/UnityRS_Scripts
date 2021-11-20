using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float platformSpeed = 2f;
    private bool isRunning = false;
    public float distance = 60.0f;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float startPosition;
    private float endPosition;
    private Transform oldParent;

    void Start()
    {
        endPosition = transform.position.z + distance;
        startPosition = transform.position.z;
    }

    void FixedUpdate()
    {
        if (isRunningForward && transform.position.z >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.z <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * platformSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;
            if (transform.position.z >= endPosition)
            {
                isRunningBackward = true;
                isRunningForward = false;
                platformSpeed = -platformSpeed;
            }
            else if (transform.position.z <= startPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                platformSpeed = Mathf.Abs(platformSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z >= endPosition)
            {
                isRunningBackward = true;
                isRunningForward = false;
                platformSpeed = -platformSpeed;
            }
            else if (transform.position.z <= startPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                platformSpeed = Mathf.Abs(platformSpeed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
 

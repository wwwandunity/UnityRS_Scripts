using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public float doorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 5.0f;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float startPosition;
    private float endPosition;

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
            Vector3 move = transform.forward * doorSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunningForward = true;
            isRunningBackward = false;
            doorSpeed = Mathf.Abs(doorSpeed);

            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunningBackward = true;
            isRunningForward = false;
            doorSpeed = -doorSpeed;

            isRunning = true;
        }
    }
}

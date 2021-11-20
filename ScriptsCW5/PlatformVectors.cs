using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVectors : MonoBehaviour
{
    public float platformSpeed = 2f;
    public List<Vector3> vectorList = new List<Vector3>();
    private int vectorIndex = 0;
    private bool isMovingForward = true;
    private Vector3 currentPosition;
    private float distance;
    private Vector3 startPosition;
    private Vector3 moveVector;

    void Start()
    {
        currentPosition = transform.position;
        startPosition = transform.position;
        distance = Vector3.Distance(transform.position, vectorList[vectorIndex]);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentPosition) >= distance)
        {
            if (vectorIndex == 0 && isMovingForward == false)
            {
                isMovingForward = true;
                platformSpeed = -platformSpeed;
                vectorIndex -= 1;
            }
                
            if (vectorIndex >= vectorList.Count - 1 && isMovingForward)
            {
                isMovingForward = false;
                platformSpeed = -platformSpeed;
                vectorIndex += 1;
            }

            if (isMovingForward)
                vectorIndex += 1;
            else
                vectorIndex -= 1;

            currentPosition = transform.position;
            distance = Vector3.Distance(startPosition, vectorList[vectorIndex]);
        }

        Move();
    }

    private void Move()
    {
        moveVector = vectorList[vectorIndex] * platformSpeed * Time.deltaTime;
        transform.Translate(moveVector);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    // Speed value has to be greater than 0
    // Object is able to move forward or backward
    public float speed;
    private bool isMovingForward = true;
    private float start_x_position;

    void Start()
    {
        speed = 2.0f;
        start_x_position = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        isMovingForward = ChangeDirectionIfObjectGoesOutOfTrack(start_x_position, transform.position.x, isMovingForward);
        MoveObjectInGivenDirection(isMovingForward);
    }

    bool ChangeDirectionIfObjectGoesOutOfTrack(float start_x_position, float currentPosition, bool currentDirection)
    {
        if (currentPosition <= start_x_position)
            return true;
        if (currentPosition >= start_x_position + 10)
            return false;

        return currentDirection;
    }

    void MoveObjectInGivenDirection(bool isMovingForward)
    {
        if (isMovingForward == true)
            transform.Translate(Time.deltaTime * speed, 0, 0);
        else
            transform.Translate(Time.deltaTime * speed * -1, 0, 0);
    }
}

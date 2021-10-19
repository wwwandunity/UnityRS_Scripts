using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    // Speed value has to be greater than 0
    // Direction options: right, up, left, down
    // Object moves on the X and Y axes
    public float speed;
    private float start_x_position;
    private float start_y_position;
    private string direction;

    void Start()
    {
        speed = 2.0f;
        start_x_position = transform.position.x;
        start_y_position = transform.position.y;
        transform.Rotate(0.0f, 0.0f, -90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = ChangeDirectionAndRotateIfObjectGoesOutOfTrack(start_x_position, start_y_position, transform.position.x, transform.position.y, direction);
        MoveObjectInGivenDirection(direction);
    }

    string ChangeDirectionAndRotateIfObjectGoesOutOfTrack(float start_x_position, float start_y_position, float current_x_position, float current_y_position, string currentDirection)
    {
        string newDirection = currentDirection;

        if (current_x_position <= start_x_position & current_y_position <= start_y_position)
            newDirection = "right";
        if (current_x_position >= start_x_position + 10 & current_y_position <= start_y_position)
            newDirection = "up";
        if (current_x_position >= start_x_position + 10 & current_y_position >= start_y_position + 10)
            newDirection = "left";
        if (current_x_position <= start_x_position & current_y_position >= start_y_position + 10)
            newDirection = "down";

        if (newDirection != currentDirection)
            transform.Rotate(0.0f, 0.0f, 90.0f);

        return newDirection;
    }

    void MoveObjectInGivenDirection(string direction)
    {
        if (direction == "right")
            transform.Translate(Time.deltaTime * speed, 0, 0, Space.World);
        if (direction == "up")
            transform.Translate(0, Time.deltaTime * speed, 0, Space.World);
        if (direction == "left")
            transform.Translate(Time.deltaTime * speed * -1, 0, 0, Space.World);
        if (direction == "down")
            transform.Translate(0, Time.deltaTime * speed * -1, 0, Space.World);
    }
}

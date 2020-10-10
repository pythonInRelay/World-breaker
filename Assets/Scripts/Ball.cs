using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float ballVelocityX = 1f;
    [SerializeField] private float ballVelocityY = 10f;
    
    // State - Store distance between ball and paddle
    Vector2 _paddleToBallVector;
    private bool _hasStarted;  // Default value is false, so no need to assign as 'false'
    private Rigidbody2D _rigidBody2D;

    void Start()
    {    // Set _rigidBody2D variable at start (less exhaustive)
        _rigidBody2D = GetComponent<Rigidbody2D>();
        // ball's location is the ball minus the paddle
        _paddleToBallVector = transform.position - paddle1.transform.position;
    }
    
    void Update()
    {
        // Lock needs to be in update because each frame we're checking for a mouse click action
        if (_hasStarted) return;
        LockBallToPaddle();
        LaunchOnMouseClick();  // Same for this script
        _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * ballVelocityY;
    }

    private void LaunchOnMouseClick()
    {  // If mouseclick is detected
        if (Input.GetMouseButtonDown(0)) // Set the ball's rigidbody velocity to 10 to ballVelocityY (aka launch it)
            _hasStarted = true;  // Prevent ball from being locked after release
        { _rigidBody2D.velocity = new Vector2(ballVelocityX, ballVelocityY);}
    }

    private void LockBallToPaddle()
    {
        // each frame update paddlePos Vector2 with new paddle transform position of x and y coord
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        // transform.position of the ball now equals paddle position + the remaining paddleToBallVector
        transform.position = paddlePos + _paddleToBallVector;
    }
}

// obviously because the paddle follows the mouse as defined in the other file
// the ball will follow the paddle that is moved with the mouse
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;
    
    // State - Store distance between ball and paddle
    Vector2 _paddleToBallVector;
    
    void Start()
    {  // ball's location is the ball minus the paddle
        _paddleToBallVector = transform.position - paddle1.transform.position;  
    }
    
    void Update()
    {  // each frame update paddlePos Vector2 with new paddle transform position of x and y coord
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); 
        // transform.position of the ball now equals paddle position + the remaining paddleToBallVector
        transform.position = paddlePos + _paddleToBallVector;
    }
}

// obviously because the paddle follows the mouse as defined in the other file
// the ball will follow the paddle that is moved with the mouse
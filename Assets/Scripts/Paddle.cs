using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    private void Update()
    {
        var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);  // for the paddle pos on x-axis
                                                                 // do not go any higher or lower
                                                                 // than the game window width
        transform.position = paddlePos;
    }
}

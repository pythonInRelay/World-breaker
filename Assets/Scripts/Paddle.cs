using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    
    private void Update()
    {
        var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var transform1 = transform;
        var paddlePos = new Vector2(mousePosInUnits, transform1.position.y);
        transform1.position = paddlePos;
    }
}

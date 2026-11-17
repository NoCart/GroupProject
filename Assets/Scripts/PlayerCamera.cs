using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float yDistThreshold = 1.0f;
    public float yOffset = 3.0f;
    public float minY = 0.0f;
    private float targetY;

    void Start()
    {
        targetY = playerTransform.position.y + transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            playerTransform.position.x, 
            Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * 3.0f), 
            -10
        );

      
        if ( Mathf.Abs(playerTransform.position.y - yOffset - transform.position.y ) > yDistThreshold)
        {
            targetY = playerTransform.position.y + yOffset;
            if (targetY < minY)
            {
                targetY = minY;
            }
        }
    }
}

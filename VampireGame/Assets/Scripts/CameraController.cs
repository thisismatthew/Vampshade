using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // so i want a camera controller where the player can move around a bit without the camera moving,
    // like get to the edges and then the camera lerps over a bit. 

    public const float MAX_DISTANCE = 3f;

    public Transform target; // Specify the player
    public float speed = 1f;

    // the camera will move if projctedPos and currentPos are not equal, projectedPos gets moved relative
    // to the distance of the player from the currentPos. 
    public Vector2 currentPos;
    public Vector2 projectedPos;

    void Start()
    {
        currentPos = transform.position;
        projectedPos = target.position;
    }

    void LateUpdate()
    {
        if (currentPos != projectedPos)
        {
            Vector3 newPos = Vector2.Lerp(currentPos, projectedPos, Time.deltaTime * speed);
            newPos.z = -10;
            transform.position = newPos;
            currentPos = transform.position;
        }

        if (Vector2.Distance(currentPos, target.transform.position) > MAX_DISTANCE)
        {
            projectedPos = target.transform.position;
            //this line is just to offset the pivot being at the players feet
            projectedPos.y += 5f;
            
        }


    }
}

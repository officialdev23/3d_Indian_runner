using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform platform;
    public Transform startPosition;
    public Transform endPosition;
    public float speed = 1f;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.Lerp(platform.position, target, speed*Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.1)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return startPosition.position;
        }
        else
        {
            return endPosition.position;
        }
    }
    private void OnDrawGizmos()
    {
        if(platform != null && startPosition != null && endPosition != null)
        {
            Gizmos.DrawLine(platform.transform.position,startPosition.position);
            Gizmos.DrawLine(platform.transform.position,endPosition.position);
        }
    }
}

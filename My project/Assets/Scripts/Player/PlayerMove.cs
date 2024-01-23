//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMove : MonoBehaviour
//{
//    public float moveSpeed = 5;
//    public float leftRightSpeed = 4;
//    static public bool canMove = false;
//    public bool isJumping = false;
//    public bool comingDown = false;
//    public GameObject playerObject;

//    void Update()
//    {
//        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
//        if (canMove == true)
//        {
//            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
//            {
//                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
//                {
//                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
//                }
//            }
//            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
//            {
//                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
//                {
//                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
//                }
//            }
//            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
//            {
//                if(isJumping == false)
//                {
//                    isJumping = true;
//                    playerObject.GetComponent<Animator>().Play("Jump");
//                    StartCoroutine(JumpSequence());
//                }
//            }
//        }

//        if(isJumping == true)
//        {
//            if(comingDown == false)
//            {
//                transform.Translate(Vector3.up* Time.deltaTime * 3, Space.World);
//            }
//            if (comingDown == true)
//            {
//                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
//            }
//        }
//    }

//    IEnumerator JumpSequence()
//    {
//        yield return new WaitForSeconds(0.45f);
//        comingDown = true;
//        yield return new WaitForSeconds(0.45f);
//        isJumping = false;
//        comingDown = false;
//        playerObject.GetComponent<Animator>().Play("Standard Run");
//    }
//}

using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    private Vector2 touchStartPos;
    private bool isSwiping = false;

    void Update()
    {
        // Swipe detection
        DetectSwipe();

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (canMove)
        {
            // Left and Right Movement
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }

            // Swipe Up or Press Space for Jump
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
        }

        // Jumping Logic
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
    }

    void DetectSwipe()
    {
        foreach (var touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    float swipeDelta = touch.position.x - touchStartPos.x;

                    if (isSwiping)
                    {
                        // Swipe Left
                        if (swipeDelta < 0 && Mathf.Abs(swipeDelta) > Screen.width * 0.1f)
                        {
                            // Add logic for left swipe
                        }
                        // Swipe Right
                        else if (swipeDelta > 0 && swipeDelta > Screen.width * 0.1f)
                        {
                            // Add logic for right swipe
                        }
                        // Swipe Up
                        else if (touch.position.y - touchStartPos.y > Screen.height * 0.1f)
                        {
                            // Add logic for up swipe
                        }
                    }

                    isSwiping = false;
                    break;
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public float maxTime;
    public float minSwipeDistance;
    float startTime;
    float endTime;

    float swipeDistance;
    float swipeTime;

    Vector3 startPos;
    Vector3 endPos;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;

            }else if(touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;
                if(swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    Swipe();
                }
            }
        }
    }
    void Swipe()
    {

        Vector2 distance = endPos - startPos;
        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y)){
            Debug.Log("Horizontal Swipe");
            if(distance.x > 0)
            {
                Debug.Log("Right Swipe");
            }
            if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y)){
            Debug.Log("Vertical Swipe");
            if (distance.y > 0)
            {
                Debug.Log("Up Swipe");
                player.GetComponent<PlayerMove>().Jump();
            }
            if (distance.y < 0)
            {
                Debug.Log("Down Swipe");
            }
        }
    }
}

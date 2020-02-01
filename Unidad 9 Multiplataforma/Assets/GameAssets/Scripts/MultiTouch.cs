using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    public List<GameObject> balls = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < myTouches.Length; i++) {
                if (i < balls.Count) {
                    balls[i].transform.position = myTouches[i].position;
                }
            }
        }

    }
}

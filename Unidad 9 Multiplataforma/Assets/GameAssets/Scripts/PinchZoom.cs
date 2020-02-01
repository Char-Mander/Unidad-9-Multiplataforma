using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    float iniDist =0;
    Vector3 iniScale;

    bool init = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2)
            {
                float zoomdist;

                if (!init)
                {
                    init = true;
                    iniDist = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    iniScale = this.transform.localScale;
                }

                zoomdist = Vector2.Distance(Input.touches[0].position, Input.touches[1].position) - iniDist;
                Vector3 newScale = new Vector3(iniScale.x + zoomdist / 100, iniScale.y + zoomdist / 100, iniScale.z + zoomdist / 100);
                this.transform.localScale = newScale;
               
            }
        }
        else {
            init = false;
        }

    }
}

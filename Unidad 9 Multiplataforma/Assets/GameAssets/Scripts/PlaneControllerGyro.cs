using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllerGyro : MonoBehaviour
{
    public float rotationSpeed =10;

    public float pitch;
    public float yaw;
    public float rol;

    // Update is called once per frame
    void Update()
    {
        pitch = Input.acceleration.y;
        rol = Input.acceleration.z;
        yaw = Input.acceleration.x;

        //float rotaX = this.transform.rotation.eulerAngles.x;

        Vector3 eulerVector = new Vector3(pitch,yaw,0);

        this.transform.Rotate(eulerVector * rotationSpeed  * Time.deltaTime);

    }
}

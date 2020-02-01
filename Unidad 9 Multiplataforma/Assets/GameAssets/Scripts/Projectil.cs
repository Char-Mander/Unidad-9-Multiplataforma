using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float maxDistance = 3;
    public float fate = 8;
    public Transform slingShot;
    public LineRenderer lineFront;
    public LineRenderer lineBack;

    SpringJoint2D springJ;
    Rigidbody2D rigi;
    Ray rayToMouse;
    Ray rayToSlingShot;
    bool isClicked = false;
    Vector2 prevVel;
    float circleRadio;
    bool isLauched = false;

    // Start is called before the first frame update
    void Start()
    {
        springJ = GetComponent<SpringJoint2D>();
        rigi = GetComponent<Rigidbody2D>();
        rayToMouse = new Ray(slingShot.position, Vector3.zero);
        rayToSlingShot = new Ray(slingShot.position, Vector3.zero);
        CreateSlingshotRubber();
        circleRadio = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            Dragging();
        }

        if (springJ != null)
        {
            if (!rigi.isKinematic && prevVel.magnitude > rigi.velocity.magnitude)
            {
                Destroy(springJ);
                rigi.velocity = prevVel;
                isLauched = true;
                Destroy(this.gameObject, fate);
            }

            if (!isClicked)
            {
                prevVel = rigi.velocity;
            }

            UpdateslingShotRubber();
        } else {
            lineFront.enabled = false;
            lineBack.enabled = false;
        }

    }

    void UpdateslingShotRubber() {
        Vector2 SlingShotToProjectil = transform.position - slingShot.position;
        rayToSlingShot.direction = SlingShotToProjectil;
        Vector3 projectilPoint = rayToSlingShot.GetPoint(SlingShotToProjectil.magnitude + circleRadio);
        lineFront.SetPosition(1, projectilPoint);
        lineBack.SetPosition(1, projectilPoint);
    }    

    void CreateSlingshotRubber() {
        lineFront.SetPosition(0, lineFront.transform.position);
        lineBack.SetPosition(0, lineBack.transform.position);
        lineFront.sortingOrder = 4;
        lineBack.sortingOrder = 2;
    }

    void Dragging() {
        Vector3 mouseWorldPosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 slingShotToMouse = mouseWorldPosi - slingShot.position;

        if (slingShotToMouse.magnitude > maxDistance) {
            rayToMouse.direction = slingShotToMouse;
            mouseWorldPosi = rayToMouse.GetPoint(maxDistance);
        }

        mouseWorldPosi.z = 0;
        transform.position = mouseWorldPosi;
    }

    private void OnMouseDown()
    {
        if (!isLauched) {
            isClicked = true;
            springJ.enabled = false;
        }
    }

    private void OnMouseUp()
    {
        if (!isLauched)
        {
            isClicked = false;
            springJ.enabled = true;
            rigi.isKinematic = false;
        }
    }

    public void initProjectil(Transform sling, LineRenderer lf, LineRenderer lb) {
        slingShot = sling;
        lineFront = lf;
        lineBack = lb;
        GetComponent<SpringJoint2D>().connectedBody = sling.GetComponent<Rigidbody2D>();
        lineFront.enabled = true;
        lineBack.enabled = true;
    }

}

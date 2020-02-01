using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxProjectil;
    private int actualProjectil;

    public GameObject SligShot;
    public LineRenderer lineFront;
    public LineRenderer lineBack;

    public GameObject projectilPref;
    public Transform posidisp;

    bool canShoot = true;
    GameObject projectilClone;
    // Start is called before the first frame update
    void Start()
    {
        actualProjectil = maxProjectil;
        LoadProjectil();
    }

    void LoadProjectil() {
        projectilClone = Instantiate(projectilPref, posidisp.position, Quaternion.identity);
        projectilClone.GetComponent<Projectil>().initProjectil(SligShot.transform, lineFront, lineBack);
    }

    // Update is called once per frame
    void Update()
    {
        if (projectilClone == null) {
            actualProjectil--;
            if (actualProjectil > 0)
            {
                LoadProjectil();
            }
            else {
                print("GameOver");
            }
            
        }
    }
}

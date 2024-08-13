using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksSeed : MonoBehaviour
{
    // ‰Ô‰Î‚ğ¶¬‚·‚é‚½‚ß‚ÌƒNƒ‰ƒX
    // ‹…‚¶‚á‚È‚­‚Ä–Ê‚É‚·‚é
    private Transform myTransform = null;
    const int devideNumber = 4; //•ªŠ„”C1‚Å4•ûŒü
    Vector3 Position = new Vector3(-100.0f, 40.0f, 110.0f);
    public GameObject kayaku;

    void Start()
    {
        myTransform = this.gameObject.transform;
        LaunchFireWorks();
    }

    void LaunchFireWorks()
    {
        int i;
        int j;
        Vector3 Velocity = new Vector3(0.0f, 1.0f, 0.0f);
        for (i = 0; i < devideNumber; i++)
        {
            GameObject g = null;
            FireWorks fireWorksIns = null;
            //4ŒÂ‚Ã‚Â¶¬‚µ‚Ä‚¢‚­
            for (j = 0; j < 4; j++)
            {
                g = Instantiate(kayaku, Position, Quaternion.identity, myTransform);
                g.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                fireWorksIns = g.GetComponent<FireWorks>();
                fireWorksIns.SetSpeed(Velocity.x, Velocity.y, Velocity.z);
                Velocity = Quaternion.Euler(0, 0, 90) * Velocity;
            }
            Velocity = Quaternion.Euler(0, 0, 90 / devideNumber) * Velocity;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LaunchFireWorks();
        }
    }
}

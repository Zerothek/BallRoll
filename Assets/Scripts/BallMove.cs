using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private Rigidbody rigid;

    private float tiltX, tiltY;
    private float moveX, moveY;
    private float speed = 13;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 tilt = Input.acceleration;

        tiltX = 3 * Input.acceleration.x;
        tiltY = 3 * Input.acceleration.y;

        tilt = Quaternion.Euler(90, 0, 0) * tilt;


        float smooth = speed * Time.deltaTime * 20;

        if (transform.position.y < -40)
        {
            //transform.Translate(-transform.position.x, -transform.position.y + 5, -transform.position.z, Space.World);
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {

            //When tilting the phone sideways
            if (Mathf.Abs(tiltX) > 0.1)
            {
                Vector3 Xaxis = new Vector3(0, 1, 0);
                moveX = tiltX * speed * Time.deltaTime;
                transform.Translate(moveX, 0, 0, Space.World);
                transform.Rotate(Xaxis * smooth * tiltX, Space.World);
            }

            //When tilting the phone top and bottom
            if (Mathf.Abs(tiltY) > 0.1)
            {
                moveY = tiltY * speed * Time.deltaTime;
                transform.Translate(0, 0, moveY, Space.World);
                Vector3 Yaxis = new Vector3(1, 0, 0);
                transform.Rotate(-Yaxis * smooth * tiltY, Space.World);
            }
        }
    }
}

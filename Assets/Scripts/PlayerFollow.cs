using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform BallTranform;

    private Vector3 cameraOffset = new Vector3(0, 10, -15);

    private float SmoothFactor = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = BallTranform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        transform.LookAt(BallTranform);
    }
}

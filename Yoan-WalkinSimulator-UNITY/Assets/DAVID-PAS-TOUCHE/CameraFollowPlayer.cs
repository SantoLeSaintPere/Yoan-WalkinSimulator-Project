using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    PlayerInputReader inputReader;

    [HideInInspector]
    public float lookX,lookY;

    public float speed;
    public float turnSpeed;
    public float limitUp = 30, limitDown = 30;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        inputReader = target.GetComponent<PlayerInputReader>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Rotation();

    }

    private void Rotation()
    {
        lookX  += inputReader.lookX * turnSpeed;
        lookY += inputReader.lookY * turnSpeed;

        lookY = Mathf.Clamp(lookY, -limitUp, limitDown);

        transform.rotation = Quaternion.Euler(-lookY, lookX, 0);
        target.rotation = Quaternion.Euler(0, lookX,0);
    }

    void Follow()
    {

        Vector3 pos = transform.position;
        Vector3 desiredPos = target.position;

        transform.position = Vector3.MoveTowards(pos, desiredPos, speed * Time.deltaTime);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputReader inputReader;
    CharacterController characterController;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = inputReader.move.x;
        float z = inputReader.move.y;

        Vector3 dir = new Vector3(x, 0, z);
        dir = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * dir;
        dir.Normalize();
        characterController.Move(dir * speed * Time.deltaTime);
    }
}

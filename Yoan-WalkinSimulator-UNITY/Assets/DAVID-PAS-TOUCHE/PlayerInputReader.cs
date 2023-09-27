using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInputControls inputControls;

    public Vector2 move;
    public bool isMoving;

    public float lookX, lookY;

    private void OnEnable()
    {
        inputControls.Player.Enable();
    }

    private void OnDisable()
    {
        inputControls.Player.Disable();
    }

    private void Awake()
    {
        inputControls = new PlayerInputControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = inputControls.Player.Move.ReadValue<Vector2>();
        isMoving = move.x != 0 || move.y != 0;

        lookX = inputControls.Player.LookX.ReadValue<float>();
        lookY = inputControls.Player.LookY.ReadValue<float>();
    }
}

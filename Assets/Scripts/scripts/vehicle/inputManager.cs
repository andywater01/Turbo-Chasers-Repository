
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour{

    DriverControls controls;

    public float vertical;
    public float horizontal;
    public bool handbrake;
    public bool boosting;

    public float GasAmountF;
    public float GasAmountB;

    public bool controlsEnabled = false;

    private void Awake()
    {
        controls = new DriverControls();

        //Gas Forward
        controls.Gameplay.DriveForward.performed += ctx => GasAmountF = ctx.ReadValue<float>();
        controls.Gameplay.DriveForward.canceled += ctx => GasAmountF = 0.0f;

        //Gas Backward
        controls.Gameplay.DriveBackward.performed += ctx => GasAmountB = ctx.ReadValue<float>();
        controls.Gameplay.DriveBackward.canceled += ctx => GasAmountB = 0.0f;
    }


    void Update()
    {
        keyboard();
        //controller();

        if (controlsEnabled == true)
        {
            //Gas Forward
            controls.Gameplay.DriveForward.performed += ctx => GasAmountF = ctx.ReadValue<float>();
            controls.Gameplay.DriveForward.canceled += ctx => GasAmountF = 0.0f;

            //Gas Backward
            controls.Gameplay.DriveBackward.performed += ctx => GasAmountB = ctx.ReadValue<float>();
            controls.Gameplay.DriveBackward.canceled += ctx => GasAmountB = 0.0f;
        }
    }

    public void keyboard () {
        vertical = Input.GetAxis ("Vertical");
        horizontal = Input.GetAxis ("Horizontal");
        handbrake = (Input.GetAxis ("Jump") != 0) ? true : false;
        if (Input.GetKey (KeyCode.LeftShift)) boosting = true;
        else boosting = false;

    }

    public void controller()
    {
        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0) ? true : false;
        //if (Input.GetKey(KeyCode.LeftShift)) boosting = true;
        //else boosting = false;
        

    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
        controlsEnabled = true;
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
        controlsEnabled = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CarMovement : MonoBehaviour
{

    DriverControls controls;
    private Rigidbody rb;

    [SerializeField]
    private float ForwardAcceleration;

    [SerializeField]
    private float BackwardAcceleration;

    float GasAmountF;
    float GasAmountB;

    public GameObject LeftFrontWheel;

    Vector2 SteerAngle;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        controls = new DriverControls();

        //Gas Forward
        controls.Gameplay.DriveForward.performed += ctx => GasAmountF = ctx.ReadValue<float>();
        controls.Gameplay.DriveForward.canceled += ctx => GasAmountF = 0.0f;

        //Gas Backward
        controls.Gameplay.DriveBackward.performed += ctx => GasAmountB = ctx.ReadValue<float>();
        controls.Gameplay.DriveBackward.canceled += ctx => GasAmountB = 0.0f;

        //Get Turn
        controls.Gameplay.Steer.performed += ctx => SteerAngle = ctx.ReadValue<Vector2>();
        controls.Gameplay.Steer.canceled += ctx => SteerAngle = Vector2.zero;
    }


    private void FixedUpdate()
    {
        //Driving Forward
        Vector3 SteerA = new Vector3(SteerAngle.x, 0.0f, SteerAngle.y) * 100 * Time.deltaTime;
        Debug.Log(SteerA);

        float gasFor = GasAmountF * ForwardAcceleration * Time.deltaTime;
        rb.AddForce(SteerA * gasFor, ForceMode.Acceleration);

        //Driving Backward
        float gasBack = GasAmountB * BackwardAcceleration * Time.deltaTime;
        rb.AddForce(-SteerA * gasBack, ForceMode.Acceleration);


        //SetCarRotation
        LeftFrontWheel.transform.eulerAngles = new Vector3(0.0f, SteerAngle.y, 0.0f);
    }



    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

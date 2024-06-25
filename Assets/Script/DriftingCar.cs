using UnityEngine;

public class DriftingCar : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    private WheelFrictionCurve frontLeftFriction;
    private WheelFrictionCurve frontRightFriction;
    private WheelFrictionCurve rearLeftFriction;
    private WheelFrictionCurve rearRightFriction;

    private float originalStiffness;
    public float driftStiffness = 0.5f;
    public KeyCode handbrakeKey = KeyCode.Space;

    public float motorForce = 1500f;
    public float maxSteeringAngle = 30f;

    void Start()
    {
        // 저장된 마찰력 값을 초기화합니다.
        frontLeftFriction = frontLeftWheel.sidewaysFriction;
        frontRightFriction = frontRightWheel.sidewaysFriction;
        rearLeftFriction = rearLeftWheel.sidewaysFriction;
        rearRightFriction = rearRightWheel.sidewaysFriction;

        originalStiffness = rearLeftFriction.stiffness;
    }

    void Update()
    {
        if (Input.GetKey(handbrakeKey))
        {
            SetRearTireFriction(driftStiffness);
        }
        else
        {
            SetRearTireFriction(originalStiffness);
        }
    }

    void FixedUpdate()
    {
        float motor = motorForce * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;
    }

    void SetRearTireFriction(float stiffness)
    {
        rearLeftFriction.stiffness = stiffness;
        rearRightFriction.stiffness = stiffness;

        rearLeftWheel.sidewaysFriction = rearLeftFriction;
        rearRightWheel.sidewaysFriction = rearRightFriction;
    }
}

using UnityEngine;

public class DriftingCar : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    private WheelFrictionCurve frontLeftFriction;
    private WheelFrictionCurve frontRightFriction;
    private WheelFrictionCurve rearLeftFriction;
    private WheelFrictionCurve rearRightFriction;

    private float originalStiffness;
    public float driftStiffness = 0.5f;
    public KeyCode handbrakeKey = KeyCode.Space;

    public float motorForce = 1500f;
    public float maxSteeringAngle = 30f;

    private Rigidbody rb;

    void Start()
    {
        // 리지드 바디 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();

        // 저장된 마찰력 값을 초기화합니다.
        frontLeftFriction = frontLeftWheelCollider.sidewaysFriction;
        frontRightFriction = frontRightWheelCollider.sidewaysFriction;
        rearLeftFriction = rearLeftWheelCollider.sidewaysFriction;
        rearRightFriction = rearRightWheelCollider.sidewaysFriction;

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

        // 바퀴 메쉬의 위치와 회전을 업데이트합니다.
        UpdateWheelPoses();
    }

    void FixedUpdate()
    {
        float motor = motorForce * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        frontLeftWheelCollider.steerAngle = steering;
        frontRightWheelCollider.steerAngle = steering;

        rearLeftWheelCollider.motorTorque = motor;
        rearRightWheelCollider.motorTorque = motor;
    }

    void SetRearTireFriction(float stiffness)
    {
        rearLeftFriction.stiffness = stiffness;
        rearRightFriction.stiffness = stiffness;

        rearLeftWheelCollider.sidewaysFriction = rearLeftFriction;
        rearRightWheelCollider.sidewaysFriction = rearRightFriction;
    }

    void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelTransform);
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }
}

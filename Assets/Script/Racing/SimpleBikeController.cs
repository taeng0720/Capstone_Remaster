using UnityEngine;

public class SimpleBikeController : MonoBehaviour
{
    public Transform leftWheel;               // 왼쪽 바퀴 모델
    public Transform rightWheel;              // 오른쪽 바퀴 모델
    public WheelCollider leftWheelCollider;   // 왼쪽 휠 콜라이더
    public WheelCollider rightWheelCollider;  // 오른쪽 휠 콜라이더

    public float motorTorque = 2000f;         // 모터 힘
    public float maxSteerAngle = 30f;         // 최대 조향각
    public float driftFactor = 0.95f;         // 드리프트 계수

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 입력 값 받기
        float motor = motorTorque * Input.GetAxis("Vertical");
        float steering = maxSteerAngle * Input.GetAxis("Horizontal");

        // 모터 힘 적용
        leftWheelCollider.motorTorque = motor;
        rightWheelCollider.motorTorque = motor;

        // 조향 각도 적용
        leftWheelCollider.steerAngle = steering;
        rightWheelCollider.steerAngle = steering;

        // 바퀴 위치와 회전 적용
        ApplyLocalPositionToVisuals(leftWheelCollider, leftWheel);
        ApplyLocalPositionToVisuals(rightWheelCollider, rightWheel);

        // 드리프트 적용
        Drift();
    }

    void ApplyLocalPositionToVisuals(WheelCollider collider, Transform visualWheel)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.position = position;
        visualWheel.rotation = rotation;
    }

    void Drift()
    {
        WheelHit leftWheelHit;
        WheelHit rightWheelHit;
        leftWheelCollider.GetGroundHit(out leftWheelHit);
        rightWheelCollider.GetGroundHit(out rightWheelHit);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            // 드리프트 상태
            leftWheelCollider.sidewaysFriction = new WheelFrictionCurve
            {
                extremumSlip = 0.4f,
                extremumValue = 1f,
                asymptoteSlip = 0.8f,
                asymptoteValue = 0.5f,
                stiffness = driftFactor
            };

            rightWheelCollider.sidewaysFriction = new WheelFrictionCurve
            {
                extremumSlip = 0.4f,
                extremumValue = 1f,
                asymptoteSlip = 0.8f,
                asymptoteValue = 0.5f,
                stiffness = driftFactor
            };
        }
        else
        {
            // 일반 상태
            leftWheelCollider.sidewaysFriction = new WheelFrictionCurve
            {
                extremumSlip = 0.4f,
                extremumValue = 1f,
                asymptoteSlip = 0.8f,
                asymptoteValue = 0.75f,
                stiffness = 1f
            };

            rightWheelCollider.sidewaysFriction = new WheelFrictionCurve
            {
                extremumSlip = 0.4f,
                extremumValue = 1f,
                asymptoteSlip = 0.8f,
                asymptoteValue = 0.75f,
                stiffness = 1f
            };
        }
    }
}

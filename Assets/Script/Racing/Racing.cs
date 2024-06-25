using TMPro;
using UnityEngine;

public class Racing : MonoBehaviour
{
    public int Gear = 0;
    public float Speed = 0;
    public bool Transmission = false;
    public bool isPressedSpace = false;
    public bool canStop = false;

    [SerializeField] private GameObject Tire;

    [SerializeField] private TMP_Text SpeedText;
    [SerializeField] private TMP_Text GearText;
    [SerializeField] private TMP_Text TransmissionText;

    private void FixedUpdate()
    {
        GearControl();
        SpeedControl();
        TireRoll();
    }

    private void GearControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Gear = 1;
            GearText.text = "Gear : " + Gear;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Gear = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Gear = 3;
        }
    }

    private void SpeedControl()
    {
        if (Input.GetKey(KeyCode.R) && !Transmission)
        {
            Transmission = true;
            TransmissionText.text = "Transmission : fast";
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isPressedSpace = true;
            if (canStop) if (Speed > 0) Speed -= 0.25f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressedSpace = false;
        }

        if (!canStop && Speed < 60)
        {
            isPressedSpace = false;
            if (Gear == 1)
            {
                if (Transmission)
                {
                    if (Speed < 40) Speed += 0.25f;
                    else if (Speed > 40) Speed -= 0.25f;
                }
                else
                {
                    if (Speed < 10) Speed += 0.25f;
                    else if (Speed > 10) Speed -= 0.25f;
                }
            }
            else if (Gear == 2)
            {
                if (Transmission)
                {
                    if (Speed < 50) Speed += 0.25f;
                    else if (Speed > 50) Speed -= 0.25f;
                }
                else
                {
                    if (Speed < 20) Speed += 0.25f;
                    else if (Speed > 20) Speed -= 0.25f;
                }
            }
            else if (Gear == 3)
            {
                if (Transmission)
                {
                    if (Speed < 60) Speed += 0.25f;
                    else if (Speed > 60) Speed -= 0.25f;
                }
                else
                {
                    if (Speed < 30) Speed += 0.25f;
                    else if (Speed > 30) Speed -= 0.25f;
                }
            }
        }

        transform.parent.transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
        SpeedText.text = "Speed : " + Speed;
    }

    private void TireRoll()
    {
        Vector3 currentRotation = Tire.transform.rotation.eulerAngles;
        currentRotation.z += Speed / 20;
        Tire.transform.rotation = Quaternion.Euler(currentRotation);
    }
}

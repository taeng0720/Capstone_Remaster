using TMPro;
using UnityEngine;

public class Tutorial_ruddnsrl : MonoBehaviour
{
    public int Gear = 0;
    public float Speed = 0;
    public bool Transmission = false;

    public bool canPressGear1 = false;
    public bool canPressGear2 = false;
    public bool canPressGear3 = false;
    public bool canPressR = false;
    public bool canPressSpace = false;
    public bool isPressedSpace = false;
    public bool canStop = false;

    [SerializeField] private GameObject Tire;
    [SerializeField] private GameObject TutoText;

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && canPressGear1)
        {
            Gear = 1;
            GearText.text = "Gear : " + Gear;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && canPressGear2)
        {
            Gear = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && canPressGear3)
        {
            Gear = 3;
        }
    }

    private void SpeedControl()
    {
        if (Input.GetKey(KeyCode.R) && canPressR && !Transmission)
        {
            Transmission = true;
            TransmissionText.text = "Transmission : fast";
        }

        if (Input.GetKey(KeyCode.Space) && canPressSpace)
        {
            isPressedSpace = true;
            if (canStop) if (Speed > 0) Speed -= 0.25f;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && canPressSpace)
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

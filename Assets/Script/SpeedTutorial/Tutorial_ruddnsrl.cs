using UnityEngine;

public class Tutorial_ruddnsrl : MonoBehaviour
{
    public int Gear = 0;
    private float Speed = 0;
    public bool Transmission = false;

    public bool canPressGear2 = false;
    public bool canPressGear3 = false;
    public bool canPressR = false;

    [SerializeField] private GameObject Tire;

    private void Update()
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
        if (Input.GetKeyDown(KeyCode.R) && canPressR)
        {
            if (Transmission) Transmission = false;
            else Transmission = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Speed > 0) Speed -= 0.25f;
        }
        else if (Gear == 1)
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

        transform.parent.transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }

    private void TireRoll()
    {
        Vector3 currentRotation = Tire.transform.rotation.eulerAngles;
        currentRotation.z += Speed / 20;
        Tire.transform.rotation = Quaternion.Euler(currentRotation);
    }
}

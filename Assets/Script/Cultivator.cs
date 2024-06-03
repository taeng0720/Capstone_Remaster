using UnityEngine;

public class Cultivator : MonoBehaviour
{
    private int Gear = 0;
    private float Speed = 0;
    private bool Transmission = true;
    private int RotateDirection = 0;
    private float RotateSpeed = 0;

    private bool isPressedLeft = false;
    private bool isPressedRight = false;

    private void Update()
    {
        GearControl();
        SpeedControl();
        RotateControl();
    }

    private void GearControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Gear = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) Gear = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) Gear = 3;
    }

    private void SpeedControl()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Transmission) Transmission = false;
            else Transmission = true;
        }

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

        transform.parent.transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }

    private void RotateControl()
    {
        if (isPressedLeft && !isPressedRight) RotateDirection = -1;
        else if (isPressedRight && !isPressedLeft) RotateDirection = 1;
        else RotateDirection = 0;

        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.A)) isPressedLeft = true;
            else isPressedLeft = false;
        }
        else isPressedLeft = false;
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKey(KeyCode.D)) isPressedRight = true;
            else isPressedRight = false;
        }
        else isPressedRight = false;

        if (RotateDirection > 0 && RotateDirection * 15 > RotateSpeed) RotateSpeed += 1.25f;
        else if (RotateDirection < 0 && RotateDirection * 15 < RotateSpeed) RotateSpeed -= 1.25f;
        else if (RotateDirection == 0)
        {
            if (RotateSpeed > 0.2) RotateSpeed -= 1.25f;
            else if (RotateSpeed < -0.2) RotateSpeed += 1.25f;
            else RotateSpeed = 0;
        }

        Quaternion parentRotation = transform.parent.rotation;
        Quaternion newRotation = parentRotation * Quaternion.Euler(0, RotateSpeed, 0);
        transform.rotation = newRotation;

        Vector3 currentRotation = transform.parent.transform.rotation.eulerAngles;
        currentRotation.y += RotateSpeed/15 * Speed/100;
        transform.parent.transform.rotation = Quaternion.Euler(currentRotation);
    }
}

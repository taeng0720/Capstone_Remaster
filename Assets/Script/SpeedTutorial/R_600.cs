using TMPro;
using UnityEngine;

public class R_600 : MonoBehaviour
{
    [SerializeField] private TMP_Text TipText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressR == false)
        {
            collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressR = true;
            TipText.text = "RŰ�� ���� ���� �� ������ �̵�����.";
        }

        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().Transmission == false)
        {
            Vector3 dir = collision.transform.position;
            dir.x -= 10;
            dir.y -= 0.01f;
            collision.transform.position = dir;
        }
        else
        {
            TipText.text = "";
        }
    }
}

using TMPro;
using UnityEngine;

public class Gear3_300 : MonoBehaviour
{
    [SerializeField] private TMP_Text TipText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressGear3 == false)
        {
            collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressGear3 = true;
            TipText.text = "���� 3�� ���� ��ǥ���� ���� ������ �̵�����.";
        }

        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().Gear < 3)
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

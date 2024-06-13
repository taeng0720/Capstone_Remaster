using TMPro;
using UnityEngine;

public class Gear2_150 : MonoBehaviour
{
    [SerializeField] private TMP_Text TipText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressGear2 == false)
        {
            collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().canPressGear2 = true;
            TipText.text = "숫자 2를 눌러 속도를 높이자.";
        }

        if (collision.transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>().Gear < 2)
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

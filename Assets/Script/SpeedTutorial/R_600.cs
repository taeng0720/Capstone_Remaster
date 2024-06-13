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
            TipText.text = "R키를 눌러 더욱 더 빠르게 이동하자.";
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

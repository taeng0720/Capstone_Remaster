using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial_Dialogue : MonoBehaviour
{
    [SerializeField] private float TextSpeed;
    [SerializeField] private RowArray[] Tutorial;
    [SerializeField] private GameObject TextBG;
    [SerializeField] private TMP_Text TutoText;
    [SerializeField] private TMP_Text TipText;
    private int StoryProgress = 0;
    private Tutorial_ruddnsrl Child;

    private void Start()
    {
        Child = transform.GetChild(0).GetComponent<Tutorial_ruddnsrl>();
    }

    private void Update()
    {
        if (Child.Gear == 1 && StoryProgress == 0)
        {
            TipText.text = "";
        }
    }

    public void StartTextTyping()
    {
        Child.canPressGear1 = true;
        TextBG.SetActive(true);
        TipText.text = "\"숫자 1\" 버튼을 누르자.";
        StartCoroutine(TutoTextTyping(StoryProgress));
    }

    IEnumerator TutoTextTyping(int StoryPrg)
    {
        for (int i = 0; i < Tutorial[StoryPrg].row.Length; i++)
        {
            TutoText.text = Tutorial[StoryPrg].row[i];
            yield return new WaitForSeconds(TextSpeed);
        }
        yield return new WaitForSeconds(3f);
        TutoText.text = "";
        yield break;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.name == "100")
        {
            if (Child.canPressGear2 == false)
            {
                Child.canPressGear2 = true;
            }

            if (Child.Gear < 2)
            {
                if (StoryProgress < 1)
                {
                    StoryProgress = 1;
                    Child.canPressGear1 = false;
                    TipText.text = "\"숫자 2\" 버튼을 누르자.";
                    StartCoroutine(TutoTextTyping(StoryProgress));
                }
                Vector3 dir = transform.position;
                dir.x -= 10;
                dir.y -= 0.01f;
                transform.position = dir;
            }
            else
            {
                TipText.text = "";
            }
        }

        if (collision.transform.name == "300")
        {
            if (Child.canPressGear3 == false)
            {
                Child.canPressGear3 = true;
            }

            if (Child.Gear < 3)
            {
                if (StoryProgress < 2)
                {
                    Child.canPressGear2 = false;
                    TipText.text = "\"숫자 3\" 버튼을 누르자.";
                    StoryProgress = 2;
                    StartCoroutine(TutoTextTyping(StoryProgress));
                }
                Vector3 dir = transform.position;
                dir.x -= 10;
                dir.y -= 0.01f;
                transform.position = dir;
            }
            else
            {
                TipText.text = "";
            }
        }

        if (collision.transform.name == "600")
        {
            if (Child.canPressR == false)
            {
                Child.canPressR = true;
            }

            if (Child.Transmission == false)
            {
                if (StoryProgress < 3)
                {
                    TipText.text = "\"R\" 버튼을 누르자.";
                    StoryProgress = 3;
                    StartCoroutine(TutoTextTyping(StoryProgress));
                }
                Vector3 dir = transform.position;
                dir.x -= 10;
                dir.y -= 0.01f;
                transform.position = dir;
            }
            else
            {
                TipText.text = "";
            }
        }
    }
}

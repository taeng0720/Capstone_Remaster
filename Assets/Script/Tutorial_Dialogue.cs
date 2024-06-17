using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial_Dialogue : MonoBehaviour
{
    [SerializeField] private float TextSpeed;
    [SerializeField] private RowArray[] Tutorial;
    [SerializeField] private GameObject TextBG;
    [SerializeField] private GameObject TutorialBG;
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

        if (transform.position.x >= 100 && transform.position.x < 110)
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
                    TipText.text = "\"���� 2\" ��ư�� ������.";
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

        if (transform.position.x >= 300 && transform.position.x < 310)
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
                    TipText.text = "\"���� 3\" ��ư�� ������.";
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

        if (transform.position.x >= 600 && transform.position.x < 610)
        {
            if (Child.canPressR == false)
            {
                Child.canPressR = true;
            }

            if (Child.Transmission == false)
            {
                if (StoryProgress < 3)
                {
                    TipText.text = "\"R\" ��ư�� ������.";
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

        if (transform.position.x >= 925 && transform.position.x < 935)
        {
            if (Child.canPressSpace == false)
            {
                Child.canPressSpace = true;
            }

            if (StoryProgress < 4)
            {
                TipText.text = "\"�����̽���\" ��ư�� ������.";
                StoryProgress = 4;
                StartCoroutine(TutoTextTyping(StoryProgress));
            }
        }

        if (transform.position.x >= 950 && transform.position.x < 960)
        {
            if (Child.isPressedSpace == false)
            {
                Vector3 dir = transform.position;
                dir.x -= 10;
                dir.y -= 0.01f;
                transform.position = dir;
            }
        }
    }

    public void StartTextTyping()
    {
        Child.canPressGear1 = true;
        TutorialBG.SetActive(true);
        TextBG.SetActive(true);
        TipText.text = "\"���� 1\" ��ư�� ������.";
        StartCoroutine(TutoTextTyping(StoryProgress));
    }

    IEnumerator TutoTextTyping(int StoryPrg)
    {
        TextBG.SetActive(true);
        for (int i = 0; i < Tutorial[StoryPrg].row.Length; i++)
        {
            TutoText.text = Tutorial[StoryPrg].row[i];
            yield return new WaitForSeconds(TextSpeed);
        }
        yield return new WaitForSeconds(3f);
        TextBG.SetActive(false);
        yield break;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Image FadeOut;

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

        if (transform.position.x >= 925 && transform.position.x < 935)
        {
            if (Child.canPressSpace == false)
            {
                Child.canPressSpace = true;
            }

            if (StoryProgress < 4)
            {
                TipText.text = "\"스페이스바\" 버튼을 누르자.";
                StoryProgress = 4;
                StartCoroutine(TutoTextTyping(StoryProgress));
            }
        }

        if (transform.position.x >= 1150 && transform.position.x < 1325 && Child.Speed > 0)
        {
            if (Child.isPressedSpace == false)
            {
                FadeOut.CrossFadeAlpha(2f, 1f, true);
                Invoke("SpaceReset", 2f);
            }
            else
            {
                Child.canStop = true;
            }
        }
    }

    private void SpaceReset()
    {
        Child.canStop = false;
        Child.Speed = 60;
        transform.rotation = Quaternion.Euler(0, 90, 0);
        Vector3 dir = transform.position;
        dir.x = 925;
        dir.y = 0;
        transform.position = dir;
        FadeOut.CrossFadeAlpha(-1f, 1f, true);
    }

    public void StartTextTyping()
    {
        Child.canPressGear1 = true;
        TutorialBG.SetActive(true);
        TextBG.SetActive(true);
        TipText.text = "\"숫자 1\" 버튼을 누르자.";
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

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RowArray
{
    public string[] row;
}

public class Story_Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject ruddnsrl;
    [SerializeField] private TMP_Text StoryText;
    [SerializeField] private float TextSpeed;
    [SerializeField] private RowArray[] Story;
    private int StoryProgress = 0;
    private bool canPress = false;

    [SerializeField] private Image FadeOut;
    [SerializeField] private GameObject Cam;

    [SerializeField] private GameObject SkipUI;
    private bool canPressSkip = true;
    private bool Skip = false;

    private void Start()
    {
        Cam.SetActive(false);
        StoryText.text = "";
        Invoke("StoryStart", 1.5f);
    }

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.Return) && !Skip)
        {
            canPress = false;
            StoryText.text = "";

            if (StoryProgress == Story.Length)
            {
                canPressSkip = false;
                Cam.SetActive(true);
                Invoke("DelayFO", 1f);
            }
            else
            {
                StartCoroutine(TextTyping(StoryProgress));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPressSkip)
        {
            if (!Skip)
            {
                Time.timeScale = 0f;
                SkipUI.SetActive(true);
                Skip = true;
            }
            else
            {
                Time.timeScale = 1f;
                SkipUI.SetActive(false);
                Skip = false;
            }
        }
    }

    public void OnClickYes()
    {
        Time.timeScale = 1f;
        StopAllCoroutines();
        canPress = false;
        StoryText.text = "";
        StoryProgress = Story.Length;
        Cam.SetActive(true);
        Invoke("DelayFO", 1f);
        SkipUI.SetActive(false);
        canPressSkip = false;
    }
    public void OnClickNo()
    {
        Time.timeScale = 1f;
        SkipUI.SetActive(false);
        Skip = false;
    }

    private void DelayFO()
    {
        FadeOut.CrossFadeAlpha(0f, 2.5f, true);
        Invoke("StartTutoDialogue", 2.5f);
    }

    private void StartTutoDialogue()
    {
        ruddnsrl.GetComponent<Tutorial_Dialogue>().StartTextTyping();
    }

    private void StoryStart()
    {
        if (canPressSkip) StartCoroutine(TextTyping(StoryProgress));
    }

    IEnumerator TextTyping(int StoryPrg)
    {
        for (int i = 0; i < Story[StoryPrg].row.Length; i++)
        {
            StoryText.text = Story[StoryPrg].row[i];
            yield return new WaitForSeconds(TextSpeed);
        }
        StoryProgress++;
        canPress = true;
        yield break;
    }
}
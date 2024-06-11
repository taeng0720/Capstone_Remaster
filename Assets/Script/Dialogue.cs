using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public class RowArray
{
    public string[] row;
}

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private float TextSpeed;
    [SerializeField] private RowArray[] tutorial;
    private int TutorialProgress = 0;
    private bool canPress = false;

    private void Start()
    {
        StartCoroutine(TextTyping(TutorialProgress));
    }

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.Return))
        {
            canPress = false;
            StartCoroutine(TextTyping(TutorialProgress));
        }
    }

    IEnumerator TextTyping(int Tutorial)
    {
        for (int i = 0; i < tutorial[Tutorial].row.Length; i++)
        {
            tutorialText.text = tutorial[Tutorial].row[i];
            yield return new WaitForSeconds(TextSpeed);
        }
        TutorialProgress++;
        canPress = true;
        yield break;
    }
}
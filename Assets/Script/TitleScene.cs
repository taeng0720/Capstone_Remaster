using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private int tutorial;
    [SerializeField] private GameObject Cover;
    [SerializeField] private GameObject SettingUI;
    [SerializeField] private GameObject ExitUI;

    private void Start()
    {
        if (PlayerPrefs.HasKey("isClear")) tutorial = PlayerPrefs.GetInt("isClear");
        else tutorial = 0;

        if (tutorial == 0)
        {
            Cover.SetActive(true);
        }
    }

    public void OnClickLoadgame()
    {
        ;
    }

    public void OnClickNewgame()
    {
        PlayerPrefs.DeleteAll();
        tutorial = 0;

        SceneManager.LoadScene("tutorial");
    }

    public void OnClickSetting()
    {
        SettingUI.SetActive(true);
    }

    public void OnClickExit()
    {
        ExitUI.SetActive(true);
    }

    public void OnClickExitYes()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnClickExitNo()
    {
        ExitUI.SetActive(false);
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenGitsite(string url)
    {
        Application.OpenURL(url);
    }
}

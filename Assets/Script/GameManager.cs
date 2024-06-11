using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int TutorialProgress;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("isClear")) TutorialProgress = PlayerPrefs.GetInt("isClear");
        else TutorialProgress = 0;
    }
}

using UnityEngine;
using DG.Tweening;

public class Hover : MonoBehaviour
{
    [SerializeField] private float Up;
    [SerializeField] private float Down;

    public void EnterUp()
    {
        transform.DOLocalMoveY(Up, 0.5f);
    }
    public void ExitDown()
    {
        transform.DOLocalMoveY(Down, 0.5f);
    }
}

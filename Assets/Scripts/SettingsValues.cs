using UnityEngine;

public class SettingsValues : MonoBehaviour
{
    public float timePerMove = 60;
    public enum TimerType { timePerMove, timePerPlayer};
    public TimerType timerType = TimerType.timePerMove;
}

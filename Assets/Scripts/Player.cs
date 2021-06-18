using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SettingsValues sv;

    public Text time;
    public Text movesText;

    public GameObject button;
    public GameObject timeUp;

    public Toggle timePerPlayerToggle;

    float remainingTime;
    bool timerIsRunning = false;
    bool moveCounted = false;

    int moves = 0;

    void Start()
    {
        timePerPlayerToggle.isOn = false;
        ResetTimer();
    }

    void Update()
    {

        if (timerIsRunning)
        {
            if (remainingTime > 0)
            {
                button.gameObject.SetActive(true);
                timeUp.SetActive(false);
                remainingTime -= Time.deltaTime;
            }
            else
            {
                button.gameObject.SetActive(false);
                timeUp.SetActive(true);
                timerIsRunning = false;
                remainingTime = 0;
            }
            DisplayTime(remainingTime);
        }
        else
        {

        }

    }


    public void DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        if (hours < 0)
        {
            hours = 0;
        }
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        if (minutes < 0)
        {
            minutes = 0;
        }
        float seconds = Mathf.RoundToInt(timeToDisplay % 60);

        time.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void StartTimer()
    {
        moveCounted = false;
        if(!timePerPlayerToggle.isOn)
        {
            remainingTime = sv.timePerMove;
        }
        timerIsRunning = true;
    }
    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        moves = 0;
        remainingTime = sv.timePerMove;
        timerIsRunning = false;
        DisplayTime(remainingTime);
        DisplayMoves();
        button.gameObject.SetActive(true);
    }

    public void CountMove()
    {
        if (!moveCounted)
        {
            moves++;
            moveCounted = true;
        }
        DisplayMoves();
    }

    public void DisplayMoves()
    {
        movesText.text = "Moves: " + moves.ToString();
    }
}

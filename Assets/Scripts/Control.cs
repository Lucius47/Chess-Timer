using UnityEngine;

public class Control : MonoBehaviour
{
    public Player whitePlayer;
    public Player blackPlayer;
    
    AudioSource timerSound;

    enum CurrentMove
    {
        startingMove,
        whitesMove,
        blacksMove
    }

    CurrentMove cm = CurrentMove.startingMove;

    private void Start()
    {
        timerSound = GetComponent<AudioSource>();

        ResetButtonPressed();
    }

    private void Update()
    {
        whitePlayer.DisplayMoves();
        blackPlayer.DisplayMoves();
    }

    public void WhiteButtonPressed()
    {
        if (cm == CurrentMove.startingMove || cm == CurrentMove.whitesMove)
        {
            if (!(cm == CurrentMove.startingMove))
            {
                whitePlayer.CountMove();
            }

            timerSound.Play();

            whitePlayer.StopTimer();
            blackPlayer.StartTimer();

            cm = CurrentMove.blacksMove;
        }
    }

    public void BlackButtonPressed()
    {
        if (cm == CurrentMove.startingMove || cm == CurrentMove.blacksMove)
        {
            if (!(cm == CurrentMove.startingMove))
            {
                blackPlayer.CountMove();
            }

            timerSound.Play();

            blackPlayer.StopTimer();
            whitePlayer.StartTimer();

            cm = CurrentMove.whitesMove;
        }
        
    }

    public void ResetButtonPressed()
    {
        cm = CurrentMove.startingMove;
        whitePlayer.ResetTimer();
        blackPlayer.ResetTimer();
    }


}


using UnityEngine;


public class Visuals : MonoBehaviour
{
    [SerializeField] Player player;


    void Update()
    {
        if (player.timerIsRunning)
        {
            transform.Rotate(0, 0, 10 * player.remainingTime * Time.deltaTime);
        }
        
        
    }
}

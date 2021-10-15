using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public SettingsValues sv;
    public Control control;

    public InputField timePerMoveInput;
    public GameObject invalidInputErrorText;

    float timePerMoveFloat;

    void Start()
    {
        timePerMoveInput.text = sv.timePerMove.ToString();
    }


    public void PanelOpen()
    {
        this.gameObject.SetActive(true);
    }
    
    public void PanelClose()
    {
        this.gameObject.SetActive(false);
    }

    public void PanelSave()
    {
        if (ValidateInput())
        {
            invalidInputErrorText.SetActive(false);
            sv.timePerMove = timePerMoveFloat;
            control.ResetButtonPressed();
            PanelClose();
        }
        else
        {
            invalidInputErrorText.SetActive(true);
        }
    }



    public bool ValidateInput()
    {
        
        if (float.TryParse(timePerMoveInput.text, out timePerMoveFloat))
        {
            if (timePerMoveFloat > 172800 || timePerMoveFloat < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}

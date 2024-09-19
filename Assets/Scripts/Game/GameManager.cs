using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    AngleSelection,
    PowerSelection,
    WaitResolution
}

public class GameManager : MonoBehaviour
{
    public GameState State;
    public Turret Turret;
    public PowerBar PowerBar;
    
    void Start()
    {
        State = GameState.AngleSelection;
        Turret.StartAngleSelection();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(State)
            {
                case GameState.AngleSelection:
                    Turret.StopAngleSelection();
                    State = GameState.PowerSelection;
                    PowerBar.StartPowerSelection();
                    break;
                case GameState.PowerSelection:
                    PowerBar.StopPowerSelection();
                    State = GameState.WaitResolution;
                    Turret.Shoot(PowerBar.GetPower());
                    StartCoroutine(WaitResolution(5));
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        }
    }

    IEnumerator WaitResolution(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PowerBar.HidePowerBar();
        State = GameState.AngleSelection;
        Turret.StartAngleSelection();
    }
}

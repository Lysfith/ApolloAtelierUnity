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
    public Score Score;
    public GameObject WallPrefab;
    public Transform WallRoot;

    private int _score;
    
    void Start()
    {
        WallPrefab.SetActive(false);
        _score = 0;
        SpawnWalls();
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

    private void SpawnWalls(){
        ClearWalls();
        var wall = Instantiate(WallPrefab);
        wall.transform.SetParent(WallRoot);
        wall.transform.localPosition = Vector3.zero;
        wall.SetActive(true);
    }

    private void ClearWalls(){
        foreach (Transform child in WallRoot.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    IEnumerator WaitResolution(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PowerBar.HidePowerBar();
        SpawnWalls();
        State = GameState.AngleSelection;
        Turret.StartAngleSelection();
    }

    public void AddScore(int score)
    {
        _score += score;
        Score.UpdateScore(_score);
    }
}

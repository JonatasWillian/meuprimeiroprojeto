using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public static GameManager Instance;
    public float timeToSetBallFree = 1f;
    public StateMachine stateMachine;
    public List<Player> players;

    private bool _blocked;

    [Header("Menus")]
    public GameObject uiMainMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void ButtonResetBall()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    public void SetBallFree()
    {
        if (_blocked) return;
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
        _blocked = false;
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        _blocked = true;
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }

}

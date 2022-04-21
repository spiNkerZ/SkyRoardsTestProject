using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverAnimationUI_Module : MonoBehaviour, IGameStart, IGameOver
{
    [SerializeField] Animator animator;
    [SerializeField] Transform gameOverUIRoot;

    void Start() => InterfacesInit();

    void InterfacesInit()
    {
        InterfaceManager.instance.Add_IStartGameInterface(this);
        InterfaceManager.instance.Add_IGameOverInterface(this);
    }

    public void StartGame()
    {
        gameOverUIRoot.gameObject.SetActive(false);
        animator.SetBool("ActiveGameOver", false);
    }
    public void GameOver()
    {
        gameOverUIRoot.gameObject.SetActive(true);
        animator.SetBool("ActiveGameOver", true);
    }
}

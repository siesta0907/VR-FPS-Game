using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStart = false;
    public int playerHp = 100;
    public int monsterDead = 0;
    public int goal = 0;
    private int stageLevel;
    public Text UITxt, LevelTxt;
    public Slider HPSlider;
    public Button StartBtn, NextStageBtn, restartBtn;

    // Start is called before the first frame update
    void Start()
    {
        NextStageBtn.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
        playerHp = 100;
        goal = 10;
        stageLevel = 1;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartGame()
    {
        isStart = true;
        Debug.Log("게임이 시작되었습니다.");
        StartBtn.gameObject.SetActive(false);
    }

    public void GoNextStage()
    {
        stageLevel += 1;
        MonsterManager.instance.moveSpeed += 3;
        MonsterManager.instance.MonsterMaxNum += 5;
        goal += 10;
    }
    public void RestartStage()
    {
        SceneManager.LoadScene("Stage1");
    }

    private void Update()
    {
        HPSlider.value = playerHp;
        UITxt.text = string.Format($"현재 목표 달성: {monsterDead} / {goal}");
        LevelTxt.text = string.Format($"현재 스테이지: {stageLevel}레벨");

        if (monsterDead >= goal)
        {
           // NextStageBtn.gameObject.SetActive(true);
            monsterDead = 0;
            GoNextStage();
        }

        if(playerHp <= 0)
        {
            UITxt.text = "게임 오버 다시 시작하려면 클릭하세요!";
            restartBtn.gameObject.SetActive(true);
        }

    }

}
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
        Debug.Log("������ ���۵Ǿ����ϴ�.");
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
        UITxt.text = string.Format($"���� ��ǥ �޼�: {monsterDead} / {goal}");
        LevelTxt.text = string.Format($"���� ��������: {stageLevel}����");

        if (monsterDead >= goal)
        {
           // NextStageBtn.gameObject.SetActive(true);
            monsterDead = 0;
            GoNextStage();
        }

        if(playerHp <= 0)
        {
            UITxt.text = "���� ���� �ٽ� �����Ϸ��� Ŭ���ϼ���!";
            restartBtn.gameObject.SetActive(true);
        }

    }

}
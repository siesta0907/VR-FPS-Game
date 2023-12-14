using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    private void Start()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public GameObject[] MonPrefabs;
    public Transform[] monsterResapwnPoints;
    public int MonsterMaxNum;
    private int CurrentMonNum;
    public float moveSpeed = 1;

    private void Update()
    {
        CurrentMonNum = GameObject.FindGameObjectsWithTag("Monster").Length;

        if (GameManager.instance.isStart)
        {
            if (CurrentMonNum < MonsterMaxNum)
            {
                Transform MonPos = monsterResapwnPoints[Random.Range(0, monsterResapwnPoints.Length)];
                GameObject Monster = Instantiate(MonPrefabs[Random.Range(0, MonPrefabs.Length)], MonPos);
            }
        }
   

    }


}

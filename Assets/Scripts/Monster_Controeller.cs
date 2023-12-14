using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Controeller : MonoBehaviour
{
    
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 100f);
            
            if(distance > 1f)
            {

                transform.Translate(Vector3.forward * MonsterManager.instance.moveSpeed * Time.deltaTime);

            }
            else
            {
                GameManager.instance.playerHp -= 10;
                Destroy(gameObject);
            }
            
        }
    }
}

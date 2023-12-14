using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private string targetTag = "Monster";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("�Ѿ��� ��ǥ�� �¾ҽ��ϴ�!");
            GameManager.instance.monsterDead += 1;
            Destroy(collision.gameObject);
           
        }
        
    }
}

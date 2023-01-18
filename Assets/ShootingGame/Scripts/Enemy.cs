using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBullet")
        {
            Die();
        }
    }

    void Die()
    {
        //addScore
        gameObject.SetActive(false);
    }
}
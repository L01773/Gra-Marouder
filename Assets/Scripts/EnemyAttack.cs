using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public Slider HpBar;
    public float ValueToAdd;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision started");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            HpBar.value = HpBar.value + ValueToAdd;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Collision ended");
    }
}

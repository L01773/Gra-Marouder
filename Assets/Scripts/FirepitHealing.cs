using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class FirepitHealing : MonoBehaviour
{
    public Slider PlayerHpBar;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision started");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            PlayerHpBar.value = PlayerHpBar.value + 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Collision ended");
    }
}

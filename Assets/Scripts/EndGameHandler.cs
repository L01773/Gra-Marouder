using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameHandler : MonoBehaviour
{
    public Slider HpBar;

    // Start is called before the first frame update
    void Start()
    {
        HpBar.onValueChanged.AddListener(this.EndGame);
    }

    void EndGame(float value)
    {
        if(value <= 0)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject home_page;
    public GameObject options_page;
    public GameObject levelselect_page;

    public Button open_level_1Handler;
    public Button open_level_2Handler;
    public Button open_level_3Handler;

    public Button open_level_selectHandler;
    public Button close_level_selectHandler;

    public Button open_optionsHandler;
    public Button SaveChangesHandler;
    public Button close_optionsHandler;

    public Button exit_gameHandler;

    public Slider SoundHandler;
    public Slider EnemyArmorHandler;
    public Slider EnemySpeedHandler;

    void Start()
    {
        open_level_1Handler.onClick.AddListener(this.OpenLevel1);
        open_level_2Handler.onClick.AddListener(this.OpenLevel2);
        open_level_3Handler.onClick.AddListener(this.OpenLevel3);

        open_level_selectHandler.onClick.AddListener(this.OpenLevels);
        close_level_selectHandler.onClick.AddListener(this.CloseLevels);
        open_optionsHandler.onClick.AddListener(this.OpenOptions);
        close_optionsHandler.onClick.AddListener(this.CloseOptions);

        SaveChangesHandler.onClick.AddListener(this.SaveSettings);

        exit_gameHandler.onClick.AddListener(this.ExitGame);
    }

    public void OpenOptions()
    {
        this.home_page.SetActive(false);
        this.options_page.SetActive(true);
        this.levelselect_page.SetActive(false);
    }

    public void CloseOptions()
    {
        this.home_page.SetActive(true);
        this.options_page.SetActive(false);
        this.levelselect_page.SetActive(false);
    }

    public void OpenLevels()
    {
        this.home_page.SetActive(false);
        this.options_page.SetActive(false);
        this.levelselect_page.SetActive(true);
    }

    public void CloseLevels()
    {
        this.home_page.SetActive(true);
        this.options_page.SetActive(false);
        this.levelselect_page.SetActive(false);
    }

    public void OpenLevel1()
    {
        Debug.Log("should load scene 1");
        SceneManager.LoadScene("Stage_1", LoadSceneMode.Single);
    }

    public void OpenLevel2()
    {
        Debug.Log("should load scene 2");
        SceneManager.LoadScene("Stage_2", LoadSceneMode.Single);
    }

    public void OpenLevel3()
    {
        Debug.Log("should load scene 3");
        SceneManager.LoadScene("Stage_3", LoadSceneMode.Single);
    }

    public void SaveSettings()
    {
        var sound = SoundHandler.value;
        var armor = EnemyArmorHandler.value;
        var speed = EnemySpeedHandler.value;

        string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Marouder");
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Marouder", "user_data.dat");

        if (File.Exists(path))
        {
            File.WriteAllText(path, string.Empty);

            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"sound={sound}");
            writer.WriteLine($"armor={armor}");
            writer.WriteLine($"speed={speed}");
            writer.Close();
        }
        else
        {
            //Directory.CreateDirectory(dir);
            var fs = new FileStream(path, FileMode.Create);
            fs.Dispose();

            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"sound={sound}");
            writer.WriteLine($"armor={armor}");
            writer.WriteLine($"speed={speed}");
            writer.Close();
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
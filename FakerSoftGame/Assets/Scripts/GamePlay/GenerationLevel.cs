using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GenerationLevel : MonoBehaviour {
   /* int level;
    public GameObject levelUI;
    string[] levels = { "Вялый лес", "Дмечуе пески", "Сливная пустыня" };
    public Image background;
    public Image[] level_pointer;
    double forlevel;
    public Text getlevel;


    void TakeInfAboutLevel()
    {
        //Получаем с базы колличество прошедшых уровней в данной области(регионе) по ключу из массива и устанавливаем background
        if (getlevel.text == null) level = 1;
        else
        {
            level = Convert.ToInt32(getlevel.text, 16);
        }
    }

    public void LevelGeneration()
    {
        levelUI.SetActive(true);
        TakeInfAboutLevel();
        forlevel = level % level_pointer.Length;
        for (int i = 0; i < level_pointer.Length; i++)
        {
            if (i > forlevel) level_pointer[i].color = new Color32(96, 96, 96, 255);
            else
            {
                if (i == forlevel) { level_pointer[i].color = new Color32(255, 50, 255, 255); }//+делаем какую то подсветку, нам на этот уровень
                else level_pointer[i].color = new Color32(255, 255, 255, 255);
            }
        }
    }
    */
    public void StartFight()
    {
        SceneManager.LoadScene("clickScene");
    }
}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;

/*
Здесь основніе состояния игры, такие как начало игры конец игры, и контроль времени на уровень
    */
public class GameController : MonoBehaviour
{

    private Vector2 _oldValueOfHealthBar;

    [SerializeField]
    private RectTransform _healthTimeBar;

    [SerializeField]
    private GameObject _timeIsOut;

    [SerializeField]
    private GameObject _retryButton;

    void Start()
    {
        _oldValueOfHealthBar = _healthTimeBar.sizeDelta;
        _timeIsOut.SetActive(false);
        _retryButton.SetActive(false);
        GameTimer.current.setStartTimerValue(30.0f);
        BigMom.ENC.SpawnMonsters();
        GameTimer.current.timerStop = false;
    }
    void Update()
    {
        if (BigMom.ENC.isAllMonstersOnMapDead())
        {
            BigMom.ENC.SpawnMonsters();
        }
        if (BigMom.ENC.isWaveEnd())
        {
            Debug.Log("All dead");
        }
        HealthBarDecrease(GameTimer.current.getTimerValue());
    }


    private void HealthBarDecrease(float value)
    {
        _healthTimeBar.sizeDelta = new Vector2(Mathf.Abs((100.0f*value)/30.0f), _healthTimeBar.sizeDelta.y);
        EndGame();
    }

    public void StartGame()
    {
        //BigMom.ENC.DestroyAllMobs();
        _healthTimeBar.sizeDelta = _oldValueOfHealthBar;
        BigMom.ENC._scoreCounter = 0;
        BigMom.ENC.UpdateScore();
        InvokeRepeating("TimeDecrease", 0, 0.05f);
        _timeIsOut.SetActive(false);
        _retryButton.SetActive(false);
        BigMom.PS.RefreshSpellColdown();
    }


    private void EndGame()
    {
        if (_healthTimeBar.sizeDelta.x <= 0)
        {
            _timeIsOut.SetActive(true);
            _retryButton.SetActive(true);
        }
    }

}

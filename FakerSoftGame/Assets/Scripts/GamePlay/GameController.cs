using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;

public class GameController : MonoBehaviour {

    private Vector2 _oldValueOfHealthBar;

    [SerializeField]
    private RectTransform _healthTimeBar;

    [SerializeField]
    private GameObject _timeIsOut;

    [SerializeField]
    private GameObject _retryButton;


    [HideInInspector]
    public UnityEvent MonsterReadyToBeHealed_E;

    [HideInInspector]
    public UnityEvent MonsterWasKilled_E;

    

    public float standartTimeDecreaseCoeficient = 0.1f;

    public bool TimeIsOutLetsEndThisGame = false;

    void Start()
    {
        _oldValueOfHealthBar = _healthTimeBar.sizeDelta;
        InvokeRepeating("TimeDecrease", 0, 0.1f);
        _timeIsOut.SetActive(false);
        _retryButton.SetActive(false);
    }


    void Update()
    {
   
    }
    private void TimeDecrease()
    {
       // Debug.Log(BigMom.ENC.timeDecreaseCoeficient.ToString());
      //  timeDecreaseCoeficient = 5.0f;
        _healthTimeBar.sizeDelta = new Vector2(_healthTimeBar.sizeDelta.x - BigMom.PP.CalculateTimeDecrease(), _healthTimeBar.sizeDelta.y);
        EndGame();
    }

    public void StartGame()
    {
        BigMom.ENC.DestroyAllMobs();
        _healthTimeBar.sizeDelta = _oldValueOfHealthBar;
        BigMom.ENC._scoreCounter = 0;
        BigMom.ENC.UpdateScore();
        InvokeRepeating("TimeDecrease", 0, 0.05f);
        _timeIsOut.SetActive(false);
        _retryButton.SetActive(false);
        BigMom.ENC.SpawnMonstersAfterDeath();
        BigMom.PS.RefreshSpellColdown();
    }


    private void EndGame()
    {
        if (_healthTimeBar.sizeDelta.x <= 0)
        {
            CancelInvoke("TimeDecrease");

            TimeIsOutLetsEndThisGame = true;
            _timeIsOut.SetActive(true);
            _retryButton.SetActive(true);
            
                
            
        }
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Govnokod_LvL1_button : MonoBehaviour {


    public SpriteRenderer CurentIngicator;
    public SpriteRenderer NextIngicator;

    void  LoadLevel()
        {
        
    }
    void ChangeIndicatorsColour()
        {
        
        CurentIngicator.color = Color.yellow;
        if (NextIngicator != null)
        {
            NextIngicator.color = Color.green;
        }
    }

    void UpdateProgressBar()
    {
        BigMom.GKPB.IncreaseFor1Step();
        BigMom.GKPB.UpdateProgressBarValues();
    }

    void OnMouseDown()
    {
        if (CurentIngicator.color == Color.green)
        {
            UpdateProgressBar();
            ChangeIndicatorsColour();
            
        }
    }
}

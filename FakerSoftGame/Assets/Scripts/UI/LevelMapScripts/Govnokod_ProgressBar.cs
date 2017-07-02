using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Govnokod_ProgressBar : MonoBehaviour {

    public GameObject ProgressBarActivePart;
    private float minValuePosX = -2.67f;
    private float minValueScaleX = 0.0318f;
    private float mainSecretCoeficient = 2.72f;
    private int count_of_levels = 5;
    private float buffer;
    // Use this for initialization
   public void UpdateProgressBarValues ()
    {
        ProgressBarActivePart.transform.localScale = new Vector3(minValueScaleX, ProgressBarActivePart.transform.localScale.y, ProgressBarActivePart.transform.localScale.z);
        ProgressBarActivePart.transform.localPosition = new Vector3(minValuePosX, ProgressBarActivePart.transform.localPosition.y, ProgressBarActivePart.transform.localPosition.z);
        
    }
  public  void IncreaseFor1Step()
    {
        float oneStepPosX = mainSecretCoeficient / count_of_levels;
        float oneStepSceleX = (80 * oneStepPosX) / 100;
        minValuePosX += oneStepPosX;
        minValueScaleX += oneStepSceleX;
}

    void Start () {

        UpdateProgressBarValues();
	}
	
}

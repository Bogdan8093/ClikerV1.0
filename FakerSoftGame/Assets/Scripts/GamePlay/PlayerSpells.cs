using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpells : MonoBehaviour
{

    private float ColdownRageSpell = 15f;
    private float durationRageSpell = 6f;

    private float ColdownSlowPunch = 15f;
    private float durationSlowPunch = 10f;
    private float clicker = 0;
    private float time = 10f;
    private bool spelled = false;
    public GameObject rageSpell;
    public GameObject slowPunch;
    public GameObject slowPunchEffect;



    void Update()
    {

    }

    public void onRageSpellClick()
    {
        BigMom.PP.boostDamage = 3.0f;
        rageSpell.SetActive(false);
        StartCoroutine(WaitForSpellColdownAndEnable(ColdownRageSpell));
        StartCoroutine(WaitForSpellDurationThenOffEffects());
    }
    public void onSlowPunchClick()
    {
        Debug.Log("SPELL2");
        InvokeRepeating("spellTimeOut", 0, 1.0f);
        spelled = true;
        slowPunch.SetActive(false);
        slowPunchEffect.SetActive(true);
        StartCoroutine(WaitForSpellColdownAndEnable(ColdownSlowPunch));
        StartCoroutine(WaitForSlowPunchDone());
    }

    public void RefreshSpellColdown()
    {
        StopCoroutine(WaitForSpellColdownAndEnable(ColdownRageSpell));
        StopCoroutine(WaitForSpellDurationThenOffEffects());
        rageSpell.SetActive(true);
        BigMom.PP.boostDamage = 1.0f;
    }

    private IEnumerator WaitForSpellColdownAndEnable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        rageSpell.SetActive(true);
    }

    private IEnumerator WaitForSpellDurationThenOffEffects()
    {
        yield return new WaitForSeconds(durationRageSpell);
        BigMom.PP.boostDamage = 1.0f;
    }
    private IEnumerator WaitForSlowPunchDone()
    {
        yield return new WaitForSeconds(durationSlowPunch);
        slowPunchEffect.SetActive(false);
        if (clicker >= 20)
            BigMom.ENC.setAllMonstersHP(0.0f);
        else
           BigMom.ENC.setAllMonstersHP(0.5f);
        clicker = 0f;
        spelled = false;
        CancelInvoke();
    }
    void spellTimeOut()
    {
        time--;
        slowPunchEffect.GetComponentInChildren<Text>().text = time.ToString();
        Debug.Log("time");
    }

    public void ClickCounter()
    {
        clicker++;
    }

}

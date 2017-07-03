using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public static class BigMom
{
    

    private static bool _is_initialized = false;
    public static bool IsInitialized
    {
        get
        {
            return _is_initialized;
        }
    }

    //TODO make this fields readonly

    /// <summary>
    /// Enviroment Controller
    /// </summary>
    public static Back BackUIScript;  // тут лучше не задавать лишних вопросов!

    public static HealingMonster HM;

    public static MonstersBasicClass MBC;

    public static EnemyController ENC;

    public static UsualClickerController UCC;

    public static GameController GC;

    public static PlayerParametrs PP;

    public static PlayerSpells PS;
    
    public static PlayerSkillPoints PSP;

    public static DBkey DBkey;

<<<<<<< HEAD
    public static Govnokod_ProgressBar GKPB;

=======
    public static DataBaseFunc DBF;

    public static tempStats TS;

    public static Govnokod_ProgressBar GKPB;
>>>>>>> f36844799a2b8629e7709a0e53bd0f9f74d0a3a9

    public static void Init()
    {
        GKPB = GameObject.FindObjectOfType<Govnokod_ProgressBar>();
        BackUIScript = GameObject.FindObjectOfType<Back>();
        HM = GameObject.FindObjectOfType<HealingMonster>();
        MBC = GameObject.FindObjectOfType<MonstersBasicClass>();
        ENC = GameObject.FindObjectOfType<EnemyController>();
        UCC = GameObject.FindObjectOfType<UsualClickerController>();
        GC = GameObject.FindObjectOfType<GameController>();
        PP = GameObject.FindObjectOfType<PlayerParametrs>();
        PS = GameObject.FindObjectOfType<PlayerSpells>();
        PSP = GameObject.FindObjectOfType<PlayerSkillPoints>();
        DBkey = GameObject.FindObjectOfType<DBkey>();
        DBF = GameObject.FindObjectOfType<DataBaseFunc>();
        TS =  GameObject.FindObjectOfType<tempStats>();
    }

}

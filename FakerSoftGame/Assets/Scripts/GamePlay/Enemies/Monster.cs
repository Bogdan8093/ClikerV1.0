using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
[System.Serializable]
public class Monster
{
    private float defaultHealthPoints = 10.0f;
    private float defaultDamage = 0.1f;
    private float defaultExperience = 1.0f;
    private float defaultGold = 0.1f;
    private float defaultDropChance = 1.0f;
    private float defaultArmor = 1.0f;
    private float defaultMagicResist = 1.0f;

    private float CorrectionHealthPoints = 1.0f;
    private float CorrectionDamage = 1.0f;
    private float CorrectionExperience = 1.0f;
    private float CorrectionGold = 1.0f;
    private float CorrectionDropChanse = 1.0f;
    private float CorrectionArmor = 1.0f;
    private float CorrectionMagicResist = 1.0f;

    public float HealthPoints;
    public float Damage;
    public float Experience;
    public float Gold;
    public float DropChanse;
    public float Armor;
    public float MagicResist;

    public float maxHealthPoints;
    public float maxDamage;
    public float maxExperience;
    public float maxGold;
    public float maxDropChanse;
    public float maxArmor;
    public float maxMagicResist;



    public float Level = 1.0f;
    public string monsterType = "";

    public Monster()
    {
        setLevel(1.0f);
    }

    public class Builder
    {
        private float CorrectionHealthPoints = 1.0f;
        private float CorrectionDamage = 1.0f;
        private float CorrectionExperience = 1.0f;
        private float CorrectionGold = 1.0f;
        private float CorrectionDropChanse = 1.0f;
        private float CorrectionArmor = 1.0f;
        private float CorrectionMagicResist = 1.0f;

        public Builder coefHP(float val)
        {
            CorrectionHealthPoints = val;
            return this;
        }
        public Builder coefDmg(float val)
        {
            CorrectionDamage = val;
            return this;
        }
        public Builder coefXP(float val)
        {
            CorrectionExperience = val;
            return this;
        }
        public Builder coefGold(float val)
        {
            CorrectionGold = val;
            return this;
        }
        public Builder coefDC(float val)
        {
            CorrectionDropChanse = val;
            return this;
        }
        public Builder coefArmor(float val)
        {
            CorrectionArmor = val;
            return this;
        }
        public Builder coefMR(float val)
        {
            CorrectionMagicResist = val;
            return this;
        }
        public Monster build()
        {
            return new Monster
            {
                CorrectionHealthPoints = CorrectionHealthPoints,
                CorrectionDamage = CorrectionDamage,
                CorrectionExperience = CorrectionExperience,
                CorrectionGold = CorrectionGold,
                CorrectionDropChanse = CorrectionDropChanse,
                CorrectionArmor = CorrectionArmor,
                CorrectionMagicResist = CorrectionMagicResist
            };
        }
    }

    public void setLevel(float Level)
    {
        this.Level = Level;
        HealthPoints = defaultHealthPoints * CorrectionHealthPoints * Level;
        Damage = defaultDamage * CorrectionDamage * Level;
        Experience = defaultExperience * CorrectionExperience * Level;
        Gold = defaultGold * CorrectionGold * Level;
        DropChanse = defaultDropChance * CorrectionDropChanse * Level;
        Armor = defaultArmor * CorrectionArmor * Level;
        MagicResist = defaultMagicResist * CorrectionMagicResist * Level;

        maxHealthPoints = HealthPoints;
        maxDamage = Damage;
        maxExperience = Experience;
        maxGold = Gold;
        maxDropChanse = DropChanse;
        maxArmor = Armor;
        maxMagicResist = MagicResist;

    }

    public bool isDead()
    {
        if (HealthPoints <= 0.0f)
            return true;
        return false;
    }
}

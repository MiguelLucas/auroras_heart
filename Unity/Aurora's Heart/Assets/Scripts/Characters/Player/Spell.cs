using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject {

    [SerializeField]
    private string spellName = "";
    [SerializeField]
    private GameObject spellPrefab = null;
    [SerializeField]
    private GameObject spellCollisionParticle = null;
    [SerializeField]
    private Texture2D spellIcon = null;
    [SerializeField]
    private int manaCost = 0;
    [SerializeField]
    private int minDamage = 0;
    [SerializeField]
    private int maxDamage = 0;
    [SerializeField]
    private int projectileSpeed = 0;

    public string SpellName
    {
        get
        {
            return spellName;
        }

        set
        {
            spellName = value;
        }
    }

    public GameObject SpellPrefab
    {
        get
        {
            return spellPrefab;
        }

        set
        {
            spellPrefab = value;
        }
    }

    public GameObject SpellCollisionParticle
    {
        get
        {
            return spellCollisionParticle;
        }

        set
        {
            spellCollisionParticle = value;
        }
    }

    public Texture2D SpellIcon
    {
        get
        {
            return spellIcon;
        }

        set
        {
            spellIcon = value;
        }
    }

    public int ManaCost
    {
        get
        {
            return manaCost;
        }

        set
        {
            manaCost = value;
        }
    }

    public int MinDamage
    {
        get
        {
            return minDamage;
        }

        set
        {
            minDamage = value;
        }
    }

    public int MaxDamage
    {
        get
        {
            return maxDamage;
        }

        set
        {
            maxDamage = value;
        }
    }

    public int ProjectileSpeed
    {
        get
        {
            return projectileSpeed;
        }

        set
        {
            projectileSpeed = value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellCreator : EditorWindow
{
    [MenuItem("Spell Maker/Spell Wizard")]
    static void Init()
    {
        SpellCreator spellWindow = (SpellCreator)CreateInstance(typeof(SpellCreator));
        spellWindow.Show();
    }

    Spell tempSpell = null;
    SpellManager spellManager = null;

    private void OnGUI()
    {
        if(spellManager == null)
        {
            spellManager = GameObject.Find("SpellManager").GetComponent<SpellManager>();
            
        }
        if(tempSpell)
        {
            tempSpell.SpellName = EditorGUILayout.TextField("Spell Name", tempSpell.SpellName);
            tempSpell.SpellPrefab = (GameObject)EditorGUILayout.ObjectField("Spell Prebab", tempSpell.SpellPrefab, typeof(GameObject), false);
            tempSpell.SpellCollisionParticle = (GameObject)EditorGUILayout.ObjectField("Spell Collision Effect", tempSpell.SpellCollisionParticle, typeof(GameObject), false);
            tempSpell.SpellIcon = (Texture2D)EditorGUILayout.ObjectField("Spell Icon", tempSpell.SpellIcon, typeof(Texture2D), false);
            tempSpell.ManaCost = EditorGUILayout.IntField("Mana Cost", tempSpell.ManaCost);
            tempSpell.MinDamage = EditorGUILayout.IntField("Minimum Damage", tempSpell.MinDamage);
            tempSpell.MaxDamage = EditorGUILayout.IntField("Maximum Damage", tempSpell.MaxDamage);
            tempSpell.ProjectileSpeed = EditorGUILayout.IntField("Projectile Speed", tempSpell.ProjectileSpeed);
        }

        EditorGUILayout.Space();

        if(tempSpell == null)
        {
            if(GUILayout.Button("Create Spell"))
            {
                tempSpell = CreateInstance<Spell>();
            }
        }
        else
        {
            if(GUILayout.Button("Create Scriptable Object"))
            {
                AssetDatabase.CreateAsset(tempSpell, "Assets/Resources/Spells/" + tempSpell.SpellName + ".asset");
                AssetDatabase.SaveAssets();
                spellManager.SpellList.Add(tempSpell);
                Selection.activeObject = tempSpell;

                tempSpell = null;
            }
        }

        if (GUILayout.Button("Reset"))
        {
            Reset();
        }
    }

    private void Reset()
    {

        if (tempSpell)
        {
            tempSpell.SpellName = "";
            tempSpell.SpellPrefab = null;
            tempSpell.SpellCollisionParticle = null;
            tempSpell.SpellIcon = null;
            tempSpell.ManaCost = 0;
            tempSpell.MinDamage = 0;
            tempSpell.MaxDamage = 0;
        }
    }

}

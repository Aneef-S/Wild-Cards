using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ParaScriptableObject", order = 1)]

public class ParaScriptableObject : ScriptableObject
{
    // Para Class Details

    public int ID;
    public string paraName;
    public int paraAttack;
    public float maxHealth;
}

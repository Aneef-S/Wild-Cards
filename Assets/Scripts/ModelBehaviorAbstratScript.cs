using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelBehaviorAbstratScript : MonoBehaviour
{

    private ParaScriptableObject paraScriptableObject;
    public abstract void Attack();
    public abstract void Move();

    public abstract string GetName();


    public abstract void reduceHealth(float attack);

    public abstract float GetHealth();
    public abstract float GetMaxHealth();

    public abstract void Die();


}

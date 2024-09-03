using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : ModelBehaviorAbstratScript
{
    [SerializeField] private ParaScriptableObject m_skeletonScript;
    
    
    [SerializeField] private Animator m_animator;

    private const string IDLE = "idle";
    private const string ATTACK = "Strike_1";
    private string m_currentState = IDLE;
    private float currentHealth;
    private float maxhealth;
    // Start is called before the first frame update

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    void Start()
    {
       
        currentHealth = m_skeletonScript.maxHealth;
        maxhealth = m_skeletonScript.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetAnimationToIdle()
    {
        while (IsAnimationPlaying(m_animator, m_currentState)) ;
        ChangeState(IDLE);
    }

    public override void Attack()
    {
        if (IsAnimationPlaying(m_animator, ATTACK)) return;
        ChangeState(ATTACK);
        ChangeState(IDLE);
        
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override string GetName()
    {
        return m_skeletonScript.paraName;
    }

    public override void reduceHealth(float attack)
    {
        currentHealth -= attack;
    }

    public override float GetHealth()
    {
        return currentHealth;
    }

    public override float GetMaxHealth()
    {
        return maxhealth;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }





    //To change the animation.
    private void ChangeState(string state) 
    {
        if (m_currentState == state) return;

        else
        {
            m_currentState = state;
            m_animator.Play(m_currentState);
        }

    }

    private bool IsAnimationPlaying(Animator animator, string state)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(state) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) 
            return true;
        else return false;
    }
}

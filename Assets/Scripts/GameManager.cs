using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private float currentTime;
    [SerializeField] private float afterAttackInterval = 1f;
    private bool playerTurn = true;
    [SerializeField] private float attackInterval = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private ModelBehaviorAbstratScript playerScript;
    [SerializeField] private ModelBehaviorAbstratScript enemyScript;
    [SerializeField] private Text playerText;
    [SerializeField] private Text enemyText;

    [SerializeField] private CharacterScript playerCharacterScript;
    [SerializeField] private CharacterScript enemyCharacterScript;

    int enemyIndex = 0;

    public bool isPlayerDead;
    public bool isEnemyDead;

    [SerializeField] private Image enemyHealthbar;
    [SerializeField] private Image playerHealthbar;
    [SerializeField] private DataHoldingScript dataHolderScript;

    public Sprite[] cardImages;
    public List<int> selectedCards;
    public List<int> selectedEnemyCards;


    [SerializeField] private GameObject menuPanel;

    private void Awake()
    {
       

        selectedEnemyCards.Add(0);
        selectedEnemyCards.Add(1);
        selectedEnemyCards.Add(2);
        menuPanel.SetActive(false);
       dataHolderScript = FindObjectOfType<DataHoldingScript>();
       selectedCards = dataHolderScript.selectedCards;
    }
    private void Start()
    {
        playerCharacterScript = player.GetComponentInChildren<CharacterScript>();
        enemyCharacterScript = enemy.GetComponentInChildren<CharacterScript>();

        currentTime = 0f;
        enemyHealthbar.fillAmount = 1;
        isEnemyDead = true;
        isPlayerDead = true;

        SpawnEnemy();
        
        

        

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        
        
        if (!enemyScript) 
        {
            playerScript = player.GetComponentInChildren<ModelBehaviorAbstratScript>();
            enemyScript = enemy.GetComponentInChildren<ModelBehaviorAbstratScript>();
            if(!enemyScript)
            {
                return;
            }
            enemyText.text = enemyScript.GetName();
            return;
        }
        //PLAYER ATTACK
        if (currentTime > attackInterval && playerTurn && !isPlayerDead && !isEnemyDead)
        {
            PlayerAttack();
            currentTime = 0f;
            playerTurn = !playerTurn;
            StartCoroutine(PlayerAttackCoroutine());
        }
        //ENEMY ATTACK
        else if (currentTime > attackInterval && !playerTurn && !isEnemyDead && !isPlayerDead)
        {
            EnemyAttack();
            currentTime = 0f;
            playerTurn = !playerTurn;
            StartCoroutine (EnemyAttackCoroutine());
        }

        

    }

    public void SpawnPlayer(int modelNum)
    {
        playerCharacterScript.SpawnModel(modelNum);
        playerHealthbar.fillAmount = 1;
        playerScript = player.GetComponentInChildren<ModelBehaviorAbstratScript>();
        playerText.text = playerScript.GetName();
        isPlayerDead = false;
    }

    void SpawnEnemy()
    {
        enemyCharacterScript.SpawnModel(enemyIndex++);
        enemyHealthbar.fillAmount = 1;
        enemyScript = enemy.GetComponentInChildren<ModelBehaviorAbstratScript>();
        enemyText.text = enemyScript.GetName();
        isEnemyDead = false;
    }

    private void KillPlayerModel()
    {
        playerScript.Die();
    }

    private void KillEnemyModel()
    {
        enemyScript.Die();
    }

    private void EnemyAttack()
    {
        enemyScript.Attack();
    }

    private void PlayerAttack()
    {
        playerScript.Attack();
    }

    IEnumerator PlayerAttackCoroutine()
    { 
        float finalAttackTime = currentTime + afterAttackInterval;

        while(currentTime < finalAttackTime)
        {

            yield return null;
        }
        enemyScript.reduceHealth(1);
        enemyHealthbar.fillAmount = enemyScript.GetHealth() / enemyScript.GetMaxHealth();
        if (enemyScript.GetHealth() <= 0)
        {
            isEnemyDead = true;
            KillEnemyModel();
            if(enemyIndex <3)
            {
                SpawnEnemy();
            }
            else
            {
                EnableExitButton();
            }

        }
    }

    IEnumerator EnemyAttackCoroutine()
    {
        float finalAttackTime = currentTime + afterAttackInterval;

        while (currentTime < finalAttackTime)
        {

            yield return null;
        }
        
        playerScript.reduceHealth(1);
        playerHealthbar.fillAmount = playerScript.GetHealth() / playerScript.GetMaxHealth();
        if (playerScript.GetHealth() <= 0)
        {
            isPlayerDead = true;
            KillPlayerModel();
        }
    }

    void EnableExitButton()
    {
        menuPanel.SetActive(true);
    }

}

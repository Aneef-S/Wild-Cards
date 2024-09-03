using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCardScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameManager gameManagerScript;
    [SerializeField] private Transform parentAfterDrag;
    [SerializeField] private Image mainCard;
    [SerializeField] private int index;

   

    private void Start()
    {
        
        mainCard = GetComponent<Image>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
        mainCard.sprite = gameManagerScript.cardImages[gameManagerScript.selectedCards[index]];
       
    }

    public void SpawnModel()
    {
        if(!gameManagerScript.isPlayerDead)
        {
            return;
        }
        gameManagerScript.SpawnPlayer(gameManagerScript.selectedCards[index]);
        Destroy(gameObject);
    }
}

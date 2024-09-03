using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    [SerializeField] private GameObject sceneManager;
    [SerializeField] private MenuManager menuManager;
    private UIScript script;
    [SerializeField] private float disapperTime = 1.0f;
    [SerializeField] private Image emptyCardImage;
    [SerializeField] private Image mainCardImage;
    [SerializeField] private int cardIndex;
    [SerializeField] private GameObject dataHolder;
    [SerializeField] private DataHoldingScript dataHoldingScript;


    private void Start()
    {
        script = sceneManager.GetComponent<UIScript>();
        menuManager = sceneManager.GetComponent<MenuManager>();
        mainCardImage.sprite = menuManager.cardImages[menuManager.modelsNumbers[cardIndex]];
        dataHoldingScript = dataHolder.GetComponent<DataHoldingScript>();
       
    }
    public void ReavealButton()
    {
        if(menuManager.selectedCardsCount >= 3)
        {
            return;
        }

        if(emptyCardImage != null) 
        {
            
            StartCoroutine(ButtonRevealCoroutine());
            menuManager.selectedCardsCount++;
            menuManager.selectedCard.Add(menuManager.modelsNumbers[cardIndex]);
        }
        else
        {
            Debug.Log("Card Image found NULL\n");
        }
    }

    private IEnumerator ButtonRevealCoroutine()
    {
        Color cardColour = emptyCardImage.color;
        float currentTime = 0;
        float currentAlpha;

        while (currentTime < disapperTime)   
        {
            currentAlpha = Mathf.Lerp(1f,0f,(currentTime/disapperTime));
            cardColour.a = currentAlpha;
            emptyCardImage.color = cardColour;

            currentTime += Time.deltaTime;

            yield return null;
        }
        cardColour.a = 0f;
        emptyCardImage.color = cardColour;
        if(menuManager.selectedCardsCount == 3)
        {
            script.CardRevealed();
            dataHoldingScript.selectedCards = menuManager.selectedCard;
        }

    }
}

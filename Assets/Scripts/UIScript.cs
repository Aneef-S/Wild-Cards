using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform buttonPanel; // The panel containing the buttons
    public RectTransform cardsPanel;  // The panel containing the cards
    public float buttonSlideDistance = 1957f; // Distance the buttons will slide down
    public float cardSlideDistance = 1957f; // Distance the cards will slide down from the top
    public float slideDuration = 0.5f; // Duration of the slide

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject revealText;
    private bool isCardReavealed = false;

    private Vector3 buttonInitialPosition;
    private Vector3 cardsInitialPosition;

    private void Start()
    {
        buttonInitialPosition = buttonPanel.anchoredPosition;
        cardsInitialPosition = cardsPanel.anchoredPosition;
        playButton.SetActive(false);
        revealText.SetActive(true);
    }

    private void Update()
    {
        if (isCardReavealed)
        {
            playButton.SetActive(true);
            revealText.SetActive(false);
        }
    }

    public void RevealCardTransform()
    {
        StartCoroutine(SlideButtonAndCards());
    }

    private IEnumerator SlideButtonAndCards()
    {
        float elapsedTime = 0f;

        Vector3 buttonTargetPosition = buttonInitialPosition + new Vector3(0, -buttonSlideDistance, 0);
        Vector3 cardsTargetPosition = cardsInitialPosition + new Vector3(0, -cardSlideDistance, 0);

        while (elapsedTime < slideDuration)
        {
            buttonPanel.anchoredPosition = Vector3.Lerp(buttonInitialPosition, buttonTargetPosition, elapsedTime / slideDuration);
            cardsPanel.anchoredPosition = Vector3.Lerp(cardsInitialPosition, cardsTargetPosition, elapsedTime / slideDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonPanel.anchoredPosition = buttonTargetPosition;
        cardsPanel.anchoredPosition = cardsTargetPosition;
    }

    public void CardRevealed()
    {
        isCardReavealed = true;
    }

}

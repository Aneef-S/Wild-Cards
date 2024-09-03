using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Sprite[] cardImages;
    public List<int> selectedCard = new List<int>();
    public int selectedCardsCount = 0;
  
    public int[] modelsNumbers = { 0, 1, 2, 3 };

    private void Awake()
    {
        for (int i = modelsNumbers.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);  
            int temp = modelsNumbers[i];
            modelsNumbers[i] = modelsNumbers[j];
            modelsNumbers[j] = temp;
        }
    }

    private void Start()
    {

    }


}

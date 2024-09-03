using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHoldingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> selectedCards;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

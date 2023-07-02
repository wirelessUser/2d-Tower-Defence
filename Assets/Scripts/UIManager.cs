using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TowerCreation towerCreationRef;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = MainGameControlller. instance.CoinInTreasure.ToString();
    }
}

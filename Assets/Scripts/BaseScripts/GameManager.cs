using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class GameManager : MyBaseSingleton<GameManager>
{
    public TextMeshProUGUI MoneyText;
    public float Money;

    private void Update()
    {
        MoneyText.text = "$" + PlayerPrefs.GetInt("money");


        if (Input.GetMouseButtonDown(1))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 50);
        }

    }
}

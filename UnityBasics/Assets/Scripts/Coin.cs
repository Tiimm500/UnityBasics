using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Update is called once per frame
    public void UpdateCoin(Player player)
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = player.DoubleJumpsRemaining.ToString();
    }
}

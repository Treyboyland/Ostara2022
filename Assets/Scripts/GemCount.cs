using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCount : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    Player player;

    private void Awake()
    {
        UpdateUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        player.OnInventoryUpdated.AddListener(UpdateUI);

    }

    void UpdateUI()
    {
        textBox.text = "Gems: " + player.Inventory.GetNumberOfItem("Gem");
    }
}

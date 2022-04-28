using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotsUI : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Image image;


    [SerializeField]
    List<Sprite> countSprites;

    // Start is called before the first frame update
    void Awake()
    {
        player.OnInventoryUpdated.AddListener(ShowCarrotGraphic);
        ShowCarrotGraphic();
    }

    void ShowCarrotGraphic()
    {
        int count = player.Inventory.GetNumberOfItem("Carrot");

        if (count >= countSprites.Count)
        {
            image.sprite = countSprites[countSprites.Count - 1];
        }
        else
        {
            image.sprite = countSprites[count];
        }
    }
}

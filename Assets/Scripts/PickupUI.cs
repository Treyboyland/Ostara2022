using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    Sprite dandelionSprite;

    [SerializeField]
    Sprite tomatoSprite;

    [SerializeField]
    Sprite pelletSprite;



    public void SetItem(Item item)
    {
        Sprite sprite = null;
        switch (item.ItemName)
        {
            case "Tomato":
                sprite = tomatoSprite;
                break;
            case "Dandelion":
                sprite = dandelionSprite;
                break;
            case "Pellet":
                sprite = pelletSprite;
                break;
            default:
                break;
        }

        image.sprite = sprite;
    }
}

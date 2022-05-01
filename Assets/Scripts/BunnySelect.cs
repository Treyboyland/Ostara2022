using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BunnySelect : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    PlayerDataSO dataSO;

    [SerializeField]
    Inventory cost;

    public UnityEvent<PlayerDataSO> OnBunnyChosen = new UnityEvent<PlayerDataSO>();

    private void Start()
    {
        button.onClick.AddListener(ChooseBunny);
    }

    void ChooseBunny()
    {
        OnBunnyChosen.Invoke(dataSO);
    }

}

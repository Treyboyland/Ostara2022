using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO playerData;

    public PlayerDataSO PlayerData { get { return playerData; } set { playerData = value; UpdateParameters(); } }


    [SerializeField]
    PlayerController controller;

    [SerializeField]
    BoxCollider2D playerBody;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Inventory inventory;

    public Inventory Inventory { get { return inventory; } }

    public UnityEvent OnInventoryUpdated = new UnityEvent();

    private void Start()
    {
        UpdateParameters();
    }


    void UpdateParameters()
    {
        if (playerData != null)
        {
            controller.Speed = playerData.Speed;
            playerBody.size = playerData.ColliderSize;
            animator.runtimeAnimatorController = playerData.PlayerAnimator;
        }
    }

    public void AddToInventory(Item item)
    {
        inventory.AddItem(item);
        OnInventoryUpdated.Invoke();
    }
}

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
    PlayerDig playerDig;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Inventory inventory;

    [SerializeField]
    AK.Wwise.Event onPlayerDamaged;

    [SerializeField]
    Rigidbody2D body;

    public Inventory Inventory { get { return inventory; } }

    public UnityEvent OnInventoryUpdated = new UnityEvent();

    public UnityEvent OnPlayerDeath = new UnityEvent();

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
            playerDig.DigTime = playerData.DigTime;
        }
    }

    public void AddToInventory(Item item)
    {
        inventory.AddItem(item);
        OnInventoryUpdated.Invoke();
    }

    public void DamagePlayer()
    {


        inventory.RemoveItem("Carrot");
        OnInventoryUpdated.Invoke();
        onPlayerDamaged.Post(gameObject);
        if (inventory.GetNumberOfItem("Carrot") == 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        OnPlayerDeath.Invoke();
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HomeBase : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    SpriteRenderer burrowRenderer;

    [SerializeField]
    float secondsToWaitForReturn;

    [SerializeField]
    List<BunnySelect> possibleSelections;

    [SerializeField]
    Vector3 spawnLocation;

    public Vector3 SpawnLocation
    {
        get
        {
            return spawnLocation;
        }
    }

    [SerializeField]
    GameObject selectText;

    bool canEnterBase = true;

    bool CanEnterBase
    {
        get { return canEnterBase; }
        set
        {
            canEnterBase = value;
            burrowRenderer.enabled = canEnterBase;
        }
    }

    public UnityEvent OnBaseReached = new UnityEvent();

    public UnityEvent OnActivateEnemy = new UnityEvent();

    private void Awake()
    {
        foreach (var bunny in possibleSelections)
        {
            bunny.OnBunnyChosen.AddListener(BunnyChosen);
        }
        ShowBunnySelections();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetBunnySelectionsActive(bool value)
    {
        foreach (var bunny in possibleSelections)
        {
            bunny.gameObject.SetActive(value);
        }
    }

    void BunnyChosen(PlayerDataSO data)
    {
        selectText.gameObject.SetActive(false);
        player.PlayerData = data;
        player.transform.position = spawnLocation;
        player.gameObject.SetActive(true);
        SetBunnySelectionsActive(false);
        CanEnterBase = false;
        StartCoroutine(WaitThenRestore());
    }

    void ShowBunnySelections()
    {
        selectText.gameObject.SetActive(true);
        OnBaseReached.Invoke();
        player.gameObject.SetActive(false);
        player.transform.position = spawnLocation;
        var playerBody = player.GetComponent<Rigidbody2D>();
        if (playerBody != null)
        {
            playerBody.velocity = Vector2.zero;
        }
        SetBunnySelectionsActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.gameObject.GetComponent<Player>();

        if (canEnterBase && p != null)
        {
            ShowBunnySelections();
        }
    }

    IEnumerator WaitThenRestore()
    {
        yield return new WaitForSeconds(secondsToWaitForReturn);
        CanEnterBase = true;
        OnActivateEnemy.Invoke();
    }
}

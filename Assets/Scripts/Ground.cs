using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer frontSprite;

    [SerializeField]
    Collider2D groundCollider;

    [SerializeField]
    AK.Wwise.Event digSoundEvent;

    [SerializeField]
    AK.Wwise.RTPC digTimeRTPC;

    public UnityEvent OnDirtBroken;

    bool isDigging = false;

    bool isDugOut = false;

    Vector3 location;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dig(float digTime)
    {
        if (!isDigging && !isDugOut)
        {
            StartCoroutine(DiggingCoroutine(digTime));
        }
    }

    public void SetLocation(Vector3 location)
    {
        this.location = location;
        transform.position = location;
    }

    public void StopDigging()
    {
        isDigging = false;
        StopAllCoroutines();
        digTimeRTPC.SetGlobalValue(0);
    }

    void ResetGround()
    {
        groundCollider.enabled = true;
        frontSprite.enabled = true;
        isDugOut = false;
    }

    void DigOut()
    {
        groundCollider.enabled = false;
        frontSprite.enabled = false;
        isDugOut = true;
        digSoundEvent.Post(gameObject);
    }

    IEnumerator DiggingCoroutine(float secondsToWait)
    {
        isDigging = true;
        float elapsed = 0;
        while (elapsed < secondsToWait)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / secondsToWait * 100;
            digTimeRTPC.SetGlobalValue(Mathf.Min(progress, 100));
            yield return null;
        }


        DigOut();
        digTimeRTPC.SetGlobalValue(0);
        isDigging = false;
        OnDirtBroken.Invoke();
    }
}

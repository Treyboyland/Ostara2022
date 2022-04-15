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

    public UnityEvent OnDirtBroken;

    bool isDigging = false;

    bool isDugOut = false;

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

    public void StopDigging()
    {
        isDigging = false;
        StopAllCoroutines();
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
    }

    IEnumerator DiggingCoroutine(float secondsToWait)
    {
        isDigging = true;
        yield return new WaitForSeconds(secondsToWait);
        DigOut();
        isDigging = false;
        OnDirtBroken.Invoke();
    }
}

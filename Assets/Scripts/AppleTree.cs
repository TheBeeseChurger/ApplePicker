using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameUI rounds;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChange = 0.1f;

    public float itemDropDelay = 1f;
    
    void Start()
    {
        TryToDrop();
    }

    void DropItem()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        TryToDrop();
    }

    private void TryToDrop()
    {
        if (rounds.CheckIfCanDrop())
        {
            Invoke(nameof(DropItem), itemDropDelay);
        }
        else
        {
            Invoke(nameof(TryToDrop), 5f);
            speed *= 1.2f;
            itemDropDelay *= 0.8f;
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChange)
        {
            speed *= -1;
        }
    }
}

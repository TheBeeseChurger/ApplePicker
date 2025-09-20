using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public bool isBranch; // supposed to not catch branches

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            if (!isBranch)
            {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleMissed();
            }
        }
    }
}

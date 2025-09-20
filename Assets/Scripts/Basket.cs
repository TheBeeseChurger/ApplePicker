using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Apple apple = collidedWith.GetComponent<Apple>();
            if (apple)
            {
                if (apple.isBranch)
                {
                    ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                    apScript.AppleMissed();
                }
                else
                {
                    scoreCounter.score += 100;
                    HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
                }
            }
            
            Destroy(collidedWith);
        }
    }
}

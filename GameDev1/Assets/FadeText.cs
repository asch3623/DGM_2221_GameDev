using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{

    private int seconds = 2;
    private int i;
    private Text t;
    private Color textColor;
    private float textY, speed, alpha;
    private bool isComplete, isDoneMoving;

    private void Start()
    {
        t = GetComponent<Text>();
        textColor = t.color;
        alpha = textColor.a;
        i = 0;

        speed = 8f;
        isComplete = false;
        isDoneMoving = false;
        textY = gameObject.transform.position.y;

    }

    private void Update()
    {
        gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
        if (gameObject.transform.position.y > 80)
        {
            isDoneMoving = true;
        }
        if (isDoneMoving)
        {
            t.CrossFadeAlpha(0.0f, 1f, false);
            StartCoroutine(Wait());
        }
        if (isComplete)
        {
            
            Destroy(gameObject);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(seconds);
        isComplete = true;
        yield break;
    }
    


    }



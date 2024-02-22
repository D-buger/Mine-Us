using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public bool isMove { get; private set; } = false;

    private Vector2 originalPos;
    private Vector2 moveToPos;

    private Collider2D collisionOre;

    public event UnityAction playerMoveAction;

    private void Start()
    {
        playerMoveAction += 
            () => transform.Translate(moveToPos * PlayManager.Instance.speed);
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            playerMoveAction?.Invoke();
        }
    }

    public void StopMoving()
    {
        isMove = false;

        if(collisionOre != null)
        {
            float distance = Vector2.Distance(collisionOre.transform.position, transform.GetChild(0).transform.position);
            if(distance < 0.3f)
            {
                PlayManager.Instance.ui.ChangeBackgroundText("Exellent");
                PlayManager.Instance.Speed += 0.05f;
                PlayManager.Instance.Timer += 5;
            }
            else if(distance < 0.5f)
            {
                PlayManager.Instance.ui.ChangeBackgroundText("Great");
                PlayManager.Instance.Speed += 0.03f;
                PlayManager.Instance.Timer += 3;
            }
            else
            {
                PlayManager.Instance.ui.ChangeBackgroundText("Good");
                PlayManager.Instance.Speed += 0.01f;
            }

        }
        else
        {
            PlayManager.Instance.ui.ChangeBackgroundText("");
            PlayManager.Instance.Speed = 0;
        }
    }

    public void Moving(float angle)
    {
        isMove = true;
        originalPos = gameObject.transform.position;

        float radian = angle * Mathf.Deg2Rad;
        moveToPos = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ore"))
            collisionOre = collision;
        else if (collision.CompareTag("PlayerBorderLine"))
            PlayManager.Instance.GameOver();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBorderLine"))
            PlayManager.Instance.GameOver();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ore"))
        {
            collisionOre = null;
        }
    }
}

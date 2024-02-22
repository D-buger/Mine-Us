using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Arrow : MonoBehaviour
{
    [SerializeField] private float minAngle = -160;
    [SerializeField] private float maxAngle = -20;

    private float angleSpeed = 5;

    private SpriteRenderer spriteRenderer;
    private PlayerMove player;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = gameObject.GetComponentInParent<PlayerMove>();

        InputManager.Instance.GetInputAction += ChangeAngle;
        InputManager.Instance.InputActionDown += AngleStart;
        InputManager.Instance.InputActionUp += AngleEnd;
        gameObject.SetActive(false);
    }

    private float angle = 0;
    private void Update()
    {
    }
    private void FixedUpdate()
    {
    }

    private void AngleStart(float a)
    {
        angle = a < 0 ? minAngle : maxAngle;
        gameObject.SetActive(true);
        player.StopMoving();
        isChangeDirection = false;
    }

    private bool isChangeDirection = false;
    private void ChangeAngle(float a)
    {
        if (angle == minAngle || angle == maxAngle)
            isChangeDirection = !isChangeDirection;

        if (isChangeDirection)
        {
            angle += a * Time.deltaTime * (PlayManager.Instance.Speed * 100) * angleSpeed;
        }
        else
        {
            angle -= a * Time.deltaTime * (PlayManager.Instance.Speed * 100) * angleSpeed;
        }

        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        

        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void AngleEnd()
    {
        gameObject.SetActive(false);
        gameObject.transform.parent.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        player.Moving(angle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : SingletonBehavior<InputManager>
{
    protected override void OnAwake()
    {

    }

    public event UnityAction<float> GetInputAction;
    public event UnityAction<float> InputActionDown;
    public event UnityAction InputActionUp;

    public bool isFirstInput = false;

    private bool isBtnDown = false;

    public void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        if (hor != 0)
        {
            if (!isBtnDown)
            {
                isBtnDown = true;
                InputActionDown?.Invoke(hor);
            }

            GetInputAction?.Invoke(hor);
        }

        if (Input.GetAxis("Horizontal") == 0 && isBtnDown)
        {
            isBtnDown = false;
            InputActionUp?.Invoke();
        }

    }
}

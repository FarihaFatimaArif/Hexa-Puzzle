using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour, IInputState
{
    IInputSystem inputsystem;
    InputState state;
    Touch touch;
    Vector2 touchStartPos;
    Vector2 touchEndPos;
    void OnEnable()
    {
        ChangeState(new IdleInputState(this, inputsystem));
    }
    public void ChangeState(InputState _state)
    {
        state = _state;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                state.Begin(touch);
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                state.Move(touch);


            }
            else if (touch.phase == TouchPhase.Ended)
            {
                state.End(touch);
            }
        }
    }

}

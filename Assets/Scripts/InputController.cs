using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour, IInputState
{
    protected IInputSystem InputSystem;
    InputState state;
    Touch touch;
    Vector2 touchStartPos;
    Vector2 touchEndPos;
    public void InitializeInputController(IInputSystem ic)
    {
        Debug.Log("intialized");
        InputSystem = ic;
        ChangeState(new IdleInputState(this, InputSystem));
        Debug.Log(state);
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
            else if (touch.phase == TouchPhase.Moved)
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

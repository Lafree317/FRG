using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

// Use a separate PlayerInput component for setting up input.
public class ControlManager : MonoSingleton<ControlManager>
{
    public Action<Vector2> MoveCallBack;
    private bool m_Charging;
    private Vector2 m_Look;
    private Vector2 m_Move;

    public void OnMove(InputAction.CallbackContext context)
    {
        
        m_Move = context.ReadValue<Vector2>();
        Move(m_Move);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
        Look(m_Look);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if (context.interaction is SlowTapInteraction)
                {
                    ChargingFire();
                }
                else
                {
                    Fire();
                }
                m_Charging = false;
                break;

            case InputActionPhase.Started:
                if (context.interaction is SlowTapInteraction)
                    m_Charging = true;
                break;

            case InputActionPhase.Canceled:
                m_Charging = false;
                break;
        }
    }

    public void OnGUI()
    {
        if (m_Charging)
            GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
    }

    private void Move(Vector2 direction)
    {
        Debug.Log("Move" + direction);
        MoveCallBack?.Invoke(direction);
    }

    private void Look(Vector2 rotate)
    {
        Debug.Log("Look" + rotate);
    }

    private void Fire()
    {
        Debug.Log("Fire");
    }

    private void ChargingFire()
    {
        Debug.Log("ChargingFire");
    }
}

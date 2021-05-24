// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player2.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player2 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player2"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""f396aff6-5a55-414e-8db0-93cd60415442"",
            ""actions"": [
                {
                    ""name"": ""Jump2"",
                    ""type"": ""Button"",
                    ""id"": ""74444157-58b2-45ec-aec0-cdf40a2ae819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fall2"",
                    ""type"": ""Button"",
                    ""id"": ""bd77bcef-356b-4afe-af48-1eae77116f68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f459283-9fcd-4493-963e-d148caa209a1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffe34e97-b6b2-41d1-866b-15080645bda5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Fall2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard2"",
            ""bindingGroup"": ""Keyboard2"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Jump2 = m_Movement.FindAction("Jump2", throwIfNotFound: true);
        m_Movement_Fall2 = m_Movement.FindAction("Fall2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Jump2;
    private readonly InputAction m_Movement_Fall2;
    public struct MovementActions
    {
        private @Player2 m_Wrapper;
        public MovementActions(@Player2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump2 => m_Wrapper.m_Movement_Jump2;
        public InputAction @Fall2 => m_Wrapper.m_Movement_Fall2;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Jump2.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump2;
                @Fall2.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnFall2;
                @Fall2.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnFall2;
                @Fall2.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnFall2;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @Fall2.started += instance.OnFall2;
                @Fall2.performed += instance.OnFall2;
                @Fall2.canceled += instance.OnFall2;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_Keyboard2SchemeIndex = -1;
    public InputControlScheme Keyboard2Scheme
    {
        get
        {
            if (m_Keyboard2SchemeIndex == -1) m_Keyboard2SchemeIndex = asset.FindControlSchemeIndex("Keyboard2");
            return asset.controlSchemes[m_Keyboard2SchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnJump2(InputAction.CallbackContext context);
        void OnFall2(InputAction.CallbackContext context);
    }
}

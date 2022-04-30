// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/CustomInputs/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CustomInputs
{
    public class @GameInputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""acaff513-e031-418e-9abd-ad781b1feef2"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""77db7997-d43f-4a1c-a404-a259966813f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleTrafficLight"",
                    ""type"": ""Button"",
                    ""id"": ""dcc37f2b-a06d-42c8-b754-13590060a792"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d41caf62-1321-4d99-9fd1-9d70ebb6945d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dc7f7f6-d05f-4cbf-96bb-2066f28f4680"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb601d6e-7677-4fc7-a896-a438035cc8ae"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleTrafficLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f69b68bd-6897-4288-abe7-0c3b19b12893"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleTrafficLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Main
            m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
            m_Main_Pause = m_Main.FindAction("Pause", throwIfNotFound: true);
            m_Main_ToggleTrafficLight = m_Main.FindAction("ToggleTrafficLight", throwIfNotFound: true);
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

        // Main
        private readonly InputActionMap m_Main;
        private IMainActions m_MainActionsCallbackInterface;
        private readonly InputAction m_Main_Pause;
        private readonly InputAction m_Main_ToggleTrafficLight;
        public struct MainActions
        {
            private @GameInputs m_Wrapper;
            public MainActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_Main_Pause;
            public InputAction @ToggleTrafficLight => m_Wrapper.m_Main_ToggleTrafficLight;
            public InputActionMap Get() { return m_Wrapper.m_Main; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
            public void SetCallbacks(IMainActions instance)
            {
                if (m_Wrapper.m_MainActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPause;
                    @ToggleTrafficLight.started -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleTrafficLight;
                    @ToggleTrafficLight.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleTrafficLight;
                    @ToggleTrafficLight.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleTrafficLight;
                }
                m_Wrapper.m_MainActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @ToggleTrafficLight.started += instance.OnToggleTrafficLight;
                    @ToggleTrafficLight.performed += instance.OnToggleTrafficLight;
                    @ToggleTrafficLight.canceled += instance.OnToggleTrafficLight;
                }
            }
        }
        public MainActions @Main => new MainActions(this);
        public interface IMainActions
        {
            void OnPause(InputAction.CallbackContext context);
            void OnToggleTrafficLight(InputAction.CallbackContext context);
        }
    }
}

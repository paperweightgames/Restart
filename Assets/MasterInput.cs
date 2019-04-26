// GENERATED AUTOMATICALLY FROM 'Assets/MasterInput.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class MasterInput : InputActionAssetReference
{
    public MasterInput()
    {
    }
    public MasterInput(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Move = m_Player.GetAction("Move");
        m_Player_Look = m_Player.GetAction("Look");
        m_Player_Action = m_Player.GetAction("Action");
        m_Player_Shoot = m_Player.GetAction("Shoot");
        // Inventory
        m_Inventory = asset.GetActionMap("Inventory");
        m_Inventory_Toggle = m_Inventory.GetAction("Toggle");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_Move = null;
        m_Player_Look = null;
        m_Player_Action = null;
        m_Player_Shoot = null;
        m_Inventory = null;
        m_Inventory_Toggle = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_Move;
    private InputAction m_Player_Look;
    private InputAction m_Player_Action;
    private InputAction m_Player_Shoot;
    public struct PlayerActions
    {
        private MasterInput m_Wrapper;
        public PlayerActions(MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Player_Move; } }
        public InputAction @Look { get { return m_Wrapper.m_Player_Look; } }
        public InputAction @Action { get { return m_Wrapper.m_Player_Action; } }
        public InputAction @Shoot { get { return m_Wrapper.m_Player_Shoot; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    // Inventory
    private InputActionMap m_Inventory;
    private InputAction m_Inventory_Toggle;
    public struct InventoryActions
    {
        private MasterInput m_Wrapper;
        public InventoryActions(MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle { get { return m_Wrapper.m_Inventory_Toggle; } }
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
    }
    public InventoryActions @Inventory
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new InventoryActions(this);
        }
    }
    private int m_WASDSchemeIndex = -1;
    public InputControlScheme WASDScheme
    {
        get

        {
            if (m_WASDSchemeIndex == -1) m_WASDSchemeIndex = asset.GetControlSchemeIndex("WASD");
            return asset.controlSchemes[m_WASDSchemeIndex];
        }
    }
    private int m_ArrowKeysSchemeIndex = -1;
    public InputControlScheme ArrowKeysScheme
    {
        get

        {
            if (m_ArrowKeysSchemeIndex == -1) m_ArrowKeysSchemeIndex = asset.GetControlSchemeIndex("Arrow Keys");
            return asset.controlSchemes[m_ArrowKeysSchemeIndex];
        }
    }
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get

        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.GetControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
}

using System;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    
    //매니저 컴포넌트
    private PlayerManager _playerManager;
    private WeaponManager _weaponManager;
    private InputManager _inputManager;

    public static Managers Instance => _instance;
    
    //매니저 속성
    public static PlayerManager PlayerManager => Instance._playerManager;
    public static WeaponManager WeaponManager => Instance._weaponManager;
    public static InputManager InputManager => Instance._inputManager;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        CreateManagers();
    }
    
    private void CreateManagers()
    {
        _playerManager = gameObject.AddComponent<PlayerManager>();
        _weaponManager = gameObject.AddComponent<WeaponManager>();
        _inputManager = gameObject.AddComponent<InputManager>();
        
    }
    
}

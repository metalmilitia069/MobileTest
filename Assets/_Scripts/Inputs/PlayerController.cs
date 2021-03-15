using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerControls _PlayerControls;
    public float movementInput = 0;

    private void Awake()
    {
        _PlayerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _PlayerControls.Enable();
    }

    private void OnDisable()
    {
        _PlayerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        movementInput = _PlayerControls.Land.move.ReadValue<float>();

        //_PlayerControls.Land.Jump
        

    }

    public PlayerControls GetPlayerControls()
    {
        return _PlayerControls;
    }
}

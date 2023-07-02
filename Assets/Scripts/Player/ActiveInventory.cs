using System;
using UnityEngine;

public class ActiveIventory : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject[] spells;
    private int activeSlotIndexNumber = 0;
    private GameInput gameInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Start()
    {
        gameInput = GameObject.FindGameObjectWithTag(Tags.T_GameInput).GetComponent<GameInput>();
        //gameInput.GetInventorySlotNumber();
        //TODO: switch to game input
        playerInput.Player.inventory_keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>() - 1);
    }

    private void ToggleActiveSlot(int number)
    {
        ChangeActiveSpell((MonoBehaviour)spells[number].GetComponent(typeof(MonoBehaviour)));
    }

    private void ToggleActiveHighlight(int number)
    {

    }

    private void ChangeActiveSpell(MonoBehaviour spell)
    {
        ActiveSpell.INSTANCE.NewSpell(spell);
    }
}
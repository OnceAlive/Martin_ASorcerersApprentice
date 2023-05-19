using UnityEngine;

public class ActiveIventory : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private int activeSlotIndexNumber = 0;

    private void Start()
    {
        playerInput.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>() - 1);
    }

    private void ToggleActiveSlot(int number)
    {
        ToggleActiveHighlight(number);
    }

    private void ToggleActiveHighlight(int number)
    {

    }

    private void ChangeActiveSpell()
    {
        //TODO
    }
}
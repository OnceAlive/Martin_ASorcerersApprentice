using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float restoreDefaultMaterialTime = .2f;

    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;

    public float GetRestoreDefaultMaterialTime => restoreDefaultMaterialTime;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(restoreDefaultMaterialTime);
        spriteRenderer.material = defaultMaterial;
    }
}
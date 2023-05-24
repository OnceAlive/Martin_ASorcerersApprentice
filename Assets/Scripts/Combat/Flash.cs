using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float restoreDefaultMaterialTime = .2f;
    [SerializeField] private SpriteRenderer martinRenderer;
    
    private Material defaultMaterial;

    public float GetRestoreDefaultMaterialTime => restoreDefaultMaterialTime;

    private void Awake()
    {
        defaultMaterial = martinRenderer.material;
    }

    public IEnumerator FlashRoutine()
    {
        martinRenderer.material = flashMaterial;
        yield return new WaitForSeconds(restoreDefaultMaterialTime);
        martinRenderer.material = defaultMaterial;
    }
}
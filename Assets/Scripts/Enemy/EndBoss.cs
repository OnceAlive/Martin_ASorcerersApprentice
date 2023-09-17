using UnityEngine;

public class EndBoss : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;
    private void OnDestroy()
    {
        Time.timeScale = 0f;
        victoryScreen.SetActive(true);
    }
}

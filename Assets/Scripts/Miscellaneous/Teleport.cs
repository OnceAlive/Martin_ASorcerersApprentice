using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.T_Player))
        {
            SceneManager.LoadScene("Dungeon");
        }
    }
}

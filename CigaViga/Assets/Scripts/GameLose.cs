using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLose : MonoBehaviour
{
    [SerializeField] float delayAfterLose = 2f;
    [SerializeField] ParticleSystem loseEffect;
    [SerializeField] Effector2D effector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            loseEffect.Play();
            effector.enabled = false;
            Invoke("RestartGame", delayAfterLose);
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Level0");
    }
}

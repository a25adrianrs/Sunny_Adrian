using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text itemsText;

    void Update()
    {
        int items = GameObject.FindGameObjectsWithTag("Gem").Length;
        itemsText.text = items.ToString();

        if (items == 0)
        {
            Invoke("RestartGame", 1f);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(ReturnToMainMenu);
        }
        else
        {
            Debug.LogError("Button component not found on ReturnToMenuButton script.");
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // add this to in game canvas

    [Header("Panels")]
    public GameObject panel;
    public GameObject losingPanel;

    bool isPanelActive = false;

    void Start()
    {
        panel.SetActive(false);
        losingPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (losingPanel.activeSelf)
            {
                Debug.Log("Game is over, cannot pause.");
                return; // do not allow pausing if game is over
            }

            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        isPanelActive = !isPanelActive;

        // toggle panel
        panel.SetActive(isPanelActive);

        // toggle cursor
        if (isPanelActive)
        {
            Cursor.visible = true;
            Time.timeScale = 0f; // pause game
            Debug.Log("Game Paused");
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1f; // resume game
            Debug.Log("Game Resumed");
        }
    }


}

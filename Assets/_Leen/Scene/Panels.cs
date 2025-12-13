using UnityEngine;

public class Panels : MonoBehaviour
{
    // this is for How To scene
    [Header("Page 1")]
    [SerializeField] GameObject p1Panel = null;
    [SerializeField] GameObject nextButton = null;
    
    [Header("Page 2")]
    [SerializeField] GameObject p1PanelP2 = null;
    [SerializeField] GameObject p1P2Buttons = null;
    [SerializeField] GameObject p1PanelP2Items = null;

    [Header("Page 3")]
    [SerializeField] GameObject p2Panel = null;
    [SerializeField] GameObject backButton = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // when you open How to scene it will always show p1 first
        p1Panel.SetActive(true);
        nextButton.SetActive(true);

        p1PanelP2.SetActive(false);
        p1P2Buttons.SetActive(false);
        p1PanelP2Items.SetActive(false);

        p2Panel.SetActive(false);
        backButton.SetActive(false);
    }

}

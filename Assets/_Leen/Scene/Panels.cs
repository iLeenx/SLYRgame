using UnityEngine;

public class Panels : MonoBehaviour
{
    // this is for How To scene

    [SerializeField] GameObject p1Panel = null;
    [SerializeField] GameObject p2Panel = null;
    [SerializeField] GameObject nextButton = null;
    [SerializeField] GameObject backButton = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // when you open How to scene it will always show p1 first
        p1Panel.SetActive(true);
        nextButton.SetActive(true);
        p2Panel.SetActive(false);
        backButton.SetActive(false);
    }

}

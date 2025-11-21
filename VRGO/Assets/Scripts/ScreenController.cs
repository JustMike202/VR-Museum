using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowScreen1();
    }

    public void ShowScreen1()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
    }
    public void ShowScreen2()
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
        screen3.SetActive(false);
    }
    public void ShowScreen3()
    {
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(true);
    }

}

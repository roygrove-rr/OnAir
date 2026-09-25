using UnityEngine;

public class CreditsButtonInfo : MonoBehaviour
{
    public GameObject[] panels;

    void Awake()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
}
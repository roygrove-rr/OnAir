using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossPatience : MonoBehaviour
{
    public float patienceInit = 400f;
    public float patience = 400f;
    public MalfManager malfManager;
    public TextMeshProUGUI patienceUI;
    public TextMeshProUGUI firstWarningUI;
    public TextMeshProUGUI finalWarningUI;
    public TextMeshProUGUI killCounterUI;

    private float killMeter;
    public float killCounter;

    private bool warned1 = false;
    private bool warned2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        killMeter = (patience * 0.03f + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        patienceUI.text = patience.ToString();
        
        if (malfManager.malfHappening == true)
        {
            patience -= (Time.deltaTime * malfManager.malfNum);

            killCounter += Time.deltaTime;
            killMeter = (patience * 0.03f + 5f);
            killCounterUI.text = killCounter.ToString() + "/" + killMeter.ToString();
            if (killCounter >= killMeter)
            {
                killCounterUI.text = "Dead";
                kill();
            }
        }
        else
        {
            killCounter = 0;
            killCounterUI.text = killCounter.ToString() + "/" + killMeter.ToString();
        }

        if (patience <= (patienceInit / 2) && warned1 == false)
        {
            Debug.Log("First warning");
            firstWarningUI.text = "warning 1";
            warned1 = true;
        }

        if (patience <= (patienceInit / 5) && warned2 == false)
        {
            Debug.Log("Final warning");
            finalWarningUI.text = "warning 2";
            warned2 = true;
        }
    }

    void FirstWarning()
    {
        
    }

    void FinalWarning()
    {
        
    }

    void kill()
    {
        malfManager.active = false;
    }
}

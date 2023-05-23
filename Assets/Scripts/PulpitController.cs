using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpitController : MonoBehaviour
{
    private Vector3 currPos;
    private bool isCreated;
    private bool isBroken;
    private bool isTimerRunning;
    private int randDir;
    private float time = 5;

    public TextMesh timerText;
    
    public GameObject pulpitPrefab;
    void Start()
    {
        currPos = this.transform.position;
        timerText.text = time.ToString();
    }

    void Update()
    {
        if(!isBroken)
        {
            if(!isTimerRunning)
                StartCoroutine(Timer());
            else
                TimerFunction();
        }
        else
        {
            CreatePulpit();
        }
    }

    void CreatePulpit()
    {
        if(!isCreated)
        {
            Vector3 newPulpitLeft = new Vector3 (currPos.x - 9, currPos.y, currPos.z);
            Vector3 newPulpitRight = new Vector3 (currPos.x + 9, currPos.y, currPos.z);
            Vector3 newPulpitUp = new Vector3 (currPos.x, currPos.y, currPos.z + 9);
            Vector3 newPulpitDown = new Vector3 (currPos.x, currPos.y, currPos.z - 9);

            randDir = Random.Range(1,5);

            if(randDir == PrevPulpit.prevDir)
            {
                randDir = Random.Range(1,5);
            }
            else
            {
                isBroken = false;
                isCreated = true;
                switch(randDir)
                {
                    case 1:
                            PrevPulpit.prevDir = 2;
                            Instantiate(pulpitPrefab, newPulpitLeft, transform.rotation);
                            currPos = this.transform.position;
                            break;
                    case 2:
                            PrevPulpit.prevDir = 1;
                            Instantiate(pulpitPrefab, newPulpitRight, transform.rotation);
                            currPos = this.transform.position;
                            break;
                    case 3:
                            PrevPulpit.prevDir = 4;
                            Instantiate(pulpitPrefab, newPulpitUp, transform.rotation);
                            currPos = this.transform.position;
                            break;
                    case 4:
                            PrevPulpit.prevDir = 3;
                            Instantiate(pulpitPrefab, newPulpitDown, transform.rotation);
                            currPos = this.transform.position;
                            break;
                }
            }
        }
    }

    IEnumerator Timer()
    {
        //way 1
        isTimerRunning = true;
        yield return new WaitForSeconds(3f);
        isBroken = true;
        yield return new WaitForSeconds(2f);
        DestroyPulpit();
        isTimerRunning = false;
    }

    void TimerFunction()
    {
        isTimerRunning = true;
        //time = 5;
        if(time>0)
        {
            timerText.text = time.ToString("0.00");
            time -= Time.deltaTime;
        }
        else
            time = 0;
    }

    void DestroyPulpit()
    {
        Destroy(this.gameObject);
    }
}

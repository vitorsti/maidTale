using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RythemMiniGameManager : MonoBehaviour
{
    public GameObject minigame;
    public GameObject prefab;
    public GameObject location;
    public NoteBehavior[] pool;
    public List<GameObject> activeNotes, waitingNotes;
    public int poolLength = 10;

    public static RythemMiniGameManager instance;
    [SerializeField]
    int scoreDefault;
    [SerializeField]
    int score;
    [SerializeField]
    TextMeshProUGUI uiText;
    string taskObject;

    [Header("Debugger")]
    [SerializeField]
    bool startSpawn;
    private void OnValidate()
    {
        if (startSpawn)
        {
            StartMiniGame();
            startSpawn = false;
        }
    }
    private void OnEnable()
    {
        //score = scoreDefault;
        //StartCoroutine(MiniGameBegin());
        //InvokeRepeating("Spawn", 1f, 1f);
        
    }
    private void Awake()
    {
        instance = this;
        StartCoroutine(SpawnPool());
    }

    public void StartMiniGame()
    {
        Debug.Log("0");
        GameManager.instace.SetState(GameManager.GameState.interaction);
        Debug.Log("1");
        score = scoreDefault;
        Debug.Log("2");
        minigame.SetActive(true);
        Debug.Log("3");
        StartCoroutine(MiniGameBegin());
        Debug.Log("4");
    }
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawn",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (minigame.activeInHierarchy == true)
        {
            if (Input.GetButton("VERDE0") && NoteDetector.instance.GetInside())
            {
                //inside = false;
                NoteDetector.instance.SetInside(false);
                RemoveScore();
                NoteDetector.instance.DestroyNote();
            }

            if (Input.GetButton("VERMELHO0"))
            {
                CloseGame();
            }
        }
    }

    IEnumerator Spawn()
    {
        int index = waitingNotes.Count - 1;
        Debug.Log(index);
        yield return new WaitForSeconds(0.1f);
        while (index > 0)
        {
            waitingNotes[index].GetComponent<NoteBehavior>().enabled = true;
            waitingNotes[index].GetComponent<NoteBehavior>().StartBehavior();
            waitingNotes[index].GetComponent<NoteBehavior>().SetIndex(0);
            activeNotes.Add(waitingNotes[index]);
            waitingNotes[index].GetComponent<NoteBehavior>().SetIndex(index);

            waitingNotes.RemoveAt(index);
            
            index--;
            Debug.Log(index);
            yield return new WaitForSeconds(1f);
        }
        yield return null;

        //Instantiate(prefab, location.transform.position, Quaternion.identity, this.transform);
    }
    public void RemoveScore()
    {
        score -= 1;
        uiText.text = score.ToString();
        Debug.Log(score);
        if (score <= 0)
        {
            score = 0;
            uiText.text = score.ToString();
            StartCoroutine(MiniGameEnd());
        }
    }
    IEnumerator MiniGameBegin()
    {
        uiText.text = "3...";
        yield return new WaitForSeconds(0.5f);
        uiText.text = "2...";
        yield return new WaitForSeconds(0.5f);
        uiText.text = "1...";
        yield return new WaitForSeconds(0.5f);
        uiText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        uiText.text = "";
        //InvokeRepeating("Spawn", 0f, 1f);
        StartCoroutine( Spawn());
        //StartCoroutine(SpawnPool());
        yield return null;
    }

    IEnumerator MiniGameEnd()
    {

        uiText.text = "End";
        yield return new WaitForSeconds(0.8f);
        uiText.text = "";
        GameOver();
        yield return null;
    }

    public void GameOver()
    {
        GameManager.instace.SetState(GameManager.GameState.play);
        TaskManager.instance.RemoveTask();
        
        NoteBehavior[] notes = FindObjectsOfType<NoteBehavior>();
        foreach (NoteBehavior i in notes)
        {
            DestroyImmediate(i.gameObject);
        }
        CancelInvoke();
        StopAllCoroutines();
        //minigame.SetActive(false);
        GameObject task = GameObject.Find(taskObject);
        DestroyImmediate(task);
        taskObject = "";
        minigame.SetActive(false);
    }

    public void CloseGame()
    {
        GameManager.instace.SetState(GameManager.GameState.play);
        TaskManager.instance.RemoveTask();
        CancelInvoke();
        StopAllCoroutines();
        NoteBehavior[] notes = FindObjectsOfType<NoteBehavior>();
        foreach (NoteBehavior i in notes)
        {
            DestroyImmediate(i.gameObject);
        }
        taskObject = "";
        minigame.SetActive(false);
    }

   public void SetObjectName(string value)
    {
        taskObject = value;
    }

    IEnumerator SpawnPool()
    {
        int index = poolLength;
        yield return new WaitForSeconds(0f);
        Debug.Log(index);
       while(index>0)
        {
            
            GameObject go = Instantiate(prefab, location.transform.position, Quaternion.identity, this.transform);
            go.GetComponent<NoteBehavior>().enabled = false;
            waitingNotes.Add(go);
            index--;
            yield return new WaitForSeconds(0f);
            Debug.Log(index);   
        }
        pool = FindObjectsOfType<NoteBehavior>();
        yield return null;
    }

    public void ResetNote(GameObject note, int value)
    {
        activeNotes.RemoveAt(value);
        note.GetComponent<NoteBehavior>().enabled = false;
        note.transform.position = location.transform.position;
        waitingNotes.Add(note);
    }
    
}

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
    public Slider slider;
    enum MiniGameState { play, stop }
    [SerializeField]
    private MiniGameState state;
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
        SetSlide();
        state = MiniGameState.play;
        //Debug.Log("0");
        GameManager.instace.SetState(GameManager.GameState.interaction);
       // Debug.Log("1");
        score = scoreDefault;
       // Debug.Log("2");
        minigame.SetActive(true);
      // Debug.Log("3");
        StartCoroutine(MiniGameBegin());
       // Debug.Log("4");
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
            if (Input.GetButtonDown("VERDE0") && NoteDetector.instance.GetInside())
            {
                //inside = false;
                NoteDetector.instance.SetInside(false);
                RemoveScore();
                ResetNote(NoteDetector.instance.GetNote());
                NoteDetector.instance.DestroyNote();
            }

            if (Input.GetButtonDown("VERDE0") && !NoteDetector.instance.GetInside())
            {
                UpdateSlider(false);
            }

            if (Input.GetButtonDown("VERMELHO0"))
            {
                CloseGame();
            }
        }
    }

    IEnumerator Spawn()
    {
        int index = waitingNotes.Count - 1;

        Debug.Log(index);
        yield return new WaitForSeconds(0f);
        while (index > -1)
        {
            waitingNotes[index].GetComponent<NoteBehavior>().enabled = true;
            waitingNotes[index].GetComponent<NoteBehavior>().StartBehavior();
            waitingNotes[index].GetComponent<NoteBehavior>().SetIndex(0);
            activeNotes.Add(waitingNotes[index]);
            waitingNotes[index].GetComponent<NoteBehavior>().SetIndex(index);
            //Debug.Log("index seted was: " + index);

            waitingNotes.RemoveAt(index);

            index--;
            //Debug.Log(index);
            yield return new WaitForSeconds(Random.Range(0.8f, 1.8f));
        }
        yield return null;

        //Instantiate(prefab, location.transform.position, Quaternion.identity, this.transform);
    }
    public void RemoveScore()
    { 
        UpdateSlider(true);
        score -= 1;
        uiText.text = score.ToString();
       // Debug.Log(score);
        if (score <= 0)
        {
            score = 0;
            uiText.text = score.ToString();
            //StartCoroutine(MiniGameEnd(true));
        }
       
    }
    void SetSlide()
    {
        slider.minValue = score - scoreDefault;
        slider.maxValue = scoreDefault;
        slider.value = score;
    }
    public void UpdateSlider(bool value)
    {
        Debug.Log(value);
        if (value)
        {
            Debug.Log("added slider");
            slider.value+=1;
            Debug.Log(slider.value);
        }
        else
            slider.value-=1;

        if (slider.value == slider.maxValue)
        {
            slider.value = slider.maxValue;

            StartCoroutine(MiniGameEnd(true));

        }

        if (slider.value <= slider.minValue)
        {
            slider.value = slider.minValue;

            StartCoroutine(MiniGameEnd(false));

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
        StartCoroutine(Spawn());
        //StartCoroutine(SpawnPool());
        yield return null;
    }

    IEnumerator MiniGameEnd(bool value)
    {
        //win
        if (value)
        {
            uiText.text = "You Win!";
            yield return new WaitForSeconds(0.5f);
            state = MiniGameState.stop;
            GameOver();
            uiText.text = "";
        }

        //loose
        if (!value)
        {
            uiText.text = "You loose!";
            yield return new WaitForSeconds(0.5f);
            state = MiniGameState.stop;
            GameOver();
            uiText.text = "";
        }
        yield return null;
    }

    public void GameOver()
    {

        GameManager.instace.SetState(GameManager.GameState.play);
        TaskManager.instance.RemoveTask();

        /*NoteBehavior[] notes = FindObjectsOfType<NoteBehavior>();
        foreach (NoteBehavior i in notes)
        {
            DestroyImmediate(i.gameObject);
        }*/
        StopAllCoroutines();
        ResetGame();

        //CancelInvoke();

        //minigame.SetActive(false);
        GameObject task = GameObject.Find(taskObject);
        if (task != null)
        {
            DestroyImmediate(task);
            taskObject = "";
        }
        minigame.SetActive(false);
        StopAllCoroutines();
    }

    public void CloseGame()
    {
        state = MiniGameState.stop;
        GameManager.instace.SetState(GameManager.GameState.play);
        TaskManager.instance.RemoveTask();
        //CancelInvoke();
        StopAllCoroutines();

        ResetGame();

        if (taskObject != null)
            taskObject = "";
        minigame.SetActive(false);
        StopAllCoroutines();
    }

    public void SetObjectName(string value)
    {
        taskObject = value;
    }

    IEnumerator SpawnPool()
    {
        int index = poolLength;
        yield return new WaitForSeconds(0);
        //Debug.Log(index);
        while (index > 0)
        {

            GameObject go = Instantiate(prefab, location.transform.position, Quaternion.identity, this.transform);
            go.GetComponent<NoteBehavior>().enabled = false;
            waitingNotes.Add(go);
            index--;
            yield return new WaitForSeconds(0f);
            //Debug.Log(index);
        }
        pool = FindObjectsOfType<NoteBehavior>();
        yield return null;
    }
    private void ResetGame()
    {
        if (waitingNotes.Count > 20)
            return;
        if (activeNotes.Count != 0)
        {

            for (int i = 0; i < activeNotes.Count; i++)
            {
                //ResetNote(activeNotes[i]);
                activeNotes[i].GetComponent<NoteBehavior>().Stop();
                activeNotes[i].GetComponent<NoteBehavior>().enabled = false;
                activeNotes[i].transform.position = location.transform.position;
                waitingNotes.Add(activeNotes[i]);

            }

            activeNotes.Clear();

        }
        else
        {

            for (int i = 0; i < waitingNotes.Count; i++)
            {
                waitingNotes[i].GetComponent<NoteBehavior>().Stop();
                waitingNotes[i].GetComponent<NoteBehavior>().enabled = false;
                waitingNotes[i].transform.position = location.transform.position;
                //waitingNotes.Add(activeNotes[i]);

            }
        }
        StopAllCoroutines();
    }
    public void ResetNote(GameObject note)
    {
        if (waitingNotes.Count > 20)
            return;
        if (state == MiniGameState.play)
        {
            activeNotes.Remove(note);
            note.GetComponent<NoteBehavior>().enabled = false;
            note.transform.position = location.transform.position;
            waitingNotes.Add(note);


            if (activeNotes.Count == 0)
            {
                StartCoroutine(Spawn());
            }
        }
        else
        {
            StopAllCoroutines();
        }

    }
}

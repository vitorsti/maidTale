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
    public static RythemMiniGameManager instance;
    [SerializeField]
    int scoreDefault;
    [SerializeField]
    int score;
    [SerializeField]
    TextMeshProUGUI uiText;
    private void OnEnable()
    {
        //score = scoreDefault;
        //StartCoroutine(MiniGameBegin());
        //InvokeRepeating("Spawn", 1f, 1f);
    }
    private void Awake()
    {
        instance = this;
    }

    public void StartMiniGame()
    {
        score = scoreDefault;
        minigame.SetActive(true);
        StartCoroutine(MiniGameBegin());
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
        }
    }

    void Spawn()
    {
        Instantiate(prefab, location.transform.position, Quaternion.identity, this.transform);
    }
    public void RemoveScore()
    {
        score -= 1;
        Debug.Log(score);
        if (score <= 0)
        {
            score = 0;
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
        InvokeRepeating("Spawn", 0f, 1f);
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
        CancelInvoke();
        NoteBehavior[] notes = FindObjectsOfType<NoteBehavior>();
        foreach (NoteBehavior i in notes)
        {
            DestroyImmediate(i.gameObject);
        }

        minigame.SetActive(false);
    }
}

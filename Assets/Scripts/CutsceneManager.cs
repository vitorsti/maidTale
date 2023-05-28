using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    DialogueManager dialogueManager;
    [Header("---- Debug")]
    [SerializeField]
    private bool beginCutscene;
    [SerializeField]
    private Button buttonMenu, endButton;
    [SerializeField]
    private TextMeshProUGUI title;
    CutsceneLoaderContainer data;
    public static CutsceneManager instance;
    [SerializeField]
    GameObject endCutsceneScreen;
    string sceneToLoad;
    [SerializeField]
    bool sceneLoaderScene;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioSource source;
    
    private void OnValidate()
    {
        if (beginCutscene)
        {
            beginCutscene = false;
            dialogueManager.StartDialogue();
        }
    }
    private void Awake()
    {
        instance = this;
            data = Resources.Load<CutsceneLoaderContainer>("CutsceneLoaderData");
        source.Stop();
    }

    private void Update()
    {
       
        if (Input.GetButtonDown("VERDE0") && sceneLoaderScene )
        {
            buttonMenu.GetComponent<Button>().onClick.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        title.text = data.GetTitle();
        sceneToLoad = data.GetSceneToLoad();
        dialogueManager.SetAfinityAndDialogueData(data.GetCutsceneToLoadName(),data.GetAfinityToLoadName());
        //clip = data.GetClip();
        source.clip = data.GetClip();

    }
    public void OnBeginScene()
    {
        dialogueManager.StartDialogue();
        source.Play();
        source.loop = true;
    }
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.05f);
        dialogueManager.StartDialogue();
    }
    public void OnEndCutScene()
    {
        GameManager.instace.SetState(GameManager.GameState.play);

        endCutsceneScreen.SetActive(true);
        if (title.text == "Intro")
        {
            PlayerPrefs.SetInt("levels", 1);
        }
        //DialogueUiDisplay.
    }

  
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

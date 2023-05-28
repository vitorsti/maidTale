using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    [SerializeField]
    private GameObject[] tasksToComplete;
    [SerializeField]
    private int tasksQuantity;
    [SerializeField]
    private string afinityToLoad;
    [SerializeField]
    AfinityContainer afinityData;
    public GameObject dayCompleted;
    private void Awake()
    {
        instance = this;
#if UNITY_EDITOR
        //PlayerPrefs.SetString("LevelAfinity", "Augustus");
#endif
        afinityToLoad = PlayerPrefs.GetString("LevelAfinity", "");
        Debug.Log(afinityToLoad);
       /* var afinity = Resources.Load<AfinityContainer>("Afinities/" + afinityToLoad);

        if (afinity != null)
        {
            afinityData = afinity;
        }*/

        //if (tasksToComplete == null)
        
        
    }

    private void Start()
    {
        

       
    }

    public void SetThings()
    {
        StartCoroutine(Set());
    }
    IEnumerator Set()
    {
        var afinity = Resources.Load<AfinityContainer>("Afinities/" + afinityToLoad);

        if (afinity != null)
        {
            afinityData = afinity;
        }

        tasksToComplete = GameObject.FindGameObjectsWithTag("Task");
        yield return new WaitForSeconds(0.2f); 
        tasksQuantity = tasksToComplete.Length;
        yield return null;
    }
    public void RemoveTask()
    {
        if (tasksQuantity > 0)
        {
            afinityData.IncreaseAfinity(1f);
            tasksQuantity--;
            if (tasksQuantity <= 0)
            {
                tasksQuantity = 0;
                //dayCompleted.SetActive(true);
                GameObject end;
                end = GameObject.Find("EndDayButton");
                if(end!=null)
                end.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
                GameManager.instace.SetState(GameManager.GameState.cutscene);
            }
        }
    }

    public int GetTasksQuantity()
    {
        return tasksQuantity;
    }
}

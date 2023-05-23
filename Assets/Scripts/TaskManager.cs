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
    AfinityContainer afinityData;
    public GameObject dayCompleted;
    private void Awake()
    {
        instance = this;
        var afinity = Resources.Load<AfinityContainer>("Afinities/" + afinityToLoad);

        if (afinity != null)
        {
            afinityData = afinity;
        }

        //if (tasksToComplete == null)
        tasksToComplete = GameObject.FindGameObjectsWithTag("Task");

    }

    private void Start()
    {
        tasksQuantity = tasksToComplete.Length;
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
                dayCompleted.SetActive(true);
                GameManager.instace.SetState(GameManager.GameState.cutscene);
            }
        }
    }

    public int GetTasksQuantity()
    {
        return tasksQuantity;
    }
}

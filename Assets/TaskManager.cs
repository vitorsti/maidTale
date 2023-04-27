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
    private void Awake()
    {
        instance = this;

        //if (tasksToComplete == null)
        tasksToComplete = GameObject.FindGameObjectsWithTag("Task");

    }

    private void Start()
    {
        tasksQuantity = tasksToComplete.Length;
    }

    public void RemoveTask()
    {
        tasksQuantity--;
        if (tasksQuantity <= 0)
        {
            tasksQuantity = 0;
        }
    }

    public int GetTasksQuantity()
    {
        return tasksQuantity;
    }
}

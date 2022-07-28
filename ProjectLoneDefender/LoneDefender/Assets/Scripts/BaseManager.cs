using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    #region Singleton

    public static BaseManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Base;
}
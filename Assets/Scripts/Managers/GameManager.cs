using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instanace
    {
        get{ return _instance;}
    }
    #endregion
    private void Awake()
    {
        _instance = this;
    }

}

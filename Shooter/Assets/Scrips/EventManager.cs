using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class Int2Event : UnityEvent<int, int>
{

}

public class EventManager : MonoBehaviour
{
    #region signgleton

    public static EventManager current;

    void Awake()
    {
        if (current == null )
        {
            current = this;
        }
        else if (current != null)
        {
            Destroy(this);
        }
    }

    #endregion

    public Int2Event updateBulletEvent = new Int2Event();
}

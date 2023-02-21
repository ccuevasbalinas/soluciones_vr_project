using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "ScriptableEvents/New Event", order=0)]
public class ScriptableEvent : ScriptableObject
{
    private readonly List<IScriptableEventListener> _listeners = new ();

    public void RegiterListener(IScriptableEventListener listener)
    {
        // Check if the listener is registered or not (in case is registered, we do not want to register again)
        if(_listeners.Contains(listener)) return;
        _listeners.Add(listener);
    }

    public void UnregisterListener(IScriptableEventListener listener)
    {
        _listeners.Remove(listener);
    }

    // If something/someone does an action and need to notify it by registering its interest, will register as a listener
    // by this foreach.RaiseEvent().
    public void Raise()
    {
        var listeners = new List<IScriptableEventListener>(_listeners);
        foreach (var listener in listeners)
        {
            listener.RaiseEvent();
        }
    }

}

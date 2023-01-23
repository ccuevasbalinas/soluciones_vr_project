using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour, IScriptableEventListener
{
    [SerializeField] private ScriptableEvent _scriptableEvent;
    [field: SerializeField] public UnityEvent OnEventRaised{ get; private set; }


    // By the moment this is active, we register this scriptable event.
    private void OnEnable()
    {
        _scriptableEvent.RegiterListener(this);
    }

    // By the moment this is innactive, we unregister this scriptable event.
    private void OnDisable()
    {
        _scriptableEvent.UnregisterListener(this);
    }

    public void RaiseEvent()
    {
        OnEventRaised.Invoke();
    }

}

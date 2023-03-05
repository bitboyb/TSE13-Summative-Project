using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour {

    public AK.Wwise.Event wwiseEvent;

    public void PostEvent ()
    {
        wwiseEvent.Post(gameObject);
    }
}

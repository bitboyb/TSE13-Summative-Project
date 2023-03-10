using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

namespace Audio
{
    public class GameStartAudio : MonoBehaviour
    {
        public List<string> gameStartEvents;
        public List<string> gameStopEvents;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var wwiseEvent in gameStartEvents)
            {
                AkSoundEngine.PostEvent(wwiseEvent, gameObject);
            }
        }

        private void OnDestroy()
        {
            foreach (var wwiseEvent in gameStopEvents)
            {
                AkSoundEngine.PostEvent(wwiseEvent, gameObject);
            }
        }
    }
}


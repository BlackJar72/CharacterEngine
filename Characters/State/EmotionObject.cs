using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kfutils.UI;
using System;


namespace CharacterModel {

    public class EmotionObject : ScriptableObject {
        [SerializeField] Emotion effect;
        [SerializeField] double duration;
        public Emotion Effect => effect;
        public double Duration => duration;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kfutils.UI;
using CharacterEngine;
using System;

namespace CharacterModel {

    public class Character {
        [SerializeField] Personality personality;
        [SerializeField] CoreNeeds needs;
        [SerializeField] EmotionalState emotions;
        [SerializeField] Preferences preferences;

        public Personality Persona => personality;
        public CoreNeeds Needs => needs;
        public EmotionalState Emotions;
        public Preferences prefs => preferences;

    }


}

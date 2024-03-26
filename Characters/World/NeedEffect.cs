using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static CharacterModel.ENeeds;


namespace CharacterModel {

    [Serializable]
    public class NeedEffect {
        [SerializeReference] readonly ENeeds need;
        [Tooltip ("How much it increases the need, should usually be small, well under 1.0f")]
        [SerializeField] [Range (0f, 1f)] readonly float effect;

        public ENeeds Need => need;
        public float Effect => effect;
    }
}
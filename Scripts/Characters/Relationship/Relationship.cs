using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    [System.Serializable]
    public struct Relationship {
        public long otherID;
        //??? should these be discrte integers (-100 to 100) of floating point (-1.0 to 1.0)?
        [Range(-100, 100)]
        public sbyte social;
        [Range(-100, 100)]
        public sbyte romantic;
    }

}

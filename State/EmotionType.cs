using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    public class EmotionType {
        public static readonly EEmotionType[] emotions = new EEmotionType[] {
            EEmotionType.CONNECTED, EEmotionType.SURPRISED, EEmotionType.FEAR, EEmotionType.SADNESS,
            EEmotionType.DISGUST, EEmotionType.ANGER, EEmotionType.INTERESTED, EEmotionType.HAPPY };

        public static EEmotionType GetTypeOfEmotion(Emotion emotion) {
            return emotions[(int)emotion.GetEmotionAngle() / 45];
        }


    }


    public enum EEmotionType {
        CONNECTED,
        SURPRISED,
        FEAR,
        SADNESS,
        DISGUST,
        ANGER,
        INTERESTED,
        HAPPY
    }

}
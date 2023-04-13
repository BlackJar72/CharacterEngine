using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    public class EmotionType {
        public const float RAD2EMO = 1.0f / 0.785398163398f;
        public static readonly EEmotionType[] emotions = new EEmotionType[] {
            EEmotionType.FEAR,       EEmotionType.SADNESS, EEmotionType.DISGUST,   EEmotionType.ANGER,
            EEmotionType.INTERESTED, EEmotionType.HAPPY,   EEmotionType.CONNECTED, EEmotionType.SURPRISED };


        public static EEmotionType GetTypeOfEmotion(Emotion emotion) {
            if(!((emotion.Positivity == 0) && (emotion.Avoidance == 0)))
                return emotions[(int)(emotion.GetEmotionAngle() * RAD2EMO)];
            else return EEmotionType.HAPPY;
        }


    }


    public enum EEmotionType {
        FEAR,
        SADNESS,
        DISGUST,
        ANGER,
        INTERESTED,
        HAPPY,
        CONNECTED,
        SURPRISED
    }

}
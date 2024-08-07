using UnityEngine;
using CharacterEngine;


namespace CharacterModel {

    public class EmotionalState {
        private Emotion emotion = new Emotion();
        private Emotion target  = new Emotion();
        private EmotionalEffects effects = new EmotionalEffects();


#region Wrappers
        public float Positivity => emotion.Positivity;
        public float Avoidance  => emotion.Avoidance;
        public float Strength   => emotion.Strength;
        public float Joy        => emotion.Joy;

        public Color GetColor(float emoWellbeing) => emotion.GetColor(emoWellbeing);
        public Emotion.EmotionPacket RetrieveData(float emoWellbeing) => emotion.RetrieveData(emoWellbeing);
        public float GetEmotionAngle() => emotion.GetEmotionAngle();
        public float MagnitudeSq() => emotion.MagnitudeSq();
        public float Magnitude => emotion.Strength;
        public float Dot(Emotion a, Emotion b) => emotion.Dot(a, b);
        public void SetEmotion(float positivity, float avoidance) => emotion.Set(positivity, avoidance);
        public void BoundCircular() => emotion.BoundCircular();
        public void BoundSimple() => emotion.BoundSimple();
#endregion


        public void AddEmotion(EmotionEffect effect) {
            emotion += effect.Effect;
            target  += effect.Effect;
            effects.AddEffect(effect.Effect, effect.Duration);
        }


        public void AddEmotion(EmotionObject effect) {
            emotion += effect.Effect;
            target  += effect.Effect;
            effects.AddEffect(effect.Effect, effect.Duration);
        }


        public void EmoUpdate() {
            Emotion removed = effects.Update();
            target -= removed;
            emotion.TrackTarget(target);
        }


    }

}

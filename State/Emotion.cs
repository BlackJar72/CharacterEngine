using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kfutils.UI;
using CharacterModel;
using System;


namespace CharacterModel {

    /// <summary>
    /// Based loosely on Plutnicks color wheel of emotions, but with some liberties to have
    /// it work better and make more sense ase a game.  Notably, fear and surprize are swaped
    /// and the positive axis goes through "love."
    /// </summary>
    public struct Emotion : IUIDataProvider<(Color color, EEmotionType type)> {

        // Some directional units
        const float SQRT2  = 0.707106781187f;
        const float COS225 = 0.923879532511f;
        const float SIN225 = 0.382683432365f;
        const float TWOPI  = 3.14159265359f * 2.0f;

        public static Emotion operator+(Emotion a, Emotion b)
                => new Emotion(a.positivity + b.positivity, a.avoidance + b.avoidance);
        public static Emotion operator-(Emotion a, Emotion b)
                => new Emotion(a.positivity - b.positivity, a.avoidance - b.avoidance);
        public static Emotion operator*(Emotion a, Emotion b)
                => new Emotion(a.positivity * b.positivity, a.avoidance * b.avoidance);
        public static Emotion operator+(Emotion a, float b)
                => new Emotion(a.positivity * b, a.avoidance * b);
        public static Emotion operator/(Emotion a, Emotion b)
                => new Emotion(a.positivity / b.positivity, a.avoidance / b.avoidance);
        public static Emotion operator/(Emotion a, float b)
                => new Emotion(a.positivity / b, a.avoidance / b);


        //Data
        float positivity, avoidance;

        public float Positivity => positivity;
        public float Avoidance  => avoidance;
        public float Strength   => Mathf.Sqrt((positivity * positivity) + (avoidance * avoidance));


        public Color GetColor() {
            float hue = GetEmotionColorAngle();
            float strength = Magnitude();
            float saturation = Mathf.Clamp(Strength, 0.0f, 1.0f);
            float value = Mathf.Clamp(((Strength * 0.25f) + 0.5f), 0.5f, 1.0f);
            return Color.HSVToRGB(hue, saturation, value);
        }


        public ValueTuple<Color, EEmotionType> RetrieveData() {
            return (color: GetColor(), type: EmotionType.GetTypeOfEmotion(this));
        }


        // Emotional Axes
        static readonly Emotion UPOSITIVE   = new Emotion( 1, 0);
        static readonly Emotion UAVOIDANCE  = new Emotion( 0, 1);

        // Unit feeling vectors -- primary
        static readonly Emotion UHAPPY  = new Emotion( COS225, -SIN225);
        static readonly Emotion UTRUST  = new Emotion( COS225,  SIN225);
        static readonly Emotion UAMAZE  = new Emotion( SIN225,  COS225);
        static readonly Emotion UFEAR   = new Emotion(-SIN225,  COS225);
        static readonly Emotion USAD    = new Emotion(-COS225,  SIN225);
        static readonly Emotion UGROSS  = new Emotion(-COS225, -SIN225);
        static readonly Emotion USRAGE  = new Emotion(-SIN225, -COS225);
        static readonly Emotion UFOCUS  = new Emotion( SIN225, -COS225);

        // Unit feeling vectors -- secondary
        static readonly Emotion ULOVE   = new Emotion( 1, 0);
        static readonly Emotion USUB    = new Emotion( SQRT2,  SQRT2);
        static readonly Emotion UAWE    = new Emotion( 0,  1);
        static readonly Emotion UNOLIKE = new Emotion(-SQRT2, SQRT2);
        static readonly Emotion UBAD    = new Emotion(-1,  0);
        static readonly Emotion UHATE   = new Emotion(-SQRT2, -SQRT2);
        static readonly Emotion UAGRRO  = new Emotion(0,  -1);
        static readonly Emotion UHOPE   = new Emotion( SQRT2,  -SQRT2);


        public Emotion(float positivity, float avoidance) {
            this.positivity = positivity;
            this.avoidance = avoidance;
        }


        public float GetEmotionAngle() {
            return  Mathf.Atan2(avoidance, positivity);
        }


        public float GetEmotionColorAngle() {
            float angle = Mathf.Atan2(avoidance, positivity)  / TWOPI;
            angle += 0.5f;
            if(angle > 1.0f) angle -= 1.0f;
            return 1.0f - angle;
        }


        public float MagnitudeSq() {
            return (positivity * positivity) + (avoidance * avoidance);
        }


        public float Magnitude() {
            return Mathf.Sqrt((positivity * positivity) + (avoidance * avoidance));
        }


        public float Dot(Emotion a, Emotion b) {
            return ((a.positivity * b.positivity) + (a.avoidance * b.avoidance));
        }

    }

}

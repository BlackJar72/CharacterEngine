using System;


namespace CharacterModel.UI {


    public class UICollater {
        Emotion emotion;
        CoreNeeds needs;


        // FIXME / TODO: Pass in the relevant UI controller to receive data
        public void GetData() {
            CoreNeeds.NeedsPacket needData = needs.RetrieveData();
            Emotion.EmotionPacket emotionData = emotion.RetrieveData(needData.psychWellbeing);
        }


    }


}
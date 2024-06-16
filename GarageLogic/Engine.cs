public class Engine
    {
        public float MaxEnergy { get; set; }
        public float CurrentEnergy
        {
            get { return CurrentEnergy; }
            set
            {
                if (value <= MaxEnergy)
                {
                    CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy);
                }
            }
        }
    }
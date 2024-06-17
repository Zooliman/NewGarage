public class Wheel
    {
        private float m_CurrentAirPressure;
        public float MaxAirPressure { get; set; }
        public string ManufacturerName { get; set; }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value <= MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxAirPressure);
                }
            }
        }

        public void Inflate(float i_AmountOfAirPressureToAdd)
        {
            if (CurrentAirPressure + i_AmountOfAirPressureToAdd <= MaxAirPressure)
            {
                CurrentAirPressure += i_AmountOfAirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - CurrentAirPressure);
            }
        }

        public void InflateWheelToMax()
        {
            Inflate(MaxAirPressure - CurrentAirPressure);
        }

        public override string ToString()
        {
            return string.Format("Manufacturer Name: {0}, Current Air Pressure: {1}, Max Air Pressure: {2}", ManufacturerName, CurrentAirPressure, MaxAirPressure);
        }
    }
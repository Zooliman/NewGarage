
public class Wheel
{

    public Wheel(float i_MaxAirPressure)
    {
        MaxAirPressure = i_MaxAirPressure;
    }
    public string ManufacturerName { get; set; }
    public float CurrentAirPressure
    {
        get { return CurrentAirPressure; }
        set
        {
            if (value <= MaxAirPressure)
            {
                CurrentAirPressure = value;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }
        }
    }   
    public float MaxAirPressure { get; set; }
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
}
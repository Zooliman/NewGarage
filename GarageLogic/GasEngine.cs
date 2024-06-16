
public class GasEngine : Engine
{
    public eGasType GasType { get; set; }
    public void Fuel(float i_GasAmountToAdd, eGasType i_GasType)
    {
        if (i_GasType == GasType)
        {
            if (i_GasAmountToAdd + CurrentEnergy <= MaxEnergy)
            {
                CurrentEnergy += i_GasAmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
            }
        }
        else
        {
            throw new ArgumentException("Wrong gas type");
        }
    }
}

public enum eGasType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
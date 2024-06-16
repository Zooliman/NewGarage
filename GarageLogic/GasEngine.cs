public class GasEngine : Engine
    {
        public Enums.eGasType? GasType { get; set; }
        public void Fuel(float i_GasAmountToAdd, Enums.eGasType i_GasType)
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
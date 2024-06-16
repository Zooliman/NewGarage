
public class ElectricEngine : Engine
{
    
    public void ChargeBattery(float i_AmountToCharge)
    {
        if (CurrentEnergy + i_AmountToCharge <= MaxEnergy)
        {
            CurrentEnergy += i_AmountToCharge;
        }
        else
        {
            throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
        }
    }
}
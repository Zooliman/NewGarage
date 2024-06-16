
public class ValueOutOfRangeException : Exception
{    
    private string m_Message;
    private float m_MaxValue;
    private float m_MinValue;

    public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
    {
        m_MinValue = i_MinValue;
        m_MaxValue = i_MaxValue;
        m_Message = string.Format("Value is out of range. Please enter a value between {0} to {1}.", i_MinValue, i_MaxValue);
    }

    public override string Message
    {
        get { return m_Message; }
    }


}
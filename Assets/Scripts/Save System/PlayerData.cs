[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float batteryStatus;
    public float[] rotation;

    public PlayerData(float[] position, float[] rotation, float batteryStatus)
    {
        this.position = position;
        this.batteryStatus = batteryStatus;
        this.rotation = rotation;
    }
}

// Swimming.cs
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthKm = 0.05;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthKm;
    public override double GetSpeed() => GetDistance() / LengthInMinutes * 60;
    public override double GetPace() => LengthInMinutes / GetDistance();
}
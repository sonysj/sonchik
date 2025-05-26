using RepairService;

public class Television : Device
{
    public int ScreenSize { get; set; }
    public string MatrixType { get; set; }
    public string BacklightType { get; set; }

    public Television(string name, string manufacturer, string serialNumber, int screenSize, string matrixType, string backlightType)
    : base(name, manufacturer, serialNumber)
    {
        ScreenSize = screenSize;
        MatrixType = matrixType;
        BacklightType = backlightType;
    }
    public override string[] GetInfo()
    {
        var info = new string[4];
        var deviceInfo = base.GetInfo();

        info[0] = deviceInfo[0];
        info[1] = deviceInfo[1];
        info[2] = $"Диагональ экрана: {ScreenSize} дюймов";
        info[3] = $"Тип матрицы: {MatrixType}. Тип подсветки: {BacklightType}.";

        return info;
    }
}
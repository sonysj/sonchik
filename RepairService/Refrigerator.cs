using RepairService;

public class Refrigerator : Device
{
    public int NumberOfCompartments { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int Depth { get; set; }

    public Refrigerator(string name, string manufacturer, string serialNumber, int numberOfCompartments, int height, int width, int depth)
    : base(name, manufacturer, serialNumber)
    {
        NumberOfCompartments = numberOfCompartments;
        Height = height;
        Width = width;
        Depth = depth;
    }
    public override string[] GetInfo()
    {
        var info = new string[4];
        var deviceInfo = base.GetInfo();

        info[0] = deviceInfo[0];
        info[1] = deviceInfo[1];
        info[2] = $"Количество камер: {NumberOfCompartments}";
        info[3] = $"Высота: {Height} см, ширина: {Width} см, глубина: {Depth} см";

        return info;
    }
}
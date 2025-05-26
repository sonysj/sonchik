using RepairService;

[TestFixture]
public class DeviceUnitTests
{
    [Test]
    public void ConstructorTest()
    {
        string name = "Телевизор";
        string manufacturer = "Samsung";
        string serialNumber = "SN123456";

        var device = new Device(name, manufacturer, serialNumber);

        Assert.That(device.Name, Is.EqualTo(name));
        Assert.That(device.Manufacturer, Is.EqualTo(manufacturer));
        Assert.That(device.SerialNumber, Is.EqualTo(serialNumber));
    }

    [Test]
    public void GetInfoTest()
    {
        var device = new Device("Телевизор", "Samsung", "SN123456")
        {
            RepairType = RepairType.Warranty,
            FaultDescription = "Не включается",
            RepairPrice = 0,
            TechnicianFullName = "Иванов И.И."
        };

        var info = device.GetInfo();

        Assert.That(info.Length, Is.EqualTo(2));
        Assert.That(info[0], Is.EqualTo("Устройство: Телевизор, Производитель: Samsung, " +
                                         "Серийный номер: SN123456, Тип ремонта: гарантийный"));
        Assert.That(info[1], Is.EqualTo("Описание неисправности: Не включается, " +
                                         "Цена ремонта: 0,00 C, Мастер: Иванов И.И."));
    }

    [Test]
    public void Television_PropertiesAreSetCorrectly()
    {
        var television = GetTelevision();
        Assert.That(television.ScreenSize, Is.EqualTo(40));
        Assert.That(television.MatrixType, Is.EqualTo("LED"));
        Assert.That(television.BacklightType, Is.EqualTo("Ambilight"));
    }

    private Television GetTelevision()
    {
        var television = new Television("Телевизор", "LG", "LG12345", 40, "LED", "Ambilight");
        television.RepairType = RepairType.Warranty;
        television.FaultDescription = "Не включается";
        television.RepairPrice = 0;
        television.TechnicianFullName = "Иванов И.И.";
        television.ScreenSize = 40;
        television.MatrixType = "LED";
        television.BacklightType = "Ambilight";
        return television;
    }

    [Test]
    public void GetInfo_Television_FourStringInfo()
    {
        var television = GetTelevision();
        var lines = new[]
        {
            "Устройство: Телевизор, Производитель: LG, " +
            $"Серийный номер: LG12345, Тип ремонта: гарантийный",
            $"Описание неисправности: Не включается, " +
            $"Цена ремонта: 0,00 C, Мастер: Иванов И.И.",
            "Диагональ экрана: 40 дюймов",
            "Тип матрицы: LED. Тип подсветки: Ambilight."
        };

        var info = television.GetInfo();

        Assert.That(info.Length, Is.EqualTo(4));

        for (var i = 0; i < info.Length; i++)
            Assert.That(info[i], Is.EqualTo(lines[i]));
    }

    [Test]
    public void Refrigerator_PropertiesAreSetCorrectly()
    {
        var refrigerator = GetRefrigerator();
        Assert.That(refrigerator.NumberOfCompartments, Is.EqualTo(3));
        Assert.That(refrigerator.Height, Is.EqualTo(200));
        Assert.That(refrigerator.Width, Is.EqualTo(55));
        Assert.That(refrigerator.Depth, Is.EqualTo(60));
    }

    private Refrigerator GetRefrigerator()
    {
        var refrigerator = new Refrigerator("Холодильник", "Bosch", "BH12345", 3, 200, 55, 60);
        refrigerator.RepairType = RepairType.Paid;
        refrigerator.FaultDescription = "Неисправный термостат";
        refrigerator.RepairPrice = 700;
        refrigerator.TechnicianFullName = "Петров П.П.";
        refrigerator.NumberOfCompartments = 3;
        refrigerator.Height = 200;
        refrigerator.Width = 55;
        refrigerator.Depth = 60;
        return refrigerator;
    }

    [Test]
    public void GetInfo_Refrigerator_FourStringInfo()
    {
        var refrigerator = GetRefrigerator();

        var lines = new[]
        {
            "Устройство: Холодильник, Производитель: Bosch, " +
            $"Серийный номер: BH12345, Тип ремонта: оплачиваемый",
            $"Описание неисправности: Неисправный термостат, " +
            $"Цена ремонта: 700,00 C, Мастер: Петров П.П.",
            "Количество камер: 3",
            "Высота: 200 см, ширина: 55 см, глубина: 60 см"
        };

        var info = refrigerator.GetInfo();

        Assert.That(info.Length, Is.EqualTo(4));

        for (var i = 0; i < info.Length; i++)
            Assert.That(info[i], Is.EqualTo(lines[i]));
    }
}
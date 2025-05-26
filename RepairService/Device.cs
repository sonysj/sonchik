using System;
using RepairService;

namespace RepairService
{
    public class Device : IComparable<Device>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public readonly string SerialNumber;
        public RepairType RepairType = RepairType.Warranty;
        public string FaultDescription = string.Empty;
        public decimal RepairPrice = 0.00m;
        public string TechnicianFullName = string.Empty;

        public Device(string name, string manufacturer, string serialNumber)
        {
            Name = name;
            Manufacturer = manufacturer;
            SerialNumber = serialNumber;
        }

        public virtual string[] GetInfo()
        {
            string repairTypeString = RepairType == RepairType.Warranty ? "гарантийный" : "оплачиваемый";
            var info = new string[2];

            info[0] = $"Устройство: {Name}, Производитель: {Manufacturer}, " +
                     $"Серийный номер: {SerialNumber}, Тип ремонта: {repairTypeString}";

            info[1] = $"Описание неисправности: {FaultDescription}, " +
                     $"Цена ремонта: {RepairPrice:0.00} C, Мастер: {TechnicianFullName}";

            return info;
        }

        public int CompareTo(Device? other)
        {
            if (other == null) return 1;

            int technicianComparison = string.Compare(TechnicianFullName, other.TechnicianFullName, StringComparison.Ordinal);
            if (technicianComparison != 0)
                return technicianComparison;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }

}

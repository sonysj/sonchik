using System.Collections;
using RepairService;

public class Service : IEnumerable<Device>
{
    public string Name { get; }
    public string Address { get; }
    public string Phone { get; }
    public int DeviceCount => _devices.Count;

    private readonly List<Device> _devices = new List<Device>();

    public Service(string name, string address, string phone)
    {
        Name = name;
        Address = address;
        Phone = phone;
    }

    public void AddDevice(Device device)
    {
        if (device == null)
            throw new ArgumentNullException(nameof(device));

        if (!_devices.Contains(device))
            _devices.Add(device);
    }

    public bool RemoveDevice(Device device)
    {
        return _devices.Remove(device);
    }

    public IEnumerator<Device> GetEnumerator()
    {
        return _devices.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

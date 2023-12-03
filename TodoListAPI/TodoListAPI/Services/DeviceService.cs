using System.Collections.Generic;
using System.Linq;
using HelloWebApi.Exceptions;
using HelloWebApi.Interfaces.Repositories;
using HelloWebApi.Interfaces.Services;
using HelloWebApi.Models;

namespace HelloWebApi.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        private const int MaxTypeDevicesCount = 5;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public Device GetDeviceById(int id)
        {
            return _deviceRepository.GetDeviceById(id);
        }

        public List<Device> GetDevices(out int totalCount)
        {
            totalCount = _deviceRepository.GetDevicesTotalCount();

            return _deviceRepository.GetDevices();
        }

        public Device AddDevice(Device device)
        {
            var storedDevices = _deviceRepository.GetDevices();

            var storedTypeDevicesCount = storedDevices.Count(d => d.Type == device.Type);

            if (storedTypeDevicesCount >= MaxTypeDevicesCount)
            {
                throw new BadOperationException($"Only {MaxTypeDevicesCount} devices for the type are available.");
            }

            return _deviceRepository.AddDevice(device);
        }
    }
}

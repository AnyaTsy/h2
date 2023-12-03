using System.Collections.Generic;
using HelloWebApi.Enums;
using HelloWebApi.Interfaces.Services;
using HelloWebApi.Models;

namespace HelloWebApi.Services
{
    public class FakeDeviceService : IDeviceService
    {
        public Device AddDevice(Device device)
        {
            throw new System.NotImplementedException();
        }

        public Device GetDeviceById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Device> GetDevices(out int totalCount)
        {
            totalCount = 1;

            return new List<Device>
            {
                new Device
                {
                    Id = 1,
                    Name = "Fake Vacuum cleaner",
                    Type = DeviceType.Vacuum
                }
            };
        }
    }
}

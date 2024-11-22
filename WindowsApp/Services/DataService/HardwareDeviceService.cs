using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PartsHunter.Data;
using PartsHunter.Data.Entities;

namespace PartsHunter.Services.DataService {
    public class HardwareDeviceService {

        private readonly PartsHunterContext _context;

        public HardwareDeviceService() {
            _context = new PartsHunterContext();
            _context.Database.EnsureCreated();
        }

        public void AddHardwareDevice(HardwareDevice hardwareDevice) {
            _context.ESP32.Add(hardwareDevice);
            _context.SaveChanges();
        }
        public bool AddIPAddress(int deviceId, string ipAddress) {
            
            var existingDevice = _context.ESP32.FirstOrDefault(device => device.Id == deviceId);

            if (existingDevice != null)                
                existingDevice.IP = ipAddress; // update
            else {
                var newDevice = new HardwareDevice {
                    Id = deviceId,
                    IP = ipAddress
                };
                _context.ESP32.Add(newDevice);
            }
            _context.SaveChanges();
            return true;
        }

        public string? GetIPAddress(int deviceId) {

 
                var existingDevice = _context.ESP32.FirstOrDefault(device => device.Id == deviceId);

                if (existingDevice != null) {
                    return existingDevice.IP; // Return the IP address if the device exists
                }
                else {
                    return null; // Return null if the device with the given ID does not exist
                }

        }
    }
}

using PartsHunter.Data;
using PartsHunter.Data.Entities;
using System.Diagnostics;

namespace PartsHunter.Services {
    public class HardwareDeviceService {

        private readonly PartsHunterContext _context;
        private static readonly HttpClient httpClient = new HttpClient();
        public string? ip_addr = string.Empty;
        public Color pixel_color;

        public HardwareDeviceService() {
            _context = new PartsHunterContext();
            _context.Database.EnsureCreated();
        }
        public void AddHardwareDevice(HardwareDeviceEntity hardwareDevice) {
            _context.HardwareDevice.Add(hardwareDevice);
            _context.SaveChanges();
        }
        public bool add_ip_addr(int deviceId, string ipAddress) {
            var existingDevice = _context.HardwareDevice.FirstOrDefault(device => device.Id == deviceId);

            if (existingDevice != null) {
                existingDevice.IP = ipAddress;
            }
            else {
                var newDevice = new HardwareDeviceEntity {
                    Id = deviceId,
                    IP = ipAddress
                };
                _context.HardwareDevice.Add(newDevice);
            }
            _context.SaveChanges();
            return true;
        }
        public string? get_ip_addr(int deviceId) {
            var value = _context.HardwareDevice.FirstOrDefault(device => device.Id == deviceId);

            if (value != null) {
                ip_addr = value.IP; ;
                return ip_addr;
            }
            else {
                return null;
            }
        }
        public async void set_pixel_color() {
            try {
                var endpoint = $"http://{ip_addr}/color?r={pixel_color.R}&g={pixel_color.G}&b={pixel_color.B}";
                var responseColor = await httpClient.PostAsync(endpoint, null);
            }
            catch (Exception) {

            }
        }
        public async void set_pixel_blinky(int interval) {
            try {
                var endpoint = $"http://{ip_addr}/blink?interval={interval}";
                var responseBlink = await httpClient.PostAsync(endpoint, null);
            }
            catch (Exception) {

            }
        }
        public async void set_pixel_brightness(int brightness) {
            try {
                var endpoint = $"http://{ip_addr}/brightness?level={brightness}";
                var responseBrightness = await httpClient.PostAsync(endpoint, null);
            }
            catch (Exception) {

            }
        }
        public async void turn_on_pixel(int pixel) {
            try {
                var endpoint = $"http://{ip_addr}/slot?id={pixel}";
                var response = await httpClient.PostAsync(endpoint, null);
            }
            catch (Exception) {

            }
        }
        public async void turn_on_pixels(List<int> pixels) {
            try {
                string slotIdList = string.Join(",", pixels);
                var endpoint = $"http://{ip_addr}/slot?id={slotIdList}";
                using (HttpClient httpClient = new HttpClient()) {
                    var response = await httpClient.PostAsync(endpoint, null);
                }
            }
            catch (Exception) {

            }
        }
        public async Task<bool> clear_pixels(int retries = 3, int delay = 2000) {

            for (int attempt = 0; attempt < retries; attempt++) {
                try {
                    var endpoint = $"http://{ip_addr}/clear";
                    var response = await httpClient.PostAsync(endpoint, null);

                    if (response.IsSuccessStatusCode) {                        
                        return true;
                    }
                    else {
                        Debug.WriteLine($"Attempt {attempt + 1} failed: Status code {response.StatusCode}");
                    }
                }
                catch (Exception ex) {
                    Debug.WriteLine($"Attempt {attempt + 1} exception: {ex.Message}");
                }

                await Task.Delay(delay);
            }
            return false;
        }
    }
}
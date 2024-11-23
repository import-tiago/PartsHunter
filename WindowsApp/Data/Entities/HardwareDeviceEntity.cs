namespace PartsHunter.Data.Entities {
    public class HardwareDeviceEntity {
        public int Id { get; set; }
        public string? IP { get; set; }
        public int blinky_ms { get; set; }
        public int brightness { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
    }
}
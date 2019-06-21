namespace CarpoolApi.Service.DataTransferObjects
{
    public class CarDto
    {
        public CarDto() { }
        public CarDto(string make, string model, int year, string color, string licensePlate)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            LicensePlateNo = licensePlate;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlateNo { get; set; }

    }
}

using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using TransportCompanyLib.Views;
using Xunit;

namespace TransportCompanyTests.ViewsTests
{
    public class ParkViewTests
    {
        [Fact]
        public void TestParkView()
        {
            Autopark autopark = new Autopark();
            MANTractor tractor1 = new MANTractor(100);
            MANTractor tractor2 = new MANTractor(200);
            var semitrailer1 = new TankSemitrailer(500, 500);
            autopark.AddTractor(tractor1);
            autopark.AddTractor(tractor2);
            autopark.AddSemitrailer(semitrailer1);

            string expected = $"Autopark tractors\r\n{tractor1}\r\n{tractor2}\r\nAutopark semitrailers\r\n{semitrailer1}\r\n";

            ParkView parkView = new ParkView(autopark);

            string actual = parkView.ShowAutopark();

            Assert.Equal(expected, actual);
        }
    }
}

using Data.Interfaces;
using Domain.Enum;
using DomainServices;
using Moq;

namespace Domain.Tests
{
    [TestFixture]
    public class ChargerServiceTests
    {
        private ChargerService _service;
        private Mock<IChargerRepository> _chargerRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            var charger = new Charger
            {
                Connector = ConnectorType.Yazaki,
                Id = 1,
                Status = ChargerStatus.Available
            };
            _chargerRepositoryMock = new Mock<IChargerRepository>(MockBehavior.Default);
            _chargerRepositoryMock
                .Setup(x => x.GetListByIds(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(new List<Charger> {charger});
            _chargerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                            .ReturnsAsync(charger);
          
            _service = new ChargerService(_chargerRepositoryMock.Object);
        }

        [Test]
        public async Task GetListByIds_Success()
        {
            var ids = new List<int> { 1, 2, 3 };
            var result = await _service.GetListByIds(ids);
            _chargerRepositoryMock.Verify(x => x.GetListByIds(It.IsAny<IEnumerable<int>>()), Times.AtLeastOnce);
        }

        [Test]
        public async Task ReservedCharger_Success()
        {
            var chargerId = 1;
            await _service.ReservedCharger(chargerId);
            _chargerRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.AtLeastOnce);
            _chargerRepositoryMock.Verify(x => x.Update(It.IsAny<Charger>()), Times.AtLeastOnce);
        }

        [Test]
        public async Task ReleasedCharger_Success()
        {
            var chargerId = 1;
            await _service.ReleasedCharger(chargerId);
            _chargerRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.AtLeastOnce);
            _chargerRepositoryMock.Verify(x => x.Update(It.IsAny<Charger>()), Times.AtLeastOnce);
        }
    }
}

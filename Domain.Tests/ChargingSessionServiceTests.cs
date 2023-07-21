using Common.Exceptions;
using Data.Interfaces;
using DomainServices;
using DomainServices.Interfaces.Validation;
using Moq;

namespace Domain.Tests
{
    [TestFixture]
    public class ChargingSessionServiceTests
    {
        private ChargingSessionService _service;
        private Mock<IChargingSessionRepository> _chargingSessionRepositoryMock;
        private Mock<IChargerValidationService> _chargerValidationServiceMock;

        [SetUp]
        public void SetUp()
        {
            var chargingSession = new ChargingSession();
            var sessions = new List<ChargingSession> { chargingSession };
            _chargingSessionRepositoryMock = new Mock<IChargingSessionRepository>(MockBehavior.Default);
            _chargingSessionRepositoryMock.Setup(x => x.GetAll())
                                            .ReturnsAsync(sessions);          
            _chargerValidationServiceMock = new Mock<IChargerValidationService>(MockBehavior.Default);

            _service = new ChargingSessionService(_chargingSessionRepositoryMock.Object, _chargerValidationServiceMock.Object);
        }

        [Test]
        public async Task GetAll_Success()
        {
            await _service.GetAll();
            _chargingSessionRepositoryMock.Verify(x => x.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public async Task GetBy_Success()
        {
            _chargingSessionRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                                         .ReturnsAsync(new ChargingSession());
            var chargingSessionId = Guid.NewGuid();
            await _service.GetBy(chargingSessionId);
            _chargingSessionRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [Test]
        public void GetBy_Throw_ChargingSessionNotFoundException()
        {
            var chargingSessionId = Guid.NewGuid();         
            Assert.ThrowsAsync<ChargingSessionNotFoundException>(() => _service.GetBy(chargingSessionId));
        }
    }
}

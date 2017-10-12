using System;
using FluentAssertions;
using TransportManagement;
using Xunit;

namespace TransportManagementTest
{
    public class TransportTest
    {
        [Fact]
        public void Give_ANewRoadTripInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            var roadTrip = new RoadTrip(32,new TimeSpan(12, 30, 45), new TimeSpan(13,45,20));
            roadTrip.Distance.Should().NotBe(null);
            roadTrip.StartTime.Should().Be(new TimeSpan(12, 30, 45));
            roadTrip.EndTime.Should().Be(new TimeSpan(13, 45, 20));
        }

        [Fact]
        public void Give_ANewRoadTripInstance_When_SettingInvalidDateParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new RoadTrip(32, new TimeSpan(13, 30, 45), new TimeSpan(12, 45, 20)));

            ex.Message.Should().Be("End time should be great than start time!");
        }

        [Fact]
        public void Give_ANewRoadTripInstance_When_SettingInvalidDistanceParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new RoadTrip(52, new TimeSpan(12, 30, 45), new TimeSpan(13, 45, 20)));

            ex.Message.Should().Be("Cannot add road trip with more than 50km!");
        }

        [Fact]
        public void Give_ANewRoadTripInstance_When_SettingNegativeDistanceParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new RoadTrip(-2, new TimeSpan(12, 30, 45), new TimeSpan(13, 45, 20)));

            ex.Message.Should().Be("Cannot add road trip with negative distance!");
        }

        [Fact]
        public void Give_ANewBusInstance_When_SettingValidParameters_Then_TheValuesShoulBeInstantiated()
        {
            var bus = new Bus();
            bus.Id.Should().NotBeEmpty();
            bus.Mileage.Should().Be(0);
            bus.FullyScheduled.Should().Be(false);
            bus.Schedule.Should().NotBeNull();
        }

        [Fact]
        public void Give_ABusInstance_When_AddRoadTripsIsCalledWhithValidRoadTrip_Then_TheLengthShouldBe4()
        {
            var bus = CreateSut();
            bus.AddRoadTrip(new RoadTrip(5, new TimeSpan(17, 32, 29), new TimeSpan(18, 0, 0)));
            bus.Schedule.Count.Should().Be(4);
        }

        [Fact]
        public void Give_ABusInstance_When_AddRoadTripsIsCalledWithInvalidDistanceRoadTrip_Then_BussinessExceptionShouldBeThrow()
        {
            var bus = CreateSut();

            Exception ex = Assert.Throws<BusinessException>(() =>
                bus.AddRoadTrip(new RoadTrip(50, new TimeSpan(17, 32, 29), new TimeSpan(18, 0, 0))));

            ex.Message.Should().Be("Cannot add road trip because schedule distance cannot be more than 100!\n" +
                                   "Curent schedule distance =" + bus.Mileage + " please add a lower road trip!");
        }

        [Fact]
        public void Give_ABusInstance_When_AddRoadTripsIsCalledWithInvalidTimeRoadTrip_Then_BussinessExceptionShouldBeThrow()
        {
            var bus = CreateSut();

            Exception ex = Assert.Throws<BusinessException>(() =>
                bus.AddRoadTrip(new RoadTrip(2, new TimeSpan(14, 55, 29), new TimeSpan(17, 0, 0))));

            ex.Message.Should().Be("Cannot add two roads in the smae period of time!");
        }

        [Fact]
        public void Give_ABusInstanceWithFullySchedule_When_AddRoadTripsIsCalled_Then_BussinessExceptionShouldBeThrow()
        {
            var bus = CreateSut();

            bus.AddRoadTrip(new RoadTrip(25, new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0)));
            bus.FullyScheduled.Should().Be(true);

            Exception ex = Assert.Throws<BusinessException>(() =>
                bus.AddRoadTrip(new RoadTrip(2, new TimeSpan(16, 55, 29), new TimeSpan(17, 0, 0))));

            ex.Message.Should().Be("Bus is fully scheduled!\nTry tomorrow! :)");
        }

        [Fact]
        public void Give_ABusInstance_When_GetAllRoadTripSchedule_Then_ShouldReturnAllRoadTrip()
        {
            var bus = CreateSut();
            bus.GetAllRoadTripSchedule().Count.Should().Be(3);
        }

        [Fact]
        public void Give_ABusInstance_When_GetAllRoadTripScheduleWithTimePeriod_Then_ShouldReturnRoadTrip()
        {
            var bus = CreateSut();
            bus.GetAllRoadTripsScheduleFromPeriodTime(new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0)).Count.Should()
                .Be(2);
        }



        private static Bus CreateSut()
        {
            var bus = new Bus();
            bus.AddRoadTrip(new RoadTrip(12, new TimeSpan(10, 20, 30), new TimeSpan(11, 0, 0)));
            bus.AddRoadTrip(new RoadTrip(45, new TimeSpan(11, 30, 56), new TimeSpan(12, 3, 0)));
            bus.AddRoadTrip(new RoadTrip(18, new TimeSpan(14, 26, 23), new TimeSpan(16, 22, 55)));
            return bus;
        }


    }
}

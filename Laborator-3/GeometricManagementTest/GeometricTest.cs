using System;
using FluentAssertions;
using GeometricManagement;
using Xunit;

namespace GeometricManagementTest
{
    public class GeometricTest
    {
        [Fact]
        public void Give_ANewCircleInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            var circle = new Circle(3.2,"red",89.9);
            circle.Id.Should().NotBeEmpty();
            circle.Radius.Should().Be(3.2);
            circle.Color.Should().Be("red");
            circle.Transparency.Should().Be(89.9);
        }
        [Fact]
        public void Give_ANewRectangleInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            var rectangle = new Rectangle(3.2, 5.7, "blue", 12.9);
            rectangle.Id.Should().NotBeEmpty();
            rectangle.Width.Should().Be(3.2);
            rectangle.Height.Should().Be(5.7);
            rectangle.Color.Should().Be("blue");
            rectangle.Transparency.Should().Be(12.9);
        }

        [Fact]
        public void Give_ANewRectangleInstance_When_SettingInvalidTransparencyParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Rectangle(3.2, 5.7, "blue", -12.9));

            ex.Message.Should().Be("Transparency should be between 0 and 100!");
        }

        [Fact]
        public void Give_ANewCircleInstance_When_SettingInvalidTransparencyParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Circle(3.2, "blue", 102.9));

            ex.Message.Should().Be("Transparency should be between 0 and 100!");
        }
        [Fact]
        public void Give_ANewCircleInstance_When_SettingInvalidRadiusParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Circle(-12, "blue", 12.9));

            ex.Message.Should().Be("Radius should be greater than 0!");
        }

        [Fact]
        public void Give_ANewRectangleInstance_When_SettingInvalidWidthParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Rectangle(-12.2,32, "blue", 12.9));

            ex.Message.Should().Be("Width should be greater than 0!");
        }

        [Fact]
        public void Give_ANewRectangleInstance_When_SettingInvalidHeightParameter_Then_ArgumentExceptionShouldBeThrown()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Rectangle(12.2, -32, "blue", 12.9));

            ex.Message.Should().Be("Height should be greater than 0!");
        }

        [Fact]
        public void Give_ACircleInstance_When_ComputeAreasIsCalledWhithValidValidParameter_Then_TheAreaShouldBeCorrect()
        {
            var circle = new Circle(3.2, "red", 89.9);
            circle.ComputeArea().Should().Be(32.169908772759484);
        }

        [Fact]
        public void Give_ACircleInstance_When_IsVisibleIsCalledWhithValidValidParameter_Then_TheAreaShouldBeTrue()
        {
            var circle = new Circle(3.2, "red", 49.9);
            circle.IsVisible().Should().Be(true);
        }
        [Fact]
        public void Give_ARectangleInstance_When_ComputeAreaIsCalledWhithValidValidParameter_Then_TheAreaShouldBeCorrect()
        {
            var rectangle = new Rectangle(3.2, 5.7, "blue", 12.9);
            rectangle.ComputeArea().Should().Be(18.240000000000002);
        }
        [Fact]
        public void Give_ARectangleInstance_When_DrawingIsCalledWhithValidParameter_Then_TheAreaShouldReturnDrawingRectangle()
        {
            var rectangle = new Rectangle(3.2, 5.7, "blue", 12.9);
            rectangle.Draw().Should().Be("Drawing Rectangle");
        }
        [Fact]
        public void Give_ACircleInstance_When_DrawingIsCalledWhithValidValidParameter_Then_TheAreaShouldReturnDrawingCircle()
        {
            var circle = new Circle(3.2, "red", 89.9);
            circle.Draw().Should().Be("Drawing Circle");
        }

    }
}

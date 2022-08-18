using FluentAssertions;

namespace Ayo.Core.Tests;

public class LengthAreaVolumeConversionTests
{
    
    [Theory()]
    [InlineData("mm", "in",1.0, 0.0394,0.0394)]
    [InlineData("in", "mm",4.0, 25.40,101.6)]
    [InlineData("in", "cm",4.0, 2.54,10.16)]
    [InlineData("in", "cm",8.0, 2.54,20.32)]
    [InlineData("ft", "m",8.0, 0.3048,2.4384)]
    [InlineData("m", "ft",6.0, 3.2809,19.6854)]
    [InlineData("km", "mi",8.0, 0.6214,4.9712)]
    [InlineData("mi", "km",6.0, 1.6093,9.6558)]
    public void GivenSourceAndTargetAndMultiplierConvert(string source,string target,
                                            double value,
                                            double multiplier,double expected)

    {
        var sut = new LengthAreaVolumeConverter();
        var result =  sut.Convert(source,target,value,multiplier);
        result.Should().Be(expected);
    }
    
    [Fact]
    public void GivenUnSupportedSourceAndTargetThenThrowInvalidOperationException()

    {
        var source = "mm";
        var target = "l";
        var value = 1d;
        var multiplier = 2.4;
        var sut = new LengthAreaVolumeConverter();
        Assert.Throws<InvalidOperationException>(()=>sut.Convert(source,target,value,multiplier));
    }
}
using System;
using Xunit;

namespace HelpfulThings.DataTypes.Unix.Test.UnixTimestamp
{
    public class TimestampKnownDateTests
    {
        [Fact]
        public void Date_1996_2_12_14_23_50()
        {
            const int timestamp = 824135030;
            var expectedDateTime = new DateTime(1996, 2, 12, 14, 23, 50);
            
            var typeUnderTest = new UnixTimeStamp(timestamp);
            
            Assert.Equal(expectedDateTime, typeUnderTest.DateTime);
            Assert.Equal(timestamp, typeUnderTest.ToTimestampValue());
        }
        
        [Fact]
        public void Date_2038_1_19_03_14_07()
        {
            const int timestamp = 2147483647;
            var expectedDateTime = new DateTime(2038, 1, 19, 3, 14, 07);
            
            var typeUnderTest = new UnixTimeStamp(timestamp);
            
            Assert.Equal(expectedDateTime, typeUnderTest.DateTime);
            Assert.Equal(timestamp, typeUnderTest.ToTimestampValue());
        }
        
        [Fact]
        public void Date_1901_12_13_20_45_52()
        {
            const int timestamp = -2147483648;
            var expectedDateTime = new DateTime(1901, 12, 13, 20, 45, 52);
            
            var typeUnderTest = new UnixTimeStamp(timestamp);
            
            Assert.Equal(expectedDateTime, typeUnderTest.DateTime);
            Assert.Equal(timestamp, typeUnderTest.ToTimestampValue());
        }
    }
}
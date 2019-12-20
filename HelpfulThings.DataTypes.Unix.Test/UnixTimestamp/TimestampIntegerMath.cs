using System;
using Xunit;

namespace HelpfulThings.DataTypes.Unix.Test
{
    public class TimestampIntegerMath
    {
        [Fact]
        public void UnixTimestampIntegerAdditionLeftHand()
        {
            var timestamp = new UnixTimeStamp(1000);
            
            var expectedTime = new DateTime(1970, 1,1,0,17,40);

            var testResult = timestamp + 60;
            
            Assert.Equal(expectedTime, testResult.DateTime);
        }
        
        [Fact]
        public void UnixTimestampIntegerAdditionRightHand()
        {
            var timestamp = new UnixTimeStamp(1000);
            
            var expectedTime = new DateTime(1970, 1,1,0,17,40);

            var testResult = 60 + timestamp;
            
            Assert.Equal(expectedTime, testResult.DateTime);
        }
        
        [Fact]
        public void UnixTimestampIntegerSubtractionLeftHand()
        {
            var timestamp = new UnixTimeStamp(1000);
            
            var expectedTime = new DateTime(1970, 1,1,0,15,40);

            var testResult = timestamp - 60;
            
            Assert.Equal(expectedTime, testResult.DateTime);
        }
        
        [Fact]
        public void UnixTimestampIntegerSubtractionRightHand()
        {
            var timestamp = new UnixTimeStamp(1000);
            
            var expectedTime = new DateTime(1970, 1,1,0,15,40);

            var testResult = 1940 - timestamp;
            
            Assert.Equal(expectedTime, testResult.DateTime);
        }
    }
}
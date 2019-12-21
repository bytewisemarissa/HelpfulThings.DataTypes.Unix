using System;
using Xunit;

namespace HelpfulThings.DataTypes.Unix.Test.UnixTimestamp
{
    public class TimestampEquality
    {
        [Fact]
        public void TimestampEqualitySelf()
        {
            var stampOne = new UnixTimeStamp(1000);
            var stampTwo = new UnixTimeStamp(1000);
            
            Assert.True(stampOne == stampTwo);
            Assert.False(stampOne != stampTwo);
            
            Assert.True(stampOne.Equals(stampTwo));
        }
        
        [Fact]
        public void TimestampEqualityInt()
        {
            var stampOne = new UnixTimeStamp(1000);
            var stampTwo = 1000;
            
            Assert.True(stampOne == stampTwo);
            Assert.False(stampOne != stampTwo);
            
            Assert.True(stampTwo == stampOne);
            Assert.False(stampTwo != stampOne);
            
            Assert.True(stampOne.Equals(stampTwo));
        }
        
        [Fact]
        public void TimestampEqualityDateTime()
        {
            var stampOne = new UnixTimeStamp(1000);
            var stampTwo = new DateTime(1970, 1,1,0,16,40);
            
            Assert.True(stampOne == stampTwo);
            Assert.False(stampOne != stampTwo);
            
            Assert.True(stampTwo == stampOne);
            Assert.False(stampTwo != stampOne);
            
            Assert.True(stampOne.Equals(stampTwo));
        }
    }
}
using System;
using Xunit;

namespace HelpfulThings.DataTypes.Unix.Test.UnixTimestamp
{
    public class ConversionCastingTests
    {
        [Fact]
        public void IntegerConversion()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            UnixTimeStamp testTimestamp = 1000;
            
            Assert.True(expected == testTimestamp);
        }  
        
        [Fact]
        public void DateTimeConversion()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            UnixTimeStamp testTimestamp = expected;
            
            Assert.True(expected == testTimestamp);
        }  
        
        [Fact]
        public void LongCast()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            UnixTimeStamp testTimestamp = (UnixTimeStamp)(long)1000;
            
            Assert.True(expected == testTimestamp);
        } 
    }
}
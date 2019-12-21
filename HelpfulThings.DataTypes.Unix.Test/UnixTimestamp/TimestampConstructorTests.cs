using System;
using Xunit;

namespace HelpfulThings.DataTypes.Unix.Test.UnixTimestamp
{
    public class TimestampConstructorTests
    {
        [Fact]
        public void IntegerConstructor()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            var testTimestamp = new UnixTimeStamp(1000);
            
            Assert.True(expected == testTimestamp);
        }   
        
        [Fact]
        public void LongConstructor()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            var testTimestamp = new UnixTimeStamp((long)1000);
            
            Assert.True(expected == testTimestamp);
        }  
        
        [Fact]
        public void StringConstructor()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            var testTimestamp = new UnixTimeStamp("1000");
            
            Assert.True(expected == testTimestamp);
        } 
        
        [Fact]
        public void DateTimeConstructor()
        {
            var expected = new DateTime(1970, 1,1,0,16,40);
            var testTimestamp = new UnixTimeStamp(expected);
            
            Assert.True(expected == testTimestamp);
        } 
    }
}
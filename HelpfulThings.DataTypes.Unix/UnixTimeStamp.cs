using System;

namespace HelpfulThings.DataTypes.Unix
{
    public struct UnixTimeStamp
    {
        public static readonly DateTime BaseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        public static readonly DateTime Minimum = BaseDate.AddSeconds(int.MinValue);
        public static readonly DateTime Maximum = BaseDate.AddSeconds(int.MaxValue);

        public DateTime DateTime { get; }
        
        public UnixTimeStamp(string ticksString)
        {
            try
            {
                var ticks = Convert.ToInt32(ticksString);
                
                DateTime = BaseDate.AddSeconds(ticks);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There was a problem with your stringified timestamp.", ex);
            }
        }

        public UnixTimeStamp(int ticks)
        {
            DateTime = BaseDate.AddSeconds(ticks);
        }

        public UnixTimeStamp(long ticks)
        {
            if (ticks > int.MaxValue || ticks < int.MinValue)
            {
                throw new ArgumentException(
                    $"UnixTimeStamps can not represent a value under {int.MaxValue} or a value over {int.MinValue}.");
            }

            DateTime = BaseDate.AddSeconds(ticks);
        }

        public UnixTimeStamp(DateTime dateTime)
        {
            if (dateTime < Minimum || dateTime > Maximum)
            {
                throw new ArgumentException($"UnixTimeStamps can not represent a time before {Minimum} or a time after {Maximum}.");
            }
            
            DateTime = dateTime.ToUniversalTime();
        }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                null => false,
                UnixTimeStamp other => Equals(other),
                int otherTicks => Equals(otherTicks),
                DateTime otherDateTime => Equals(otherDateTime),
                _ => false
            };
        }

        private bool Equals(UnixTimeStamp other)
        {
            return DateTime.Equals(other.DateTime);
        }

        private bool Equals(int other)
        {
            return ToTimestampValue().Equals(other);
        }

        private bool Equals(DateTime other)
        {
            return DateTime.Equals(other);
        }
        
        public static bool operator ==(UnixTimeStamp left, UnixTimeStamp right)
        {
            return left.DateTime.Equals(right.DateTime);
        }
        
        public static bool operator !=(UnixTimeStamp left, UnixTimeStamp right)
        {
            return !(left == right);
        }

        public static bool operator ==(UnixTimeStamp left, DateTime right)
        {
            return left.DateTime.Equals(right);
        }
        
        public static bool operator !=(UnixTimeStamp left, DateTime right)
        {
            return !(left == right);
        }

        public static bool operator ==(DateTime left,UnixTimeStamp  right)
        {
            return right.DateTime.Equals(left);
        }

        public static bool operator !=(DateTime left, UnixTimeStamp right)
        {
            return !(left == right);
        }
        
        public static bool operator ==(UnixTimeStamp left, int right)
        {
            return left.ToTimestampValue().Equals(right);
        }
        
        public static bool operator !=(UnixTimeStamp left, int right)
        {
            return !(left == right);
        }

        public static bool operator ==(int left,UnixTimeStamp  right)
        {
            return right.ToTimestampValue().Equals(left);
        }

        public static bool operator !=(int left, UnixTimeStamp right)
        {
            return !(left == right);
        }
        
        public static UnixTimeStamp operator +(UnixTimeStamp left, int right)
        {
            return new UnixTimeStamp(left.DateTime.AddSeconds(right));
        }
        
        public static UnixTimeStamp operator +(int left, UnixTimeStamp right)
        {
            return new UnixTimeStamp(right.DateTime.AddSeconds(left));
        }
        
        public static UnixTimeStamp operator -(UnixTimeStamp left, int right)
        {
            return new UnixTimeStamp(left.DateTime.AddSeconds(-right));
        }
        
        public static UnixTimeStamp operator -(int left, UnixTimeStamp right)
        {
            return new UnixTimeStamp(left - right.ToTimestampValue());
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }

        public int ToTimestampValue()
        {
            return Convert.ToInt32((DateTime - BaseDate).TotalSeconds);
        }
    }
}
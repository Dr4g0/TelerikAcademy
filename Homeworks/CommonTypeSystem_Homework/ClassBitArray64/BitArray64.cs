using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        public ulong Number { get; private set; }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] numberAsBits = this.ConvertToBits();

            for (int i = 0; i < numberAsBits.Length; i++)
            {
                yield return numberAsBits[i];
            }

        }

        public int[] ConvertToBits()
        {
            int[] result = new int[64];
            ulong tmp = this.Number;
            for (int i =0; i <63; i++)
            {
                if (tmp>0)
                {
                    result[i] = (int)(tmp % 2);
                }
                else
                {
                   break;
                }
                tmp /= 2;
            }
            return result;
        }

        public bool Equals(BitArray64 number)
        {
            if (this.Number!=number.Number)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            BitArray64 number = obj as BitArray64;
            if ((object)number == null)
            {
                return false;
            }
            return this.Equals(number);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.Number.GetHashCode();
                return result;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index<0||index>63)
                {
                    throw new IndexOutOfRangeException("Incorrect index");
                }
                int[] numberInBits = this.ConvertToBits();
                return numberInBits[index];
            }
        }

        public static bool operator ==(BitArray64 number1, BitArray64 number2)
        {
            return Equals(number1, number2);
        }

        public static bool operator !=(BitArray64 number1, BitArray64 number2)
        {
            return !Equals(number1, number2);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int[] res = this.ConvertToBits();
            for (int i = 63; i >=0; i--)
            {
                result.Append(res[i].ToString());
            }
            return result.ToString();
        }
    }
}

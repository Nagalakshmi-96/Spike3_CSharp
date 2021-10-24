using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    public class DecimalFields<T>
    {
        public T decimalfield1 { get; set; }
        public T decimalfield2 { get; set; }
        public T decimalfield3 { get; set; }
        public T decimalfield4 { get; set; }
        public T decimalfield5 { get; set; }
        public T decimalfield6 { get; set; }
        public T decimalfield7 { get; set; }
        public T decimalfield8 { get; set; }
        public T decimalfield9 { get; set; }
        public T decimalfield10 { get; set; }

        public DateTime datefield1 { get; set; }
        public DateTime datefield2 { get; set; }

        public int intfield1 { get; set; }
        public int intfield2 { get; set; }

        public DecimalFields<T> Copy()
        {
            return (DecimalFields<T>)this.MemberwiseClone();
        }
    }
    public class Class1
    {
        static void Main()
        {
            #region Initializing Original and Copy Class
            DecimalFields<decimal> c1 = new DecimalFields<decimal>();
            DecimalFields<decimal> c2 = new DecimalFields<decimal>();
            int localVar = 3;
            #endregion

            #region Initialize Decimal Fields
            int i = 0;
            List<decimal> list= new List<decimal>();
            for (i = 0; i < 10; i++)
                list.Add(0.5m + i);

            i = 0;
            foreach (var prop in c1.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(decimal))
                {
                    prop.SetValue(c1,list[i++]);
                }
            }

            #endregion

            #region Performing Copy
            c2 = c1.Copy();
            #endregion

            #region Performing Application Logic

            foreach (var prop in c1.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(decimal))
                {
                    prop.SetValue(c1, (decimal)prop.GetValue(c1)/localVar);
                    prop.SetValue(c2, (decimal)prop.GetValue(c2)- (decimal)prop.GetValue(c1));
                }
            }

            #endregion

            #region Printing the Values
            foreach (var prop in c1.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(decimal))
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine(prop.GetValue(c1));
                    Console.WriteLine(prop.GetValue(c2));
                }
            }
            #endregion
            
            Console.Read();
        }
    }
}

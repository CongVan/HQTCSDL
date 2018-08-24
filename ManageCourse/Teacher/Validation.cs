using System;
using System.Linq;

namespace Teacher
{
    public class Validation
    {
        public static Boolean isAllWhiteSpace(String value)
        {
            int dem = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsWhiteSpace(value.ElementAt(i)))
                {
                    // đếm số khoảng trắng
                    dem++;
                }

                if (dem == value.Length)
                {
                    // độ dài khoảng trắng = độ dài chuỗi
                    // chuỗi chỉ chứa khoảng trắng
                    return true;
                }
            }

            return false;
        }
    }
}
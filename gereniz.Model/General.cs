using System;
namespace gereniz.Model
{
    public class General<T>
    {
        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
    }
}

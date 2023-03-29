using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTreeTool
{
    internal enum ObejctSerilizeType : Byte
    {
        OBJ_NULL = 0,       //空对象         序列化的时候需要【写0】  
        OBJ_FIRST = 1,      //第一个实例     序列化的时候需要【先写1】【将对象缓存引用且计数】【缓存对象类型】【将对象写进流中】
        OBJ_REF = 2,        //引用           序列化的时候需要【先写2】【缓存对象索引的引用计数】
    }

    internal abstract class SerializeData
    {
        public void WriteTo(IStream stream)
        {
            WriteToImp(stream);
        }

        protected abstract void WriteToImp(IStream stream);

        public void ReadFrom(IStream stream)
        {
            ReadFromImp(stream);
        }

        protected abstract void ReadFromImp(IStream stream);

    }

    internal class SerializeHelper
}

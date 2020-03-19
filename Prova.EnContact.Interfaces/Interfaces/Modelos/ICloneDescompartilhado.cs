using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos
{
    public interface ICloneDescompartilhado<T> : ICloneable
    {
        T CloneDescompartilhado();
    }
}
